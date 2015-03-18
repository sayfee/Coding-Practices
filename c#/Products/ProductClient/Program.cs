using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ProductInterfaces;

namespace ProductClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IWCFProductService> channelFactory = new ChannelFactory<IWCFProductService>(); 

            IWCFProductService proxy = channelFactory.CreateChannel();

            List<string> products = proxy.ListProducts();
            foreach (var p in products)
            {
                Console.WriteLine(p);
            }
        }
    }
}
