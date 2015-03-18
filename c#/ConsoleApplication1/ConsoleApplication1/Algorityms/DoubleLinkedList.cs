using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.Algorityms
{
    class DoubleLinkedList
    {
        Neighbor firstLink;
        Neighbor lastLink;

        public void InsertFirstPosition(string homeowner, string houseNumber)
        {
            Neighbor neigh = new Neighbor(homeowner, houseNumber);
            if (isEmpty())
                lastLink = neigh;
            else
                firstLink.previous = lastLink;

            neigh.next = firstLink;
            firstLink = neigh;
        }

        public void InsertLastPosition(string homeowner, string houseNumber)
        {
            Neighbor neigh = new Neighbor(homeowner, houseNumber);
            if (isEmpty())
                firstLink = neigh;
            else
            {
                lastLink.next = neigh;
            }

            lastLink = neigh;
        }

        public bool isEmpty()
        {
            return firstLink == null;
        }

        public static void Main2()
        {
            DoubleLinkedList theLinkedList = new DoubleLinkedList();
            theLinkedList.InsertFirstPosition("Petunna Kalam", "1");
            theLinkedList.InsertLastPosition("last postiion", "4");
            theLinkedList.InsertFirstPosition("KEtunep Salm", "2");
            theLinkedList.InsertFirstPosition("detunit laam", "3");

            theLinkedList.display();

            Console.ReadKey();
        }

        public void display()
        {
            Neighbor theNeighbor = firstLink;
            while (theNeighbor != null)
            {
                theNeighbor.Display();
                theNeighbor = theNeighbor.next;
            }
        }


    }

    public class Neighbor
    {
        string homeowner;
        string houseNumber;

        public Neighbor next;
        public Neighbor previous;

        public Neighbor(string homeowner, string houseNu)
        {
            this.homeowner = homeowner;
            this.houseNumber = houseNu;
        }

        public override string ToString()
        {
            return homeowner;
        }

        public void Display()
        {
            Console.WriteLine("House owner : " + homeowner + " house no: " + houseNumber);

        }
    }
}
