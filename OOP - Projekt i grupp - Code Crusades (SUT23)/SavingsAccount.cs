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
        public SavingsAccount(decimal interestRate, string name, decimal balance) : base(name, balance)
        {

            InterestRate = interestRate;

        }
       
        public static void CreateSavingsAccount()
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
            decimal interestRate = 2;
            UserContext.CurrentUser.Accounts.Add(new SavingsAccount(interestRate, name, insert));
            }
            Console.ReadKey();


        }
    }
}
