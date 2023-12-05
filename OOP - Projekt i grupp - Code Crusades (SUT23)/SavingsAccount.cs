﻿using System;
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

            Console.WriteLine("\nVad vill du döpa ditt konto till?");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                name = "Savings Account";                                  //Default name if no name is chosen
            }
            string currency = "SEK";
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
                    Console.WriteLine("Beloppet du matar in måste vara större än 0.");
                }

            } while (!validInput);

            decimal interestRate = 2;
            decimal sum = insert * interestRate / 100;
            Console.WriteLine($"\nDitt nya konto: *{name}* med beloppet: {insert:C} har nu skapats.");
            Console.WriteLine($"\nDin ränta på pengarna är just nu {interestRate}% och din ökning per år är {sum:C}.");
            UserContext.CurrentUser.Accounts.Add(new SavingsAccount(interestRate, name, insert, currency));

            Console.ReadKey();
        }
    }
}
