using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;

namespace MSMQReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic v = "Hello World!";
            v = 10;
            Int32 a = new Int32();
            //Console.WriteLine("Latest Message");

            //MessageQueue myQue;
            
            //string directory = @".\Private$\MyQue";
            //myQue = new MessageQueue(directory);

            //Message mes = myQue.Receive();
            //mes.Formatter = new BinaryMessageFormatter();

            //Console.WriteLine(mes.Body);
            Console.ReadKey();
        }


    }

    class A1 { 
        static int b = 1; 
        public static void main(String[] args)
       
        { Console.WriteLine("b is " + b); }

    
    }

     class A { 
         public static void main(String [] args) 
         {  A a = new B(); }}
 
     class B : A {}

     interface Ai
     {
         void a();
         void b();
     }

    abstract class abs : Ai
    {
        public void a()
        {
            throw new NotImplementedException();
        }

        public void b()
        {
            throw new NotImplementedException();
        }
    }
}
