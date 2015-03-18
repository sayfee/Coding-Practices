using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.Algorityms
{
    class Queue
    {
        string[] queueuArray;
        int queueSize;
        int front, rear, numberOfItems = 0;

        Queue(int size)
        {
            queueSize = size;
            queueuArray = new string[size]; 
        }

        private void displayTheStack()
        {
            Console.WriteLine("----------");

            for (int i = 0; i < queueSize; i++)
            {
                Console.WriteLine("| " + i + ".| " + queueuArray[i] + " |");
                Console.WriteLine("----------");
            }
        }

        void insert(string value)
        {
            if (numberOfItems >= queueSize)
            {
                Console.WriteLine("Array is full");
            }
            else
            {
                queueuArray[rear] = value;
                rear++;
                numberOfItems++;
                Console.WriteLine("Item " + value+ " is added");

            }
        }

        void insertPriority(string value)
        {
            int i = 0;
            if (numberOfItems == 0)
            {
                insert(value);
            }
            else
            {
                for (i = numberOfItems-1; i >= 0; i--)
                {
                    if (Convert.ToInt32(value) > Convert.ToInt32(queueuArray[i]))
                    {
                        queueuArray[i + 1] = queueuArray[i];
                    }
                    else
                        break;
                }

                queueuArray[i + 1] = value;
            }
        }

        void remove()
        {
            if (numberOfItems > 0)
            {
                Console.WriteLine("Item is removed : " + queueuArray[front]);
                queueuArray[front] = "-1";
                front++;
                numberOfItems--;
            }
            else
                Console.WriteLine("Queue is empty");
        }

        public static void Main1()
        {
            Queue q = new Queue(5);
            q.insertPriority("10");
            q.insertPriority("5");
            q.insertPriority("12");
            q.insertPriority("15");

            q.insertPriority("16");
            q.insertPriority("19");

            //q.remove();
            //q.remove();

            q.displayTheStack();

            Console.ReadKey();
        }

    }
}
