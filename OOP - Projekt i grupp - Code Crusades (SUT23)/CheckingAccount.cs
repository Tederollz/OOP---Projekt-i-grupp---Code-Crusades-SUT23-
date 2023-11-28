using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class CheckingAccount : Accounts
    {

        public CheckingAccount(string name, decimal balance) : base(name, balance)
        {

        }
        public static Accounts CreateAccount(string name, decimal insert)
        {
            name = "Checking Account";
            return new Accounts(name, insert);
        }
    }
}
