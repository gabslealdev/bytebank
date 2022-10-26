using bytebank.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank.CurentAccount
{
    public class Account: IComparable<Account>
    {
        public Holder Holder{ get; set; }
        public double Balance { get; private set; }
        public int NumberAccount { get; private set;}
        public double Overdraft { get; private set; }
        public Account(Holder holder)
        {
            Holder = holder;
            Balance = 0.0;
            GenerateNumberAccount();
            SetOverdraft();
        }
        private void GenerateNumberAccount()
        {
            Random random = new Random();
            NumberAccount = random.Next(100, 999);
        }
        private void SetOverdraft()
        {
            if (Holder.Salary > 0 && Holder.Salary <= 500.0)
            {
                Overdraft = Holder.Salary * 0.02;
            }
            else if (Holder.Salary > 500.0 && Holder.Salary <= 1500.0)
            {
                Overdraft = Holder.Salary * 0.05;
            }
            else if (Holder.Salary > 1500.0 && Holder.Salary <= 5000.0)
            {
                Overdraft = Holder.Salary * 0.15;
            }
            else
            {
                Overdraft = Holder.Salary * 0.25;
            }
        }

        public void deposit(double value)
        {
            Balance += value;
        }
        public bool withDraw(double value)
        {
            if (Overdraft > value && value > 0)
            {
                Balance -= value;
                return true;
            }
            else
            {
                return false;
            }

        }
        public void transfer(Account account, double value)
        {
            if (withDraw(value) == true)
            {
                account.deposit(value);
            }
            else
            {
                account.deposit(0.0);
            }
        }
        public override string ToString()
        {
            return "==========  DATA ACCOUNT  ============"
                + "\n\nNumber account:" + NumberAccount
                + "\nHolder: " + Holder.Name
                + "\nHolder Registry: " + Holder.Registry
                + "\nBalance: R$" + Balance.ToString("F2")
                + "\nOverdraft: R$" + Overdraft.ToString("F2") + 
                "\n";
        }

        public int CompareTo(Account? other)
        {
            if (other == null)
            {
                return 1;
            }
            else
            {
                return NumberAccount.CompareTo(other.NumberAccount);
            }
        }
    }
}
