using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApplication1.DesignPattern;

namespace ConsoleApplication1.AbstractFactory
{
    class EnemyShipTesting
    {
        public static void Main2()
        {
            while (true)
            {
                string s = Console.ReadLine();
                EnemyShipBuilding makeUFOS = new UFOEnemyShipBuilding();
                EnemyShip e = makeUFOS.orderTheShip(s);
                if (e != null)
                    Console.WriteLine(e);
                if (s == "x")
                    break;
            } 
        }
    }

    abstract class EnemyShipBuilding
    {
        public abstract EnemyShip makeEnemyShip(String typeOfShip);

        public EnemyShip orderTheShip(string typeOfShip)
        {
            EnemyShip theEnemyShip = makeEnemyShip(typeOfShip);
            theEnemyShip.MakeShip();
            theEnemyShip.displayEnemyShip();
            theEnemyShip.followHeroShip();
            theEnemyShip.enemyShipShoots();

            return theEnemyShip;
        }
    }

    class UFOEnemyShipBuilding : EnemyShipBuilding
    {
        public override EnemyShip makeEnemyShip(String typeOfShip)
        {
            EnemyShip theEnemyShip = null;

            if (typeOfShip.Equals("UFO"))
            {
                EnemyShipFactory shipPartsFactory = new UFOEnemyShipFactory();
                theEnemyShip = new UFOEnemyShip(shipPartsFactory);
                theEnemyShip.Name = "UFO Grunt Ship";
            }
            else if (typeOfShip.Equals("UFO BOSS"))
            {
                EnemyShipFactory shipPartsFactory = new UFOBossEnemyShipFactory();
                theEnemyShip = new UFOEnemyShip(shipPartsFactory);
                theEnemyShip.Name = "UFO BOSS Ship";
            }


            return theEnemyShip;
        }
    }

    class UFOEnemyShip : EnemyShip
    {
        EnemyShipFactory shipFactory;
        public UFOEnemyShip(EnemyShipFactory shipFactory)
        {
            this.shipFactory = shipFactory;
        }
         
        public override void MakeShip()
        {
            Console.WriteLine("Making a new ship " + Name);

            engine = shipFactory.addESEngine();
            weapon = shipFactory.addESGun();            
        }

    }

    abstract class EnemyShip
    {
        private string name;

        public ESEngine engine;
        public ESWeapon weapon;

        public abstract void MakeShip();

        public void followHeroShip()
        {
            Console.WriteLine(Name + " is following the here at " + engine);
        }

        public void displayEnemyShip()
        {
            Console.WriteLine(Name + " is on the screen");
        }

        public void enemyShipShoots()
        {
            Console.WriteLine(name + " attacks and does " + weapon);
        }

        public override string ToString()
        {
            return "The " + name + " has a top speed of " + engine
                + " and and attack power of " + weapon;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        } 

    }

    class UFOEnemyShipFactory : EnemyShipFactory
    {

        public ESWeapon addESGun()
        {
            return new ESUFOGun();
        }

        public ESEngine addESEngine()
        {
            return new ESUFOEngine();
        }
    }

    class UFOBossEnemyShipFactory : EnemyShipFactory
    {
        public ESWeapon addESGun()
        {
            return new ESUFOBossGun();
        }

        public ESEngine addESEngine()
        {
            return new ESUFOBossEngine();
        }
    }

    public interface EnemyShipFactory
    {
        ESWeapon addESGun();
        ESEngine addESEngine();
    }

    public interface ESWeapon
    {
        string ToString();
    }

    public interface ESEngine
    {
        string ToString();
    }

    class ESUFOBossGun : ESWeapon
    {
        public override string ToString()
        {
            return "40 damage";
        }
    }

    class ESUFOBossEngine : ESEngine
    {
        public override string ToString()
        {
            return "2000 mph";
        }
    }

    class ESUFOGun : ESWeapon
    {
        public override string ToString()
        {
            return "20 damage";
        }
    }
    class ESUFOEngine : ESEngine
    {
        public override string ToString()
        {
            return "1000 mph";
        }
    }

}
