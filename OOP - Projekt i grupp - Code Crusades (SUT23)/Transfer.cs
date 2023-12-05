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
        public string SourceAccountType { get; set; }
        public string DestinationAccountType { get; set; }

        public Transfer(string sourceAccountType, string destinationAccountType, decimal balance)
        {
            SourceAccountType = sourceAccountType;
            DestinationAccountType = destinationAccountType;
            Balance = balance;
        }
        //hålla koll på menyval
        public enum TransferStep
        {
            SourceAccount,
            DestinationAccount
        }

        private static TransferStep currentStep;
        private static void DisplayAccountMessage()
        {
            Console.Clear();


            switch (currentStep)
            {
                case TransferStep.SourceAccount:
                    Console.WriteLine("Vilket konto vill du överföra ifrån?");
                    break;
                case TransferStep.DestinationAccount:
                    Console.WriteLine("Vilket konto vill du överföra till?");
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }

        public static void TransferMoney()
        {
            currentStep = TransferStep.SourceAccount;
            DisplayAccountMessage();
            int sourceAccountIndex = DisplayAccountMenu(UserContext.CurrentUser.Accounts);

            currentStep = TransferStep.DestinationAccount;
            DisplayAccountMessage();
            int destinationAccountIndex = DisplayAccountMenu(UserContext.CurrentUser.Accounts);

            if (sourceAccountIndex == destinationAccountIndex)
            {
                Console.Clear();
                Console.WriteLine("Ogiltigt val. Du kan inte överföra pengar från och till samma konto.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Ange belopp att överföra:");

            decimal amount;
            if (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.Clear();
                Console.WriteLine("Ogiltigt belopp, eller inmating. Överföring avbruten.");
                Console.ReadKey();
                return;
            }
           


            // Hitta källkonto 
            var sourceAccount = UserContext.CurrentUser.Accounts[sourceAccountIndex];
            // Hitta målkonto
            var destinationAccount = UserContext.CurrentUser.Accounts[destinationAccountIndex];

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
                Console.Clear();
                Console.WriteLine("Överföringen genomförs. Klart om 15 min.");
                Thread.Sleep(15 * 60 * 1000);
                Console.WriteLine($"Överfört: {amount} SEK från konto: {sourceAccount.Name} till kontot: {destinationAccount.Name}");

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Överföring misslyckades. Källkontot har inte tillräckligt med täckning.");
            }

            Console.WriteLine($"Kvarvarande balans på {sourceAccount.Name}: {sourceAccount.Balance} SEK");
            Console.WriteLine($"Total balans på {destinationAccount.Name}: {destinationAccount.Balance} SEK");

            Transfer transferDetails = new Transfer(sourceAccount.Name, destinationAccount.Name, amount);
            TransferLog transferLog = new TransferLog(transferDetails);
            UserContext.CurrentUser.LogTransfer(transferLog);
            Console.ReadKey();
        }

        //meny
        public static int DisplayAccountMenu(List<Accounts> accounts)
        {
            int selectedIndex = 0;
            
            ConsoleKeyInfo key;

            do
            {

                Console.Clear();
               

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

                    Console.WriteLine($"{accounts[i].Name}: {accounts[i].Balance:C}");
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