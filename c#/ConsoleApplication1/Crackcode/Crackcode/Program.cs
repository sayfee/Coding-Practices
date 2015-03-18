using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crackcode
{
    class Program
    {

        static void Main(string[] args)
        {
            //string s = "abacsdfkasdfsadf";
            //string s1 = "abcdefgh";

            //if (isUniqeChars(s1))
            //    Console.WriteLine(s + " contains Unique chars");
            //else
            //    Console.WriteLine(s + " DOES NOT contains Unique chars");

            //string duplicateString1 = "aaabbbccc";
            ////  removeDuplicates(duplicateString1.ToCharArray());
            //duplicateString1 = removeDuplicates2(duplicateString1.ToCharArray());
            //Console.WriteLine(duplicateString1);

            Perm.main();
            Console.ReadKey();
        }

        private static bool isUniqeChars(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < str.Length; j++)
                {
                    if (i != j)
                    {
                        if (str[i] == str[j])
                            return false;

                    }
                }
            }

            return true;
        }

        private static void removeDuplicates(char[] str)
        {
            int tail = 1;
            for (int i = 0; i < str.Length; i++)
            {
                int j;
                for (j = 0; j < tail; ++j)
                {
                    if (str[i] == str[j])
                        break;
                }
                if (j == tail)
                {
                    str[tail] = str[i];
                    ++tail;
                }
            }

          //  str[tail] = 0;
        }

        private static string removeDuplicates2(char[] str)
        {
            string returnString = str[0].ToString();
            for (int i = 1; i < str.Length; i++)
            {
                bool flagDuplicate = false;
                for (int j = 0; j < returnString.Length; j++)
                {
                    if (str[i] == returnString[j])
                    {
                        flagDuplicate = true;
                        break;
                    }
                }

                if(!flagDuplicate)
                returnString = returnString + str[i];
            }

            return returnString;

        }
    }
}
