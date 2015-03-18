using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.DesignPattern
{
    class Strategy
    {
        public static void Main1()
        {
            Cow c = new Cow();
            c.flyType.fly();

            Bird b = new Bird();
            b.flyType.fly();


            Console.ReadKey();
        }
    }

    class Cow : Animalize
    {
        public Cow(): base("Cow")
        {
            flyType = new CantFly();
        }
    }

    class Bird : Animalize
    {
        public Bird()
            : base("Bird")
        {
            flyType = new ItFlys();
        }
    }

    abstract class Animalize
    {
        string _name;
        public Flys flyType;

        public string getName()
        {
            return _name;
        }
 
        public Animalize(string name)
        {
            this._name = name;
            Console.Write(getName());
        }
    
    }

    public interface Flys
    {
        void fly();
    }

    class ItFlys : Flys
    {
        public void fly()
        {
            Console.WriteLine(" This animal can fly");
        }
    }

    class CantFly : Flys
    {
        public void fly()
        {
            Console.WriteLine(" CANNOT fly");
        }
    }
}
