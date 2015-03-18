using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderDesignPattern
{
    public class Sandwich
    {
        private string bread = "";

        private string cheese = "";

        public string Cheese
        {
            get { return cheese; }
            set { cheese = value; }
        }
        private string meat = "";

        public string Meat
        {
            get { return meat; }
            set { meat = value; }
        }
        private string vegetables = "";

        public string Vegetables
        {
            get { return vegetables; }
            set { vegetables = value; }
        }
        private string condiments = "";

        public string Condiments
        {
            get { return condiments; }
            set { condiments = value; }
        }

        public string Bread
        {
            get { return bread; }
            set { bread = value; }
        }

        public String toString()
        {
            return Bread + " "
                + Cheese + " "
                + Meat + " "
                + Vegetables + " "
                + condiments;
        }
    }

    public abstract class SandwichBuilder {
        public Sandwich sandwich;

        public Sandwich getSandwich()
        {
            return sandwich;
        }

        public void makeSandwich()
        {
            sandwich = new Sandwich();
        }

        public abstract void buildBread();
        public abstract void buildVegetables();
        public abstract void buildMeat();
        public abstract void buildCheese();
        public abstract void buildCondiments();
    }

    public class BLTBuilder : SandwichBuilder
    {
        public override void buildBread()
        {
            sandwich.Bread = "White Bread";
        }

        public override void buildVegetables()
        {
            sandwich.Vegetables = "Lettuce, tomato, onion";
        }

        public override void buildMeat()
        {
            sandwich.Meat = "Bacon";
        }

        public override void buildCheese()
        {
            sandwich.Cheese = "Mozeralla";
        }

        public override void buildCondiments()
        {
            sandwich.Condiments = "Mayonez";
        }
    }

    public class SandwichArtist {
        private SandwichBuilder sandwichBuilder;

        public void setSandwichBuilder(SandwichBuilder sandwichBuilder) 
        {
            this.sandwichBuilder = sandwichBuilder;
        }

        public Sandwich getSandwich()
        {
            return sandwichBuilder.getSandwich();
        }

        public void takeSandwichOrder()
        {
            sandwichBuilder.makeSandwich();
            sandwichBuilder.buildBread();
            sandwichBuilder.buildVegetables();
            sandwichBuilder.buildMeat();
            sandwichBuilder.buildCheese();
            sandwichBuilder.buildCondiments();
        }
    }

    public class TestBuilder
    {

        //static void Main()
        //{
        //    SandwichArtist pauo = new SandwichArtist();
        //    SandwichBuilder bltbuilder = new BLTBuilder();
        //    pauo.setSandwichBuilder(bltbuilder);
        //    pauo.takeSandwichOrder();
        //    Sandwich bltSandwich = pauo.getSandwich();
        //    Console.WriteLine(bltSandwich.toString());
        //    Console.ReadKey();
        //}
    }
}
