using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using test;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class CheckingAccount : Accounts
    {
        
        public CheckingAccount(string name, decimal balance) : base(name, balance)
        {

        }
        public static void CreateAccount()
        {
            decimal insert = 10000;
            string name = "Annas Bakkonto";
            UserContext.CurrentUser.Accounts.Add(new CheckingAccount(name, insert));
        }
    }
}
