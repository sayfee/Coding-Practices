using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.Algorityms
{
    class Palindrome
    {
        public static void Main1()
        {
            int readCount = Convert.ToInt32(Console.ReadLine());
            string[] strArr = new string[readCount];
            int count = 0;
            while(count < readCount)
            {
                strArr[count] = Console.ReadLine();
                count++;
            }


            foreach (string str in strArr)
            {              
                int r = IsPali(str);
                if(r != -1)
                    r = RemoveIfPali(str);

                Console.WriteLine(r);
            }
            Console.ReadKey();
             

        }

        public static int RemoveIfPali(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                string s = str.Remove(i, 1);
                if (IsPali(s) == -1)
                    return i;
            }

            return -1;
        }

        public static int  IsPali(string str)
        {
            for (int i = 0; i < str.Length/2; i++)
            {
                if (str[i] != str[str.Length - 1 - i])
                    return 0;
            }
             
                return -1;
        }

        class Inherit { }

        class In : Inherit {
            private In() { }
        }
    }
}
