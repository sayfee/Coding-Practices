using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeSafety
{
    public interface HairCut
    {
        string getDescription();
        double getCost();
    }

    public abstract class HairCutDecorator : HairCut
    {
        protected HairCut hairCut;

        public HairCutDecorator(HairCut hairCut)
        {
            this.hairCut = hairCut;
        }



        public string getDescription()
        {
            return hairCut.getDescription();
        }

        public double getCost()
        {
            return hairCut.getCost();
        }
    }

    public class RegularHairCut : HairCut
    {
        public string getDescription()
        {
            return "Trim the Hair";
        }

        public double getCost()
        {
            return 10;
        }
    }

    public class Perm : HairCutDecorator
    {
        public Perm(HairCut hairCut) : base(hairCut) { }

        public string getDescription()
        {
            return hairCut.getDescription() + "\nAdd Chemicals and Put hair in Rollers";

        }

        public double getCost()
        {
            return hairCut.getCost() + 70;
        }
    }

    public class TestHairCut
    {
        public static void Main1()
        {
            Perm permAndCut = new Perm(new RegularHairCut());
            Console.WriteLine("SERVICES");
            Console.WriteLine(permAndCut.getDescription());
            Console.WriteLine("Price : $" + permAndCut.getCost());
            Console.ReadKey();
        }
    }
}
