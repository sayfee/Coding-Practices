using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    //strategy pattreb
    class Employees
    {
        private bool bonus = false;
        private double salary = 0.0;
        private double bonusAmount = 0.0;

        public Employees(bool bonus, double salary, double bonusAmount)
        {
            this.bonus = bonus;
            this.salary = salary;
            this.bonusAmount = bonusAmount;
        }

        public Employees(bool bonus, double salary)
        {
            this.bonus = bonus;
            this.salary = salary;
        }

        public double getSalary()
        {
            if (bonus)
            {
                return salary + (bonusAmount);
            }

            return salary;
        }

        public void setSalary(double salary)
        {
            this.salary = salary;
        }
    }

    public class Employee
    {
        protected double salary = 0.0;
        protected Pay payType = new NoBonus();

        public Employee()
        {
        }

        public Employee(double salary)
        {
            this.salary = salary;
        }

        public Employee(double salary, Pay payType)
        {
            this.salary = salary;
            this.payType = payType;
        }

        public void BonusOption(Pay newPayType)
        {
            this.payType = newPayType;
        }

        public double getPay()
        {
            return payType.getPay(this.salary);
        }
    }

    public interface Pay
    {
        double getPay(double salary);
    }

    class GetsBonus : Pay
    {
        public double getPay(double salary)
        {
            return salary + (salary * .15);
        }
    }

    class NoBonus : Pay
    {
        public double getPay(double salary)
        {
            return salary;
        }
    }

    class Bonus20 : Pay
    {
        public double getPay(double salary)
        {
            return salary + (salary * .2);
        }
    }



    public class Salesman : Employee
    {
        public Salesman(double salary)
            : base(salary)
        {
        }

        Salesman(double salary, Pay payType)
            : base(salary, payType)
        {
            base.BonusOption(payType);
        }
    }

   public class Secretary : Employee
    {
        public Secretary(double salary)
            : base(salary)
        {
        }


        public Secretary(double salary, Pay payType)
            : base(salary, payType)
        {
            base.BonusOption(payType);
        }
    }
}
