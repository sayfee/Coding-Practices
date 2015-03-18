using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;

namespace MSMQConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string messageToBeSend = "Hello, how are you?";

            MessageQueue myQueue;
            string directory = @".\Private$\MyQue";
            if (MessageQueue.Exists(directory))
                myQueue = new MessageQueue(directory);
            else
                myQueue = MessageQueue.Create(directory);

            Message mes = new Message();

            mes.Formatter = new BinaryMessageFormatter();
            mes.Body = messageToBeSend;
            mes.Label = "New Message";

            mes.Priority = MessagePriority.VeryHigh;

            myQueue.Send(mes);
            Console.WriteLine("Message Sent");
            Console.ReadKey();
        }
    }
}
