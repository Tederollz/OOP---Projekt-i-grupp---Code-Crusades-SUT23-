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
            Console.WriteLine("Vad vill du döpa ditt konto till?");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                name = "No name added";
            }
            Console.WriteLine("Hur mycket vill du sätta in?");
            string input = Console.ReadLine();
            decimal insert;
            if (!decimal.TryParse(input, out insert) || insert < 0)
            {
                Console.WriteLine("Du kan inte sätta in negativt belopp");
                insert = 0;
            }
            else
            {
                
                UserContext.CurrentUser.Accounts.Add(new CheckingAccount(name, insert));
            }
            Console.ReadKey();
        }
    }
}
