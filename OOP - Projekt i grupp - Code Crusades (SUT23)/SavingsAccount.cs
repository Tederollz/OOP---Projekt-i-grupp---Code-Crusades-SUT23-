using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class SavingsAccount : Accounts
    {
        public decimal InterestRate { get; set; }
        public SavingsAccount(decimal interestRate, string name, decimal balance) : base (name, balance)
        {

            InterestRate = interestRate;

        }
        public static Accounts CreateSavingsAccount(string name, decimal insert)
        {
            name = "Savings Account";

            return new Accounts(name, insert);
        }
    }
}
