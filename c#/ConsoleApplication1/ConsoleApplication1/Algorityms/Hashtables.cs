using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.Algorityms
{
    class Hashtables
    {
        String[] theArray;
        int arraySize;
        int itemsInArray = 0;

        public static void Main2()
        {
            Hashtables theHash = new Hashtables(31);
            string[] elementsToAdd = { "1", "5", "17", "21", "26" };
            String[] elementsToAdd2 = { "100", "510", "170", "214", "268", "398",
	                "235", "802", "900", "723", "699", "1", "16", "999", "890",
	                "725", "998", "978", "988", "990", "989", "984", "320", "321",
	                "400", "415", "450", "50", "660", "624" };

            String[] elementsToAdd3 = { "30", "10", "70", "14", "68", "98",
	                "235", "802", "900", "73", "699", "1", "16", "999", "890",
	                "725", "998", "978", "988", "990", "989", "984", "320", "321",
	                "400", "415", "450", "50", "660", "624" };
           // theHash.hashFunction1(elementsToAdd, theHash.theArray);

            theHash.hashFunction2(elementsToAdd3, theHash.theArray);

            //theHash.findKey("695");

            theHash.displayTheStack();

            Console.ReadKey();
        }

        public void hashFunction1(string[] stringsForArray, string[] theArray)
        {
            for (int n = 0; n < stringsForArray.Length; n++)
            {
                string newElementVal = stringsForArray[n];
                theArray[Int32.Parse(newElementVal)] = newElementVal;
            }
        }

        public void hashFunction2(string[] stringsForArray, string[] theArray)
        {
            for (int n = 0; n < stringsForArray.Length; n++)
            {
                string newElementVal = stringsForArray[n];
                int arrayIndex= Int32.Parse(newElementVal)%29;
                Console.WriteLine("Modules Index = " + arrayIndex + " for value"
                    + newElementVal);

                while(!string.IsNullOrEmpty(theArray[arrayIndex]))
                {
                    ++arrayIndex;
                    Console.WriteLine("Collision Try " + arrayIndex + " Instead");
                    arrayIndex %= arraySize;
                }

                theArray[arrayIndex] = newElementVal;
            }
        }

        public String findKey(string key)
        {
            int arrayIndexHasd = Int32.Parse(key) % 29;

            while (!String.IsNullOrEmpty(theArray[arrayIndexHasd]))
            {
                if (theArray[arrayIndexHasd] == key)
                {
                    Console.WriteLine(key + " was found in Index " + arrayIndexHasd);
                    return theArray[arrayIndexHasd];
                }

                ++arrayIndexHasd;

                arrayIndexHasd %= arraySize;
            }

            return null;
        }

        Hashtables(int size)
        {
            arraySize = size;
            theArray = new string[size];
        }

        public void displayTheStack()
        {
            int increment = 0;
            for (int m = 0; m < 3; m++)
            {
                increment += 10;

                for (int n = 0; n < 71; n++)
                    Console.Write("-");

                Console.WriteLine();

                for (int n = increment - 10; n < increment; n++)
                {
                    Console.Write("| " + n + " ");
                }

                Console.WriteLine("|");

                for (int n = 0; n < 71; n++)
                {
                    Console.Write("-");
                }

                Console.WriteLine();

                for (int n = increment - 10; n < increment; n++)
                {
                    if ( String.IsNullOrEmpty(theArray[n]) || 
                        theArray[n].Equals("-1"))
                        Console.Write("|    ");
                    else
                        Console.Write("| " + theArray[n] + " ");
                }

                Console.WriteLine("|");

                for (int n = 0; n < 71; n++)
                {
                    Console.Write("-");
                }

                Console.WriteLine();

            }
        }
    }
}
