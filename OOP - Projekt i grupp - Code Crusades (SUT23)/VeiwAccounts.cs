using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class VeiwAccounts : Customer
    {
        internal class ViewAccounts
        {
            


        }


        public static void ShowAccounts()
        {

            Console.WriteLine("Översikt: Konton");
            foreach (var accounts in Accounts)
                
            {
                Console.WriteLine($"Account: {account.Accounts}, Saldo: {account.Balance} SEK");
            }
        }



    }
}


