using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class PrintAccounts
    {
        public static void PrintAcc()
        {
            Console.WriteLine("\n\tDina konton & saldo:");

            foreach (var account in UserContext.CurrentUser.Accounts)
            {
                Console.WriteLine($"\n\t{account.Name}: {account.Balance:C}");
            }
            Console.ReadKey();

        }
    }
}
