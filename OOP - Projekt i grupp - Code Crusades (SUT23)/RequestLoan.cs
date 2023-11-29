using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class RequestLoan
    {
        public static decimal InterestRate = 0.05m;

        public static void depositLoan(Customer customer)
        {
            Console.WriteLine("På vilket konto vill du sätta in pengarna?");


        }
        public static void Loan(Customer customer)
        {
            decimal totalCapital = customer.Accounts.Sum(account => account.Balance);
            decimal maxLoan = totalCapital * 5;
            Console.WriteLine("Hur mycket vill du låna?");

            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out decimal loanInput) && loanInput > 0)
                {
                    if (loanInput <= maxLoan)
                    {
                        decimal interest = CalculateInterest(loanInput);
                        Console.WriteLine($"Du kommer att behöva betala {interest} i ränta.");
                        Loan newLoan = new Loan(loanInput, InterestRate);
                        //customer.AddLoan(newLoan);
                        depositLoan(customer);
                        break;
                    } else
                    {
                        Console.WriteLine($"Du kan maximalt låna {maxLoan}.");
                    }
                } else
                {
                    Console.WriteLine("Fel inmatning, försök igen.");
                }
            }
        }

        public static decimal CalculateInterest(decimal loanAmount)
        {
            return loanAmount * InterestRate;
        }
    }
}
