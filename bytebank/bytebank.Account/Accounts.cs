using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank.CurentAccount
{
    public class Accounts
    {
        public List<Account> accounts = new List<Account>();

        public Accounts()
        {
        }
        public void Show()
        {
            foreach (Account account in accounts)
            {
                Console.WriteLine(account);
            }
        }
    }
}
