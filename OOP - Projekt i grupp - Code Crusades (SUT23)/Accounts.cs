using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    public class Accounts
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }

        public Accounts(string name, decimal balance, string currency)
        {
            Name = name;
            Balance = balance;
            Currency = currency;
        }
        public static void PrintAcc()
        {
            Console.WriteLine("\n\tDina konton & saldo:");

            foreach (var account in UserContext.CurrentUser.Accounts)
            {
                Console.WriteLine($"\n\t{account.Name}: {Math.Round(account.Balance, 2)} {account.Currency}");
            }
            Console.ReadKey();
        }
    }
}
