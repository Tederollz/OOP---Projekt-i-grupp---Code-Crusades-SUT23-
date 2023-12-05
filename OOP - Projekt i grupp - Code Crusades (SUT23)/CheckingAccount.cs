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
        
        public CheckingAccount(string name, decimal balance, string currency) : base(name, balance, currency)
        {

        }
        public static void CreateAccount()
        {
            Console.WriteLine("\nVad vill du döpa ditt konto till?");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                name = "Checking Account";                                  //Default name if the user doesnt add anything
            }


            decimal insert = 0;
            bool validInput = false;
            do
            {

                Console.WriteLine("\nHur mycket vill du sätta in?");
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out insert) && insert > 0)                             // The user has to add atleast 1.  
                {
                    validInput = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nBeloppet du matar in måste vara större än 0.");
                }

            } while (!validInput);

            
            Console.WriteLine($"\nDitt nya konto: *{name}* med beloppet: {insert:C} har skapats.");
            UserContext.CurrentUser.Accounts.Add(new CheckingAccount(name, insert));
            
            Console.ReadKey();
        }
    }
}
