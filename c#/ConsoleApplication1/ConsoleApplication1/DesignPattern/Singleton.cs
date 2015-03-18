using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1.Singleton
{
    class Singleton
    {
        private static Singleton fisrtInstance = null;

        static String[] scrabbleLetters = {"a", "a", "a", "a", "a", "a", "a", "a", "a",
            "b", "b", "c", "c", "d", "d", "d", "d", "e", "e", "e", "e", "e", 
            "e", "e", "e", "e", "e", "e", "e", "f", "f", "g", "g", "g", "h", 
            "h", "i", "i", "i", "i", "i", "i", "i", "i", "i", "j", "k", "l", 
            "l", "l", "l", "m", "m", "n", "n", "n", "n", "n", "n", "o", "o", 
            "o", "o", "o", "o", "o", "o", "p", "p", "q", "r", "r", "r", "r", 
            "r", "r", "s", "s", "s", "s", "t", "t", "t", "t", "t", "t", "u", 
            "u", "u", "u", "v", "v", "w", "w", "x", "y", "y", "z",};  


        private LinkedList<string> letterList = new LinkedList<string>(scrabbleLetters.ToList<string>());

        static bool firstThread = true;

        private static object Lock = new object();
        private Singleton() { }
         
        public static Singleton getInstance()
        {
            if (firstThread)
            {
                firstThread = false;
                Thread.Sleep(1000);
            }

            lock (Lock)
            {
                //lazy instattion 
                if (fisrtInstance == null)
                {
                    fisrtInstance = new Singleton();
                }
            }
            return fisrtInstance;
        }

        public LinkedList<string> getLetterList()
        {
            return fisrtInstance.letterList;
        }

        public LinkedList<string> getTiles(int howManyTiles)
        {
            LinkedList<string> tilestoSend = new LinkedList<string>();
            for (int i = 0; i < howManyTiles; i++)
            {
                string letter = fisrtInstance.letterList.First.Value;
                tilestoSend.AddFirst(letter);
                fisrtInstance.letterList.RemoveFirst();
            }

            return tilestoSend;
        }
    }

    class ScrabbleTest
    {
        public static void Main2()
        {
            Singleton newInstance = Singleton.getInstance();
            Console.WriteLine("1st instance id " + newInstance.GetHashCode());
            Console.WriteLine("Items in the bag : " + newInstance.getLetterList().Count);
            LinkedList<string> playerOne = newInstance.getTiles(7);
            Console.WriteLine("Player 1 took : " + playerOne.Count);
            Console.WriteLine("Items in the bag : " + newInstance.getLetterList().Count);

            Singleton instanceTwo = Singleton.getInstance();
            Console.WriteLine("2nd instance id " + instanceTwo.GetHashCode());
            LinkedList<string> playerTwo = instanceTwo.getTiles(7);
            Console.WriteLine("Player 2 took : " + playerOne.Count);

            Console.WriteLine("Items in the bag : " + newInstance.getLetterList().Count);



            Console.ReadKey();
        }
    }

    class ScrabbleTestThread
    {
        public static void Main1()
        {

            GetTheTiles getTiles = new GetTheTiles();
            Thread th = new Thread(new ThreadStart(getTiles.run));
            th.Start();

            GetTheTiles getTiles2 = new GetTheTiles();
            Thread th2 = new Thread(new ThreadStart(getTiles2.run));
            th2.Start();


            Console.ReadKey();
        }
    }

    class GetTheTiles
    {
        public void run()
        {
            Singleton newInstance = Singleton.getInstance();
            Console.WriteLine("1st instance id " + newInstance.GetHashCode());
            LinkedList<string> playerOne = newInstance.getTiles(7);
            Console.WriteLine("Player 1 took : " + playerOne.Count);
            Console.WriteLine("Items in the bag : " + newInstance.getLetterList().Count);

        }
    }
}
