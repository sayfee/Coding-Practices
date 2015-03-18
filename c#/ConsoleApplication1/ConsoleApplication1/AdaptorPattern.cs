using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptorPattern
{
    class AdaptorPattern
    {
    }

    public interface Enemy
    {
        void moveShip();
        void makeShipAttack();
    }

    public class Galax : Enemy
    {
        private int attackPower = 5;
        private int spacesMovedPerTurn = 2;

        public void moveShip()
        {
            Console.WriteLine("Galax moves " + spacesMovedPerTurn +" spaces");
        }

        public void makeShipAttack()
        {
            Console.WriteLine("Galax does " + attackPower + " damage");
        }
    }

    public class GalaxPrime
    {
        protected string name = "Galaxian Prime";
        private int attackPower = 15;
        protected int spacesMovedPerTurn = 4;

        public void turnOnForceField()
        {
            Console.WriteLine( name + " turns on force field");
        }


        public void warpToSpace()
        {
            Console.WriteLine(name + " Warps " + spacesMovedPerTurn + " Space");
        }

        public void chargePhasers()
        {
            Console.WriteLine(name + " charges phasers ");       
        }


        public void firePhasers()
        {
            Console.WriteLine(name + " fire phasers for "+ attackPower);
        }
    }


    public class EnemyAdapter : Enemy
    {
        GalaxPrime galaxPrime;

        public EnemyAdapter(GalaxPrime galaxPrime)
        {
            this.galaxPrime = galaxPrime;
        }

        public void moveShip()
        {
            galaxPrime.turnOnForceField();
            galaxPrime.warpToSpace();
        }

        public void makeShipAttack()
        {
            galaxPrime.chargePhasers();
            galaxPrime.firePhasers();
        }
    }

    public class TestAdaptor
    {
        public static void Main1()
        {
            Enemy galax = new Galax();
            GalaxPrime galaxPrimeAdaptee = new GalaxPrime();
            Enemy galaxPrime = new EnemyAdapter(galaxPrimeAdaptee);

            galax.moveShip();
            galax.makeShipAttack();
            Console.WriteLine();

            galaxPrime.moveShip();
            galaxPrime.makeShipAttack();

            Console.ReadKey();
        }
    }

}
