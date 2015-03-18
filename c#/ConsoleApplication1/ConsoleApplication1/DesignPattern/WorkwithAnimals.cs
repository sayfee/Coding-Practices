using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.DesignPattern
{
    class WorkwithAnimals
    {
        int justANum = 15;
        public static void Main1()
        {
            Animal dog = new Animal();
            dog.Name ="Grover";

            Console.WriteLine(dog.Name);

            int randomN = 10;
            dog.digHole();
            dog.changeVar(ref randomN);

            Console.WriteLine("Random method outside vale : " + randomN);

            ChangeName(dog);
            Console.WriteLine("Dog name after " + dog.Name);

            Console.WriteLine("================"  );

            Animal doggy = new Dog();
            Animal kitty = new Cat();

            Animal[] animals = new Animal[4];
            animals[0] = doggy;
            animals[1] = kitty;

            animals[0].GetSound();
            animals[1].GetSound();

            speakAnimal(animals[0]);

            ((Dog)doggy).digHole();

            ((Dog)doggy).callPrivate();

            Giraffe giraf = new Giraffe();
            giraf.SetName("Giraf");
            Console.WriteLine(giraf.getName());

            Console.ReadKey();
        }

        static void ChangeName(Animal a)
        {
            a.Name = "Didi";
        }
        
        public static void speakAnimal(Animal an)
        {
            Console.WriteLine("Animal says : " + an.Sound);
        }

        public void sayHello(){}
    }

    class Animal
    {
        private string name;
        private string sound;

        public string Sound
        {
          get { return sound; }
          set { sound = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int weight;

        public void digHole()
        {
            Console.WriteLine(name + " dug a hole");
        }

        public void changeVar(ref int randum)
        {
            randum = 12;
            Console.WriteLine("Random method inside vale : " + randum); 
        }

        public void GetSound()
        {
            Console.WriteLine(Name + " make sound of " + sound);
        }

        
    }

    class Dog : Animal
    {
        public Dog()
        {
            this.Name = "Dog";
            this.Sound = "Bark";
        }

        public void digHole()
        {
            Console.WriteLine("Dog dig holes ");
        }

        private void bePrivate()
        {
            Console.WriteLine("Be private");
        }

        public void callPrivate()
        {
            bePrivate();
        }
    }

    class Cat : Animal
    {
        public Cat()
        {
            this.Name = "Cat";
            this.Sound = "Meow";
        }
    }

    class Giraffe : Creature
    {
        public override void SetName(string name)
        {
            this.name = name;
        }

        public override string getName()
        {
            return this.name;
        }

        public override void setWeight(int weight)
        {
            this.weight = 3000;
        }

        public override int getWeight()
        {
            return weight;
        }
    }

    abstract class Creature
    {
        protected String name;
        protected int weight;
        protected string sound;

        public abstract void SetName(string name);
        public abstract string getName();

        public abstract void setWeight(int weight);
        public abstract int getWeight();
    
    }

    class Elephant : Creature, Living
    {

        public override void SetName(string name)
        {
            throw new NotImplementedException();
        }

        public override string getName()
        {
            throw new NotImplementedException();
        }

        public override void setWeight(int weight)
        {
            throw new NotImplementedException();
        }

        public override int getWeight()
        {
            throw new NotImplementedException();
        }

        public void SetName2(string name)
        {
            this.name = name;
        }

        public string getName2()
        {
            throw new NotImplementedException();
        }

        public void setWeight2(int weight)
        {
            throw new NotImplementedException();
        }

        public int getWeight2()
        {
            throw new NotImplementedException();
        }
    }

    interface Living
    {
        void SetName2(string name);
        string getName2();

        void setWeight2(int weight);
        int getWeight2();

    }
}
