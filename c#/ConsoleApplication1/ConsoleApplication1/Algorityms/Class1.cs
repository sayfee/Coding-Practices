using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.Algorityms
{
    class Class1
    {
        int[] arrayOfNum;
        private int arrayLength;

        public int ArrayLength
        {
            get { return arrayLength; }
            set { arrayLength = value; }
        }

        public Class1(int arrayLength)
        {
            this.arrayLength = arrayLength;
            arrayOfNum = new int[arrayLength];
        } 

        void generateRandomNumber()
        {
            Random r = new Random();
            for (int i = 0; i < ArrayLength; i++)
            { 
                arrayOfNum[i] = r.Next(0, 50);
            }
        }

        void PrintArray()
        {
            Console.WriteLine("----------");

            for (int i = 0; i < ArrayLength; i++)
            {
                Console.WriteLine("| " + i + ".| " + getValueByIndex(i) + " |");
                Console.WriteLine("----------");
            }
        
        }

        int getValueByIndex(int index)
        {
            if (index <= ArrayLength)
                  return arrayOfNum[index];

            return -1;
        }

        bool doesTheValueContainInTheArray(int value)
        {
            string foundValue = "";
            bool isFound = false;
            for (int i = 0; i < ArrayLength; i++)
            {
                if (arrayOfNum[i] == value)
                {
                    isFound = true; foundValue += i + " ";
                }

            }
            if (isFound)
                Console.WriteLine(value + " was found following indexes : " + foundValue);
            else
                Console.WriteLine("Value was not found");

            return isFound;

        }

        void deleteIndex(int index)
        {
            for (int i = index; i < ArrayLength - 1; i++)
            {
                    arrayOfNum[i] = arrayOfNum[i + 1];
            }
            ArrayLength--;
        }

        void insertValue(int value)
        {
            ArrayLength++;
            arrayOfNum[ArrayLength-1] = value;
        }

        public static void Main1()
        {
            Class1 arrayStructure = new Class1(10);
            arrayStructure.generateRandomNumber();
            arrayStructure.PrintArray();

            Console.WriteLine("The value at 18 " + arrayStructure.getValueByIndex(8));
            arrayStructure.doesTheValueContainInTheArray(20);
            arrayStructure.deleteIndex(5);
            arrayStructure.PrintArray();

            arrayStructure.insertValue(50);
            arrayStructure.PrintArray();

            
            Console.ReadKey();
        
        }

        public static void Main2()
        {
            Class1 arrayStructure = new Class1(10);
            arrayStructure.generateRandomNumber();
            arrayStructure.PrintArray();

            arrayStructure.deleteIndex(9);
            arrayStructure.insertValue(10);

            arrayStructure.BubleSortDesc();
            arrayStructure.PrintArray();

            arrayStructure.BubleSortAsc();
            arrayStructure.PrintArray();

            arrayStructure.BinarySearch(10);

            Console.ReadKey();

        }

        void BubleSortDesc()
        {
            for (int i = 0; i < ArrayLength; i++)
            {
                for (int j = i; j < ArrayLength - 1; j++)
                {
                    if (arrayOfNum[j + 1] > arrayOfNum[j])
                    {
                        SwapValues(j);
                    }
                }
            }
        }

        private void SwapValues(int j)
        {
            int value = arrayOfNum[j];
            arrayOfNum[j] = arrayOfNum[j + 1];
            arrayOfNum[j + 1] = value;
        }

        void BubleSortAsc()
        {
            for (int i = ArrayLength -1 ; i > 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arrayOfNum[j + 1] < arrayOfNum[j])
                    {
                        SwapValues(j);
                    }
                }
            }
        }

        void BinarySearch(int value)
        {
            int lowIndex = 0;
            int highIndex = ArrayLength - 1;
            while (highIndex >= lowIndex)
            {
                int middleIndex = (highIndex + lowIndex)/2;
                if (value > arrayOfNum[middleIndex])
                {
                    lowIndex = middleIndex;
                }
                else if (value < arrayOfNum[middleIndex])
                {
                    highIndex = middleIndex;
                }
                else {

                    highIndex = lowIndex;
                    Console.WriteLine(value + " found on : " + middleIndex);
                }

            }
            
        }
    }
}
