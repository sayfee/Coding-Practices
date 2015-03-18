using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.DesignPattern
{
    class WhiteBoard
    {
        public static void Main1()
        {
            //int a = 1;
            //int b = 2;

            //Console.WriteLine("1 -> a :" + a + " b:" + b);

            //a = a + b;
            //b = a - b; //  b = b - (a + b);
            //a = a - b;

            //Console.WriteLine("2 -> a :" + a + " b:" + b);
            //FizzBuzz();
            //ReverseTheString();
           // Fibonnaci();
            RepeatitiveChars();
            Console.ReadKey();
        }

        static void FizzBuzz()
        {
            for (int i = 1; i < 50; i++)
            {
                if (i % 15 == 0)
                    Console.WriteLine("For " + i + " answer is: FIZZBUZZ");
                if (i % 3 == 0)
                    Console.WriteLine("For " + i + " answer is: FIZZ");
                else if (i % 5 == 0)
                    Console.WriteLine("For " + i + " answer is: BUZZ");
                else
                    Console.WriteLine("For " + i + " answer is: "+ i);
            }
        }

        static void ReverseTheString()
        {
            string s = "Merhaba nasilsinsin dostum";
            string sR = string.Empty;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                sR += s[i];
            }

            Console.WriteLine(sR);
        }

        /// <summary>
        /// F(n) = F(n-1) + F(n-2)
        /// 
        /// </summary>
        static void Fibonnaci()
        {
            int Fib = 10;
            for (int i = 1; i < Fib; i++)
            {
                Console.WriteLine(i + " fib  is " + FibRecurse(i));
            }
        }

        static int FibRecurse(int num)
        {
            if (num <= 2)
            {
                return 1;
            }
            return FibRecurse(num - 1) + FibRecurse(num - 2);
        }

        static void RepeatitiveChars()
        {
            string St = "Kimderdiki";
            char s = new char();
            for (int i = 0; i < St.Length; i++)
            {
                if (i != St.IndexOf(St[i]))
                {
                    s = St[i];
                    break;
                }
            }

            Console.WriteLine("First repetitive char is " + s);
        }
    }
}
