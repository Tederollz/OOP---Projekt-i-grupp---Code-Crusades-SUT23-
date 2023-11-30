using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using test;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{

    internal class Transfer
    {
        public static void TransferMoney()
        {
            Console.Clear();
            Console.WriteLine("\n\t-- Överföring mellan konton --");
            PrintAccounts.PrintAcc();

            Console.Write("\n\tVälj konto att ta pengar från: ");
            string fromAcct = Console.ReadLine();

            Console.Write("\n\tVälj konto att flytta pengar till: ");
            string toAcct = Console.ReadLine();

            Console.Write("\n\tAnge summa att flytta: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Accounts fromAccount = UserContext.CurrentUser.Accounts.Find(acc => acc.Name == fromAcct);
                Accounts toAccount = UserContext.CurrentUser.Accounts.Find(acc => acc.Name == toAcct);

                if (fromAccount != null && toAccount != null)
                {
                    if (fromAccount.Balance >= amount)
                    {
                        fromAccount.Balance -= amount;
                        toAccount.Balance += amount;
                        Console.WriteLine("\n\tÖverföringen lyckades.");
                        PrintAccounts.PrintAcc();
                        Console.WriteLine("\n\tTryck \"Enter\" för att Fortsätta ");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("\n\tError: Du har för lite pengar på kontot.");
                        Console.WriteLine("\n\tTryck \"Enter\" för att Fortsätta ");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("\n\tEtt eller båda konton finns inte.");
                    Console.WriteLine("\n\tTryck \"Enter\" för att Fortsätta ");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("\n\tError: Ogiltigt input.");
                Console.WriteLine("\n\tTryck \"Enter\" för att Fortsätta ");
                Console.ReadKey();
            }
        }
        
    }
}



