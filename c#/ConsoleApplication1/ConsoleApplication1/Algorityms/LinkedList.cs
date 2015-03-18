using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.Algorityms
{
    class Link
    {
        public string BookName;
        public int SoldAmount;

        public Link next;

        public Link(string bookName, int soldAmount)
        {
            this.BookName = bookName;
            this.SoldAmount = soldAmount;
        }

        public void display()
        {
            Console.WriteLine(BookName + " is sold for : " + SoldAmount);
        }

        public override string ToString()
        {
            return BookName;
        }

        public static void Main1()
        {
            LinkList l = new LinkList();
            l.InsertFirstLink("Lord of the rings", 10);
            l.InsertFirstLink("Inception", 30);
            l.InsertFirstLink("Intersallat", 20);
            l.InsertFirstLink("Hobbit", 50);
            l.InsertFirstLink("ROME", 50);
            l.InsertFirstLink("Larry dabit", 50);

            l.display();
            l.removeFirst();

            Console.WriteLine("The value of the first link is " + l.fistLink);

            l.removeLink("Inception");

            l.display();

            Console.WriteLine("Found : " + l.Find("Hobb"));

            Console.ReadKey();
        }

    }

    class LinkList
    {
        public Link fistLink;

        public LinkList()
        {
            fistLink = null;
        }

        public bool isEmpty()
        {
            return fistLink == null;
        }

        public void InsertFirstLink(string bookName, int sold)
        {
            Link link = new Link(bookName, sold);
            link.next = fistLink;
            fistLink = link;
        }

        public void removeFirst()
        {
            Link linkRefereance = fistLink;
            if (!isEmpty())
            {
                fistLink = linkRefereance.next;
            }
            else
            {
                Console.WriteLine("Link List is empty");
            }
        }

        public Link removeLink(string bookName)
        {
            Link currentLink = fistLink;
            Link previousLink = fistLink;

            while (!currentLink.BookName.Contains(bookName))
            {
                if (currentLink.next == null)
                    return null;
                else
                {
                    previousLink = currentLink;
                    currentLink = currentLink.next;
                }                
            }

            if (currentLink == fistLink)
                fistLink = fistLink.next;
            else
            {
                Console.WriteLine("Found a match");
                Console.WriteLine("currentLink : " + currentLink);
                Console.WriteLine("previous link : " + previousLink);

                previousLink.next = currentLink.next;
                
            }

            return currentLink;
        }

        public Link Find(string bookName)
        {
            Link theLink = fistLink;
            while (!theLink.BookName.Contains(bookName))
            {
                if (theLink.next == null)
                    return null;
                else
                {
                    theLink = theLink.next;
                }   

            }

            return theLink;
        }

        public void display()
        { 
            Link theLink = fistLink;

            while (theLink.next != null)
            {
                theLink.display();
                Console.WriteLine("New Link : " + theLink.next);
                theLink = theLink.next;

            }
        }
    }
}
