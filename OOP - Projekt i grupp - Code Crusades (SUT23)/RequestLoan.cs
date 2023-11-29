using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class RequestLoan
    {
        public static decimal InterestRate = 0.05m;


        public static void Loan()
        {
            decimal totalCapital = UserContext.CurrentUser.Accounts.Sum(account => account.Balance);
            decimal maxLoan = totalCapital * 5;
            Console.WriteLine($"Hur mycket vill du låna?\nDu kan maximalt låna {maxLoan}");

            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out decimal loanInput) && loanInput > 0)
                {
                    if (loanInput <= maxLoan)
                    {
                        decimal interest = CalculateInterest(loanInput);
                        Console.WriteLine($"Räntesatsen ligger på {InterestRate * 100}%. Det innebär att räntan för lånet är {interest}sek");                        
                        Loan newLoan = new Loan(loanInput, InterestRate);
                        UserContext.CurrentUser.AddLoan(newLoan);
                        depositLoan(loanInput);
                        
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
        public static void depositLoan(decimal loanAmount)
        {
            Console.WriteLine("På vilket konto vill du sätta in pengarna?");

            Console.WriteLine("\n\tDina konton & saldo:");
            int count = 1;
            foreach (var account in UserContext.CurrentUser.Accounts)
            {
                
                Console.WriteLine($"\n\t{count}, {account.Name}: {account.Balance:C}");
                count++;
            }

            int chosenAccountIndex;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out chosenAccountIndex) &&
                    chosenAccountIndex > 0 &&
                    chosenAccountIndex <= UserContext.CurrentUser.Accounts.Count)
                {
                    break;
                } else
                {
                    Console.WriteLine("Felaktigt val, försök igen.");
                }
            }

            var chosenAccount = UserContext.CurrentUser.Accounts[chosenAccountIndex - 1];
            chosenAccount.Balance += loanAmount;

            Console.WriteLine($"\n{loanAmount}sek sattes in på {chosenAccount.Name}.");
            Console.WriteLine($"Nytt saldo : {chosenAccount.Balance}");
            Console.ReadKey();
            Console.Clear();
            Menu.startMenuForUser();

        }
    }
}
