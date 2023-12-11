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
            int sourceAccountIndex, destinationAccountIndex;
            sourceAccountIndex = Transfer.DisplayAccountMenu(UserContext.CurrentUser.Accounts, "from");

            Console.Write("\n\tAnge mottagarens användarnamn: ");
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

            Console.Clear();
            destinationAccountIndex = DisplayAccountMenu(UserContext.TargetUser.Accounts, "to");
            Console.Clear();

            Console.Write("\n\tAnge belopp att överföra: ");

            decimal amount;
            if (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.Clear();
                Console.WriteLine("\n\tOgiltigt belopp, eller inmatning. Överföring avbruten.");
                Console.ReadKey();
                return;
            }

            // Hitta källkonto 
            var sourceAccount = UserContext.CurrentUser.Accounts[sourceAccountIndex];
            // Hitta målkonto
            var destinationAccount = UserContext.TargetUser.Accounts[destinationAccountIndex];

            if (sourceAccount.Balance >= amount)
            {
                sourceAccount.Balance -= amount;
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
                destinationAccount.Balance += amount;
                Console.Clear();
                Console.WriteLine("\n\tÖverföringen genomförs. Klart om 15 min.");
                //Thread.Sleep(15 * 60 * 1000);

                Console.WriteLine($"\n\tFrån : \t\tAnvändare : {UserContext.CurrentUser.Username} - {sourceAccount.Name}\n" +
                    $"\tTill : \t\tAnvändare : {UserContext.TargetUser.Username} - {destinationAccount.Name}\n" +
                    $"\tÖverfört : \t{amount:0.00} {destinationAccount.Currency}\n");

                string logDetails = $"\n\tFrån : \t\tAnvändare : {UserContext.CurrentUser.Username} - {sourceAccount.Name}\n" +
                    $"\tTill : \t\tAnvändare : {UserContext.TargetUser.Username} - {destinationAccount.Name}\n" +
                    $"\tÖverfört : \t{amount:0.00} {destinationAccount.Currency}\n" +
                    $"\tDatum : \t{DateTime.Now}\n\n";

                TransferLog transferLog = new TransferLog(logDetails);
                UserContext.TargetUser.LogTransfer(transferLog);
                UserContext.CurrentUser.LogTransfer(transferLog);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n\tÖverföring misslyckades. Källkontot har inte tillräckligt med täckning.");
            }

            Console.WriteLine($"\tKvarvarande balans på {sourceAccount.Name}: {sourceAccount.Balance:0.00} {sourceAccount.Currency}");

            Console.ReadKey();
        }
        public static int DisplayAccountMenu(List<Accounts> accounts, string transferType)
        {
            int selectedIndex = 0;

            ConsoleKeyInfo key;

            do
            {
                Console.Clear();
                //Håller kvar CW i toppen av valet av konto.
                if (transferType == "from")
                {
                    Console.WriteLine("\n\tVilket konto vill du överföra ifrån?");
                }
                else if (transferType == "to")
                {
                    Console.WriteLine("\n\tVilket konto vill du överföra till?");
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

                    Console.WriteLine($"\t{accounts[i].Name} ({accounts[i].Currency}): ");
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
