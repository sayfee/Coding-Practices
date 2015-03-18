using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Question
    {
        static void Main1()
        { 
            string[][] jaggedArray = new string[3][];

            jaggedArray[0] = new string[3];
            jaggedArray[1] = new string[1];
            jaggedArray[2] = new string[2];

            jaggedArray[0][0] = "Bachelors";
            jaggedArray[0][1] = "Masters";
            jaggedArray[0][2] = "Doctarete";
            
            jaggedArray[1][0] = "Bachelors";

            jaggedArray[2][0] = "Bachelors";
            jaggedArray[2][1] = "Bachelors";

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.WriteLine(jaggedArray[i][j]);
                }
                Console.WriteLine();

            }

            Console.ReadKey();
        }

        public static void Main2()
        {
            Console.WriteLine("Please enter a number");
            int i = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Result " + Factorial(i).ToString());

            Console.WriteLine("Result " + FactorialRec(i).ToString());

            Console.ReadKey();
        }

        public static double Factorial(int number)
        {
            if (number == 0)
                return 1;

            double factorial = 1;

            for (int i = number; i >= 1; i--)
            {
                factorial = factorial * i;
            }

            return factorial;
        }

        public static double FactorialRec(int number)
        {
            if (number == 1)
                return 1;

            return number * FactorialRec(number - 1);

        }

        public static void Main3()
        {
            Console.WriteLine("Please enter a path");
            string path = Console.ReadLine();

            FindFiles(path);

            Console.ReadKey();
        }

        public static void FindFiles(string path)
        {
            Console.WriteLine("Files under " + path);

            foreach (string fileName in Directory.GetFiles(path))
            {
                Console.WriteLine(fileName);
            }

            foreach (string directory in Directory.GetDirectories(path))
            {
                FindFiles(directory);
            }

            Console.WriteLine("=========");
        }

        public static void Main6()
        {
            CorparoteCustomer cc = new CorparoteCustomer();
            //Console.WriteLine(cc.ID);

            SavingCustomer sc = new SavingCustomer();
           // Console.WriteLine(sc.ID);
            Check<int> o = new Check<int>();
            bool b = o.Compare(1, 2);

            Check<string> o1 = new Check<string>();

            PointToAdFunction pa = Add;
            Stopwatch objWatch = new Stopwatch();

            for (int i = 0; i < 10; i++)
            {
                objWatch.Reset();
                objWatch.Start();
                for (int j = 0; j < 1000; j++)
                    Console.WriteLine(pa.Invoke(i, j));

                objWatch.Stop();
                Console.WriteLine("Elapsed time " + objWatch.ElapsedTicks);
            }
            Console.ReadKey();
        }

        delegate int PointToAdFunction(int a1, int a2);

        static int Add(int a, int b)
        {
            return a + b;
        }

    }

    public class Check<AnyType>
    {
    
        public bool Compare(int i, int j)
        {
            if(i==j) return true;
            else return false;
        }

       

    }

    public abstract class Customer
    {
        public abstract void Print();

        public Customer()
        {
            Print();
        }

        private Guid _id;

        public Guid ID
        {
            get
            {
                return this._id;
            }
        }
    }

    public class CorparoteCustomer : Customer{
        public CorparoteCustomer()
        {
            
        }
        
        public override void Print()
        {
            Console.WriteLine("CorparoteCustomer class Print method invoked");
        }
    }

    public class SavingCustomer : Customer{
        public SavingCustomer(){}

        public override void Print()
        {
            Console.WriteLine("SavingCustomer class Print method invoked");
        }
    }


    public class FullTimeEmloyee
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
