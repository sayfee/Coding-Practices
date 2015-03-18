using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ProductServices
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WCFProductService)))
            {
                host.Open();
                Console.WriteLine("Server is open");
                Console.WriteLine("Press enter to close server");
                Console.ReadLine();

            }
        }
    }
}
