using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class SavingsAccount : Accounts
    {
        public decimal InterestRate { get; private set; }
        public SavingsAccount(decimal interestRate, string name, decimal balance, string currency) : base(name, balance, currency)
        {

            InterestRate = interestRate;

        }

        public static void CreateSavingsAccount()
        {

            Console.Write("\n\tVad vill du döpa ditt konto till: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                name = "Savings Account";                                  //Default name if no name is chosen
            }
            
            decimal insert = 0;
            bool validInput = false;
            do
            {

                Console.Write("\n\tHur mycket vill du sätta in: ");
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out insert) && insert > 0)                             // The user has to add atleast 1.  
                {
                    validInput = true;
                }
                else if (insert < 0)
                {
                    Console.Clear();
                    Console.WriteLine("\n\tBeloppet du matar in måste vara större än 0.");
                }
                else
                {
                    Console.WriteLine("\n\tOgiltig inmatning, var god försök igen!");
                }

            } while (!validInput);

            
            List<string> currencyOpt = new List<string> { "\tSEK", "\tUSD" };
            Console.WriteLine("\n\tVilken valuta vill du ha?" +
                "\n\tTryck Enter för att göra ditt val.");
            int menuSelected = Menu.startMenuArrow(currencyOpt);

            string currency = null;
            switch (menuSelected)
            {
                case 0:
                    currency = "SEK";
                    break;
                case 1:
                    currency = "USD";
                    break;
            }

            decimal interestRate = 2;
            decimal sum = insert * interestRate / 100;
            Console.WriteLine($"\n\tDitt nya konto: \"{name}\" med beloppet: {Math.Round(insert, 2)} {currency} har nu skapats.");
            Console.WriteLine($"\n\tDin ränta på pengarna är just nu {interestRate}% och din ökning per år är {sum:0.00} {currency}.");
            UserContext.CurrentUser.Accounts.Add(new SavingsAccount(interestRate, name, insert, currency));

            Console.ReadKey();
        }
    }
}
