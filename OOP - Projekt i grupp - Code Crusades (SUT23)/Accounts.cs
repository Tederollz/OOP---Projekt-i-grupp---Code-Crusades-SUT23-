using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class Accounts
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public Accounts(string name, decimal balance, decimal interestRate = 0)
        {
            Name = name;
            Balance = balance;
        }
        
        public static Accounts CreateAccount(string name, decimal insert)
        {
            name = "CheckingAccount";
            return new Accounts(name, insert);
        }
        public static Accounts CreateSavingsAccount(string name, decimal insert)
        {
            name = "SavingsAccount";

            return new Accounts(name, insert);
        }
    }
}
