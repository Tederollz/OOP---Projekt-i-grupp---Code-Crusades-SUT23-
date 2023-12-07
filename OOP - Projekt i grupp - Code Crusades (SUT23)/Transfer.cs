using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using test;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{

    public class Transfer
    {
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public string SourceAccountType { get; set; }
        public string DestinationAccountType { get; set; }

        public Transfer(string sourceAccountType, string destinationAccountType, decimal balance, string currency)
        {
            SourceAccountType = sourceAccountType;
            DestinationAccountType = destinationAccountType;
            Balance = balance;
            Currency = currency;
        }


        public static void TransferMoney()
        {
            int sourceAccountIndex, destinationAccountIndex;           
            sourceAccountIndex = DisplayAccountMenu(UserContext.CurrentUser.Accounts, "from");
            Console.Clear();
            destinationAccountIndex = DisplayAccountMenu(UserContext.CurrentUser.Accounts, "to");
            Console.Clear();

            if (sourceAccountIndex == destinationAccountIndex)
            {
                Console.WriteLine("Ogiltigt val. Du kan inte överföra pengar från och till samma konto.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Ange belopp att överföra:");

            decimal amount;
            if (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.Clear();
                Console.WriteLine("Ogiltigt belopp, eller inmatning. Överföring avbruten.");
                Console.ReadKey();
                return;
            }



            // Hitta källkonto 
            var sourceAccount = UserContext.CurrentUser.Accounts[sourceAccountIndex];
            // Hitta målkonto
            var destinationAccount = UserContext.CurrentUser.Accounts[destinationAccountIndex];



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
                Console.WriteLine("Överföringen genomförs. Klart om 15 min.");
                //Thread.Sleep(15 * 60 * 1000);
                Console.WriteLine($"Överfört: {amount} SEK från konto: {sourceAccount.Name} till kontot: {destinationAccount.Name}");
                string logDetails = $"Från : \t\t{sourceAccount.Name}\n" +
                $"Till : \t\t{destinationAccount.Name}\n" +
                $"Överfört : \t{amount:0.00} {sourceAccount.Currency}\n" +
                $"Datum : \t{DateTime.Now}\n\n";

                TransferLog transferLog = new TransferLog(logDetails);
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

        //Meny för överföring mellan konton
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