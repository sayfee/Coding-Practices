using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.Algorityms
{
    class Stacks
    {
        private string[] stackArray;

        private int stackSize;

        private int topOfStack = -1;

        Stacks(int size)
        {
            stackSize = size;
            stackArray = new string[size];
            stackArray.SetValue("-1", 0);
        }

        public void Push(string input)
        {
            if (topOfStack + 1 < stackSize)
            {
                topOfStack++;
                stackArray[topOfStack] = input;
            }
            else
            {
                Console.WriteLine("Stack is full");
            }

            displayTheStack();
            Console.WriteLine(input + " added to stack");
        }

        public void PushMultiple(string multipleValues)
        {
            foreach (string s in multipleValues.Split(' '))
            {
                Push(s);
            }
        }

        public string Pop()
        {
            if (topOfStack >= 0)
            {

                Console.WriteLine(stackArray[topOfStack] + " is removed from the stack");

                stackArray[topOfStack] = "-1";
                return stackArray[topOfStack--];
            }
            else
            {
                Console.WriteLine("Nothing in the stack");
                return "-1";
            }
        }

        public void PopAll()
        {
            while (topOfStack >= 0)
            {
                Pop();
            }

            displayTheStack();

        }

        public string Peek()
        {
            Console.WriteLine("Top of the stack is " + stackArray[topOfStack]);
            return stackArray[topOfStack];
        }

        private void displayTheStack()
        {
            Console.WriteLine("----------");

            for (int i = 0; i < stackSize; i++)
            {
                Console.WriteLine("| " + i + ".| " + stackArray[i] + " |");
                Console.WriteLine("----------");
            }
        }


        public static void Main1()
        {
            Stacks st = new Stacks(10);
            st.Push("merhaba");
            st.Push("10");

            st.Peek();
            st.Pop();
            st.displayTheStack();

            st.PushMultiple("12 10 14 18 67");

            st.PopAll();

            Console.ReadKey();

        }

    }
}
