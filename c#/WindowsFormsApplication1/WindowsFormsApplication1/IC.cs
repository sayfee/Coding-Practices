using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class IC
    {
    }

    public class OrderService
    {
        public OrderService(IOrderDatabase orderDB, Order ord)
        {
            orderDB.SaveOrder(ord);
        }

        public void AcceptOrder(Order ord)
        {
            new OrderDatabase().SaveOrder(ord);         
        }
    }

    public interface IOrderDatabase
    {
        void SaveOrder(Order or);
    }

    public class Order
    { }

    public class OrderDatabase : XMLOrderSaver
    {
        public override void  SaveOrder(Order ord)
        {
            Console.WriteLine("Order is saved");
            base.SaveOrder(ord);
        }
    }

    public class LoggerOrderDB : IOrderDatabase
    {

        public void SaveOrder(Order or)
        {
            Console.WriteLine("Order is logged");
            
        }
    }

    public class XMLOrderSaver : IOrderDatabase
    {
        public XMLOrderSaver()
        {
            Console.WriteLine("Order is xml");
        }

        public virtual void SaveOrder(Order or)
        {
            Console.WriteLine("Order is xml");
        }
    }

    public static class ServiceLocater 
    {
        public static IOrderDatabase OrderSaver { get; set; }

        public static IOrderDatabase GetOrderSaver(int cN)
        {
            if (cN == 1)
                return new OrderDatabase();
            else if (cN == 2)
                return new XMLOrderSaver();
            else
                return new LoggerOrderDB();

        }
    }
 
}
