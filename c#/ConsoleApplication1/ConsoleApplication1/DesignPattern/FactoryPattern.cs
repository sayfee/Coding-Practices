using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.DesignPattern
{
    class FactoryPattern
    {
        public static void Main1()
        {
            while (true)
            {
                string s = Console.ReadLine();

                EnemeyShipFactort factory = new EnemeyShipFactort();
                EnemyShip e = factory.makeEnemyShip(s);
                if(e != null)
                    Console.WriteLine(e.ToString());
                if (s == "x")
                    break;
            }


        }
    }

    class EnemeyShipFactort
    {
        public EnemyShip makeEnemyShip(string shipType)
        {
            EnemyShip ship = null;
            if (shipType == "U")
                ship = new UFOEnemyShip();
            else if (shipType == "B")
                ship = new BigUFOEnemyShip();



            return ship;
        }
    }

    public class BigUFOEnemyShip : EnemyShip
    {
        public BigUFOEnemyShip()
        {
            setName("Big UFO Enemy Ship");
            setDamage(40);
            setSpeed(20);
        }        
    }

    class UFOEnemyShip : EnemyShip
    {
        public UFOEnemyShip()
        {
            setName("UFO Enemy Ship");
            setDamage(20);
            setSpeed(5);
        }
    }

    public abstract class EnemyShip
    {
        private string name;
        private double speed;
        private double damage;

        public string getName()
        {
            return this.name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setSpeed(double speed)
        {
            this.speed = speed;
        }

        public double getSpeed()
        {
            return speed;
        }

        public void setDamage(double damage)
        {
            this.damage = damage;
        }
        public double getDamage()
        {
            return damage;
        }

        public override string ToString()
        {
            return "Ship : " + name + " Damage: " + damage + " Speed : " + speed;
        }
    }
}
