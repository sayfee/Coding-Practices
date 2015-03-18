using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Order ord = new Order();
            //XMLOrderSaver xml = new XMLOrderSaver();
            //OrderDatabase ob = new OrderDatabase();
            //LoggerOrderDB lb = new LoggerOrderDB();
            new OrderService(ServiceLocater.GetOrderSaver(1), ord);
            //new OrderService(ob, ord);
            //new OrderService(lb, ord);
        }
    }
}
