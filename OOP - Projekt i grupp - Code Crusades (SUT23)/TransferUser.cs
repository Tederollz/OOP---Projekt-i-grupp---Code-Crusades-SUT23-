using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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
           
            int sourceAccountIndex = DisplayAccountMenu(UserContext.CurrentUser.Accounts, "from");

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

          
            int destinationAccountIndex = DisplayAccountMenu(UserContext.TargetUser.Accounts, "to");

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
                    $"\n\tifrån konto: {sourceAccount.Name} " +
                    $"\n\ttill Användare: {UserContext.TargetUser.Username} " +
                    $"\n\tkonto: {destinationAccount.Name}");


                    string logDetails = $"Från : \t\tAnvändare : {UserContext.CurrentUser.Username} - {sourceAccount.Name}\n" +
                    $"Till : \t\tAnvändare : {UserContext.TargetUser.Username} - {destinationAccount.Name}\n" +
                    $"Överfört : \t{amount:0.00} {sourceAccount.Currency}\n" +
                    $"Datum : \t{DateTime.Now}\n\n";

                    TransferLog transferLog = new TransferLog( logDetails );
                    UserContext.TargetUser.LogTransfer(transferLog );
                    UserContext.CurrentUser.LogTransfer(transferLog);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Överföring misslyckades. Källkontot har inte tillräckligt med täckning.");
            }

            Console.WriteLine($"Kvarvarande balans på {sourceAccount.Name}: {sourceAccount.Balance} {sourceAccount.Currency}");
            Console.WriteLine($"Total balans på {destinationAccount.Name}: {destinationAccount.Balance} {sourceAccount.Currency}");
            Console.ReadKey();
        }

        //Meny för överföring mellan användare
        public static int DisplayAccountMenu(List<Accounts> accounts, string transferType)
        {
            int selectedIndex = 0;

            ConsoleKeyInfo key;

            do
            {
                Console.Clear();

                if (transferType == "from")
                {
                    Console.WriteLine("Vilket konto vill du överföra ifrån?");
                    
                }
                else if (transferType == "to")
                {
                    Console.WriteLine("Vilket konto vill du överföra till?");
                }

                Console.WriteLine();

                for (int i = 0; i < accounts.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.Write("--> ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }

                    Console.WriteLine($"\t{accounts[i].Name}: {accounts[i].Balance:C}");
                }

                key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow && selectedIndex > 0)
                {
                    selectedIndex--;
                }
                else if (key.Key == ConsoleKey.DownArrow && selectedIndex < accounts.Count - 1)
                {
                    selectedIndex++;
                }

            } while (key.Key != ConsoleKey.Enter);

            return selectedIndex;

        }
    }
}
