using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConditinalCommandPattern
{
    public class Customer
    {
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private bool man;

        public bool Man
        {
            get { return man; }
            set { man = value; }
        }
        private double bill;

        public double Bill
        {
            get { return bill; }
            set { bill = value; }
        }

        public Customer(int age, bool man, double bill)
        {
            this.age = age;
            this.man = man;
            this.bill = bill;
        }

        public void returnFinalBill()
        {
            double percentageOff = 0.0;

            if (age > 60)
            {
                percentageOff += .05;
            }

            if (!man)
                percentageOff += .05;

            Console.WriteLine("Bill Amount: $" + (bill - bill * percentageOff));
        }


        //public static void Main()
        //{
        //    Customer customer1 = new Customer(62, true, 12);
        //    customer1.returnFinalBill();

        //    Console.ReadKey();
        //}
    }

    public class CustomerGroup
    {
        List<BillPayer> customers;
        public CustomerGroup()
        {
            customers = new List<BillPayer>();
        }

        public void add(BillPayer newPayer)
        {
            customers.Add(newPayer);
        }

        public BillPayer get(int customerIndex)
        {
            return customers[customerIndex];
        }
    }

    public class UseCashRegister
    {
        public static void Main1()
        {
            BillPayer sallyMay = CustomerTypePicker.getWomanOver60();
            Waiter theWaiter = new Waiter(sallyMay);

            CashRegister calculateBill = new CashRegister(theWaiter);
            calculateBill.returnFinalbill(10);

            BillPayer paul = CustomerTypePicker.getManUnder60();
            theWaiter = new Waiter(paul); 
            calculateBill = new CashRegister(theWaiter);
            calculateBill.returnFinalbill(23);

            BillPayer maulo = CustomerTypePicker.getManOver60();
            theWaiter = new Waiter(maulo);
            calculateBill = new CashRegister(theWaiter);

            calculateBill.returnFinalbill(23);

            CustomerGroup custGroup = new CustomerGroup();
            custGroup.add(CustomerTypePicker.getManOver60());
            custGroup.get(0).calculateBill(12);

            Console.ReadKey();
        }
    }

    public interface BillPayer
    {
        void calculateBill(double amountDue);
    }

    public interface Command
    {
        void executeCalculationBill(double amountDue);

    }

    public class WomanOver60 : BillPayer
    {
        public void calculateBill(double amountDue)
        {
            Console.WriteLine("Bill Amount for Woman Over 60: $"
                + ( amountDue - (amountDue * .1)));
        }
    }

    public class ManOver60 : BillPayer
    {
        public void calculateBill(double amountDue)
        {
            Console.WriteLine("Bill Amount for Man Over 60: $"
                + (amountDue - (amountDue * .05)));
        }
    }

    public class ManUnder60 : BillPayer
    {
        public void calculateBill(double amountDue)
        {
            Console.WriteLine("Bill Amount for MAn Under 60: $"
                + amountDue);
        }
    }

    public class Waiter : Command
    {
        BillPayer thePayer;

        public Waiter(BillPayer thePayer)
        {
            this.thePayer = thePayer;
        }

        public void executeCalculationBill(double amountDue)
        {
            thePayer.calculateBill(amountDue);

        }
    }

    public class CashRegister
    {
        Command theCommand;
        public CashRegister(Command theCommand)
        {
            this.theCommand = theCommand;
        }

        public void returnFinalbill(double amountDue)
        {
            theCommand.executeCalculationBill(amountDue);
        }
    
    }

    public class CustomerTypePicker
    {
        public static BillPayer getWomanOver60()
        {
            return new WomanOver60();
        }

        public static BillPayer getManOver60()
        {
            return new ManOver60();
        }

        public static BillPayer getManUnder60()
        {
            return new ManUnder60();
        }
    
    }

}
