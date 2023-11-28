using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class RequestLoan
    {
        public static decimal maxAmount(Customer customer)
        {

            decimal totalCapital = customer.Accounts.Sum(account => account.Balance);
            decimal maxLoan = totalCapital * 5;
            return maxLoan;


        }
    }
}
