using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatePattern;
using TreesWithCompositePattern;

namespace ConsoleApplication1
{
    class Program
    {


        static void Main1()
        {
            //Employees salesman = new Employees(true, 15000, 1000);
            //Employees secretary = new Employees(false, 20000, 100);

            #region strategy pattren

            //Employee salesMan = new Salesman(15000);
            //Employee secretary = new Secretary(10000);

            //Console.WriteLine("Salesman " + salesMan.getPay());
            //Console.WriteLine("Secretary " + secretary.getPay());

            //salesMan.BonusOption(new GetsBonus());
            //Console.WriteLine("Salesman bonus " + salesMan.getPay());

            //salesMan.BonusOption(new Bonus20());
            //Console.WriteLine("Salesman bonus 20   " + salesMan.getPay());

            //secretary.BonusOption(new NoBonus());
            //Console.WriteLine("Secretaru no bon   " + secretary.getPay()); 
            #endregion

            #region Cook - Template pattern
            //Sandwich cust1 = new Hamburger();
            //cust1.makeSandwich();

            //Sandwich cust2 = new VeggieSub();
            //cust2.makeSandwich();
            #endregion

            #region Trees with composite patttern
            //ProductComponent produce = new ProductGroup("Produce");
            //ProductComponent cereal = new ProductGroup("Cereal");

            //ProductComponent evereyProduct = new ProductGroup("All Product\n");

            //evereyProduct.add(produce);
            //evereyProduct.add(cereal);

            //produce.add((new Product("Tomato", 2.2)));
            //produce.add(new Product("Orange", 2.99));
            //produce.add(new Product("Potato", .32));

            //cereal.add(new Product("Special K", 3.2));
            //cereal.add(new Product("cherig", 3.99));
            //cereal.add(new Product("adk eo", 3.32));

            //evereyProduct.displayProductInfo();
            #endregion

            Console.ReadKey();
        }

    }
}
