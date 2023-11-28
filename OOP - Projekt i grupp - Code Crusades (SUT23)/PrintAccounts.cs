using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class PrintAccounts : Customer
    {
        public PrintAccounts(string username, string pin, bool role) : base(username, pin, role)
        {
        }
        public void PrintAcc()
        {
           /* Console.WriteLine("\n\tDina konton & saldo:");

            foreach (var account in User.CurrentUser)
            {
                Console.WriteLine($"\n\t{account.Name}: {account.Balance:C}");
            }
           */
        }
    }
}
