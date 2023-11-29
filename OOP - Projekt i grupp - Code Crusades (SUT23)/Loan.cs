using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    public class Loan       //A class for creating new loans
    {
        public decimal Amount { get; set; }
        public decimal Interest { get; set; }

        public Loan(decimal amount, decimal interest)
        {
            Amount = amount;
            Interest = interest;
        }

    }
}
