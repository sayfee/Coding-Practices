using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplatePattern
{

    public class Hamburger: Sandwich
    {
        public void makeSandwich() { }
        public override void addMeat()
        {
            Console.WriteLine("Hamburger Added");
        }

        public override void addCondiments()
        {
            Console.WriteLine("Special souse added");
        }
    }

    public class VeggieSub : Sandwich
    {
        bool customerWantsMeat() { return false; }
        public override void addMeat()
        { 
        }

        public override void addCondiments()
        {
            Console.WriteLine("Vinegar Added");
        }
    }


    public abstract class Sandwich {
        
        public void makeSandwich() {
            Console.WriteLine("--------NEW ORDER -----------");
            cutBun();
            if (customerWantsMeat())
            {
                addMeat();
            }

            addVEgetables();

            if (customerWantsCondiments())
                addCondiments();

            wrapSandwich();
        }

        public abstract void addMeat();
        public abstract void addCondiments();
        public void cutBun() {
            Console.WriteLine(" Cutting Bun");
        }

        public void addVEgetables()
        {
            Console.WriteLine("added tomate, lettuce and onions");
        }
        public void wrapSandwich()
        {
            Console.WriteLine("The Sandwich was Wrapped");
        }

        bool customerWantsMeat() { return true; }
        bool customerWantsCondiments() { return true; }
    }
}
