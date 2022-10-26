using bytebank.CurentAccount;
using bytebank.bytebank.Exception;
using bytebank.Client;

namespace bytebank.Management
{
    public class Management
    {
        Accounts accountList = new Accounts();
        
        public void AccountManager()
        {
            try
            {
                char choice = '0';
                while (choice != '6')
                {
                    Console.Clear();
                    Console.WriteLine("===================================================");
                    Console.WriteLine("============= BYTEBANK MANAGER ACCOUNT ============");
                    Console.WriteLine("===================================================");
                    Console.WriteLine("======= 1 - Open a new account.        =============");
                    Console.WriteLine("======= 2 - List all accounts.         =============");
                    Console.WriteLine("======= 3 - Close an account.          =============");
                    Console.WriteLine("======= 4 - Order an account.          =============");
                    Console.WriteLine("======= 5 - Search an account          =============");
                    Console.WriteLine("======= 6 - Exit.                      =============");
                    Console.WriteLine("\n\n");
                    Console.Write("Select an option ");
                    try
                    {
                        choice = Console.ReadLine()[0];
                    }
                    catch (Exception exception)
                    {

                        throw new BytebankException(exception.Message);
                    }
                    switch (choice)
                    {
                        case '1':
                            RegisterAccount();
                            break;
                        case '2':
                            ListAccount();
                            break;
                        case '3':
                            RemoveAccount();
                            break;
                        case '4':
                            OrderAccount();
                            break;
                        case '5':
                            SearchAccount();
                            break;
                        default:
                            Console.WriteLine("Solução não implementada");
                            break;
                    }
                }
            }
            catch (BytebankException exception)
            {

                Console.WriteLine($"{exception.Message}");
            }
        }

        private void SearchAccount()
        {
            Console.Clear();
            Console.WriteLine("===================================================");
            Console.WriteLine("================== SEARCH ACCOUNT =================");
            Console.WriteLine("===================================================");
            Console.WriteLine("======= 1 - Search by Number Account.  ============");
            Console.WriteLine("======= 2 - Search by Registry Holder. ============");
            Console.WriteLine("\n");
            Console.Write("Select an option ");

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.Write("Enter with account number: ");
                    int number = int.Parse(Console.ReadLine());
                    Account QnAccount = QueryNumber(number);
                    Console.WriteLine(QnAccount.ToString());
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Enter with holder registry: ");
                    string registry = Console.ReadLine();
                    Account QrAccount = QueryRegistry(registry);
                    Console.WriteLine(QrAccount.ToString());
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    AccountManager();
                    break;
            }

        }

        private Account QueryNumber(int? numberAccount)
        {
            return accountList.accounts.Where(account => account.NumberAccount == numberAccount).FirstOrDefault();
        }

        private Account QueryRegistry(string? registry)
        {
            return accountList.accounts.Where(account => account.Holder.Registry == registry).FirstOrDefault();
        }

        private void OrderAccount()
        {
            Console.Clear();
            Console.WriteLine("===================================================");
            Console.WriteLine("==================== ORDER LIST ===================");
            Console.WriteLine("===================================================");
            Console.WriteLine("\n");


            accountList.accounts.Sort();
            accountList.Show();
            Console.WriteLine("... List has been orderned ...");
            Console.ReadLine();
        }

        private void RemoveAccount()
        {
            Console.Clear();
            Console.WriteLine("===================================================");
            Console.WriteLine("=================== REMOVE ACCOUNT ==================");
            Console.WriteLine("===================================================");
            Console.WriteLine("\n");
            Console.WriteLine("Number account to remove?");
            int numberAccount = int.Parse(Console.ReadLine());
            Account account = null;
            foreach (Account item in accountList.accounts)
            {
                if (item.NumberAccount.Equals(numberAccount))
                {
                    account = item;
                }
            }
            if (account != null)
            {
                accountList.accounts.Remove(account);
                Console.WriteLine("  ... Account hass been removed, thank you! ... ");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Account not found, verify number account and try again");
                Console.ReadLine();
            }
        }

        private void ListAccount()
        {
            Console.Clear();
            Console.WriteLine("===================================================");
            Console.WriteLine("=================== LIST ACCOUNT ==================");
            Console.WriteLine("===================================================");
            Console.WriteLine("\n");
            if (accountList.accounts.Count <= 0)
            {
                Console.WriteLine("List is empty!");
            }
            accountList.Show();
            Console.WriteLine("\n\n");
            Console.ReadLine();
        }

        private void RegisterAccount()
        {
            Console.Clear();
            Console.WriteLine("===================================================");
            Console.WriteLine("============= BYTEBANK MANAGER ACCOUNT ============");
            Console.WriteLine("===================================================");
            Console.WriteLine("\n\n");
            Console.WriteLine("============ enter the holder's data ==============");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Registry: ");
            string registry = Console.ReadLine();

            Console.Write("Monthly income: ");
            double salary = double.Parse(Console.ReadLine());
            Console.WriteLine("\n\n");

            Holder holder = new Holder(name, registry);
            holder.Salary = salary;
            Console.WriteLine($"Very well {holder.Name}, your account is already!!!");
            Account account = new Account(holder);
            accountList.accounts.Add(account);
            Console.ReadLine();
        }

    }
}