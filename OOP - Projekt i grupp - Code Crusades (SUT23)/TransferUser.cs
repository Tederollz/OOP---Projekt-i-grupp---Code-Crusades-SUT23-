using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class TransferUser
    {
        public static void TransferToUser()
        {
            Console.WriteLine("Välj konto att överföra från:");
            int sourceAccountIndex = Transfer.DisplayAccountMenu(UserContext.CurrentUser.Accounts);

            Console.WriteLine("Ange mottagarens användarnamn:");
            string destinationUsername = Console.ReadLine();
            User destinationUser = Start.CustomerList.Find(u => u.Username == destinationUsername);

            if (destinationUser != null)
            {
                UserContext.TargetUser = destinationUser;
                Console.WriteLine($"\n\tAnvändaren med användarnamn {destinationUsername} hittades. Överföring fortsätter.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"\n\tAnvändaren med användarnamn {destinationUsername} hittades inte. Överföring avbruten.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Välj konto att överföra till:");
            int destinationAccountIndex = Transfer.DisplayAccountMenu(UserContext.TargetUser.Accounts);

            Console.WriteLine("Ange belopp att överföra:");

            decimal amount;
            if (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.Clear();
                Console.WriteLine("Ogiltigt belopp, eller inmating. Överföring avbruten.");
                Console.ReadKey();
                return;
            }
            // ska denna ligga här? sen 15*60*1000 i sleep.
            Console.Clear();
            Console.WriteLine("Överföringen genomförs. Klart om 15 min.");
            Thread.Sleep(1000);

            // Hitta källkonto 
            var sourceAccount = UserContext.CurrentUser.Accounts[sourceAccountIndex];
            // Hitta målkonto
            var destinationAccount = UserContext.TargetUser.Accounts[destinationAccountIndex];

            if (sourceAccount.Currency != destinationAccount.Currency)
            {
                if (sourceAccount.Currency == "SEK")
                {
                    amount = amount * ExchangeRate.CurrentRate;
                }
                else if (sourceAccount.Currency == "USD")
                {
                    amount = amount / ExchangeRate.CurrentRate;
                }
            }

            if (sourceAccount.Balance >= amount)
            {
                sourceAccount.Balance -= amount;
                destinationAccount.Balance += amount;
                Console.WriteLine($"\n\tÖverfört: {amount} SEK från Användare: {UserContext.CurrentUser.Username}" +
                    $"\n\tkonto: {sourceAccount.Name} " +
                    $"\n\ttill Användare: {UserContext.TargetUser.Username} " +
                    $"\n\tkonto: {destinationAccount.Name}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Överföring misslyckades. Källkontot har inte tillräckligt med täckning.");
            }

            Console.WriteLine($"Kvarvarande balans på {sourceAccount.Name}: {sourceAccount.Balance} SEK");
            Console.WriteLine($"Total balans på {destinationAccount.Name}: {destinationAccount.Balance} SEK");
            Console.ReadKey();
        }
    }
}
