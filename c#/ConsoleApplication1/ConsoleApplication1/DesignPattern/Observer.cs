using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1.DesignPattern
{
    class GrabStock
    {
        public static void Main1()
        {
            StockGrabber sg = new StockGrabber();
            StockObserver so = new StockObserver(sg);
            sg.SetApplePrice(10);
            sg.SetGooglePrice(20);
            sg.SetIBMPrice(30);

            so.printThePrices();

            GetTheStock gs = new GetTheStock(sg, 1, "IBM", 10);
            GetTheStock gs2 = new GetTheStock(sg, 1, "APP", 10);
            GetTheStock gs3 = new GetTheStock(sg, 1, "GOG", 10);

            Thread newThread = new Thread(new ThreadStart(gs.run));
            newThread.Start();

            newThread = new Thread(new ThreadStart(gs2.run));
            newThread.Start();

            newThread = new Thread(new ThreadStart(gs3.run));
            newThread.Start();

            Console.ReadKey();
        }
    }

    interface Observer
    {
        void update(double ibmPrice, double applePrice, double googlePrice);
    }

    interface Subject
    {
        void register(Observer o);
        void unregister(Observer o);
        void notifyObserver();
    }

    class StockGrabber : Subject
    {
        private List<Observer> observerList;
        private double ibmPrice, applePrice, googlePrice;

        public StockGrabber()
        {
            observerList = new List<Observer>();
        }

        public void register(Observer o)
        {
            observerList.Add(o);
        }

        public void unregister(Observer o)
        {
            int obsIndex = observerList.IndexOf(o);
            Console.WriteLine("Observer "+ obsIndex + 1 + "has been deleted ");
            observerList.Remove(o);
        }

        public void notifyObserver()
        {
            foreach (Observer o in observerList)
            {
                o.update(ibmPrice, applePrice, googlePrice);
            }
        }

        public void SetIBMPrice(double newPrice)
        {
            this.ibmPrice = newPrice;
            notifyObserver();
        }

        public void SetGooglePrice(double newPrice)
        {
            this.googlePrice = newPrice;
            notifyObserver();
        }

        public void SetApplePrice(double newPrice)
        {
            this.applePrice = newPrice;
            notifyObserver();
        }
    }

    class StockObserver : Observer
    {
        private double ibmPrice, applePrice, googlePrice;

        private static int observerIDTracker = 0;

        private int observerId;

        private Subject stockGrabber;

        public StockObserver(Subject stockGrabber)
        {
            this.stockGrabber = stockGrabber;
            this.observerId = ++observerIDTracker;
            Console.WriteLine("New observer Id : " + observerId);

            stockGrabber.register(this);
        }

        public void update(double ibmPrice, double applePrice, double googlePrice)
        {
            this.ibmPrice = ibmPrice;
            this.applePrice = applePrice;
            this.googlePrice = googlePrice;
            //printThePrices();
        }

        public void printThePrices()
        {
            Console.WriteLine("Prices fro stocks are : Apple: " + applePrice + " Google : " + googlePrice + " ibm : " + ibmPrice);
        }
    }

    class GetTheStock
    {
        private string stock;
        private double price;

        private Subject stockGrabber;
        public GetTheStock(Subject stockGrabber, int newStartTime, string newStock, double newPrice)
        {
            this.stockGrabber = stockGrabber;
            this.stock = newStock;
            this.price = newPrice;
        }

        public void run()
        {
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(2000);

                Random r = new Random();
                double randNum = r.Next(-3, 3) * 0.1;

                price = price + randNum;

                if (stock == "IBM")
                    ((StockGrabber)stockGrabber).SetIBMPrice(price);
                if (stock == "APP")
                    ((StockGrabber)stockGrabber).SetApplePrice(price);
                if (stock == "GOG")
                    ((StockGrabber)stockGrabber).SetGooglePrice(price);

                printThePrices();
                Console.WriteLine();
            }
        }


        public void printThePrices()
        {
            Console.WriteLine("Prices for " + stock + " is: " + price);
        }
    }
}
