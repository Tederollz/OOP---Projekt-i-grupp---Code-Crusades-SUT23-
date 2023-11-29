using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{

    internal class Transfer : Customer
    {
        public static decimal Balance { get; set; }
        public static string SourceAccountType { get; set; }
        public static string DestinationAccountType { get; set; }

        public Transfer(string sourceAccountType, string destinationAccountType, decimal balance) : base("TransferCustomer", "", false)
        {
            SourceAccountType = sourceAccountType;
            DestinationAccountType = destinationAccountType;
            Balance = balance;
        }

        public static void TransferMoney()
        {
            Console.WriteLine("Välj konto att överföra från:");
            Console.WriteLine("1. Savings");
            Console.WriteLine("2. Checking");

            if (!int.TryParse(Console.ReadLine(), out int sourceAccountChoice) || (sourceAccountChoice != 1 && sourceAccountChoice != 2))
            {
                Console.WriteLine("Ogiltigt val. Överföring avbruten.");
                return;
            }

            string sourceAccountType = (sourceAccountChoice == 1) ? "Savings" : "Checking";

            Console.WriteLine("Välj konto att överföra till:");
            Console.WriteLine("1. Savings");
            Console.WriteLine("2. Checking");

            if (!int.TryParse(Console.ReadLine(), out int destinationAccountChoice) || (destinationAccountChoice != 1 && destinationAccountChoice != 2))
            {
                Console.WriteLine("Ogiltigt val. Överföring avbruten.");
                return;
            }

            string destinationAccountType = (destinationAccountChoice == 1) ? "Savings" : "Checking";

            Console.WriteLine("Ange belopp att överföra:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("Ogiltigt belopp. Överföring avbruten.");
                return;
            }


            // Hitta källkonto
            Accounts sourceAccount = UserContext.CurrentUser.Accounts.Find(acc => acc.Name == SourceAccountType);

            // Hitta målkonto
            Accounts destinationAccount = UserContext.TargetUser.Accounts.Find(acc => acc.Name == DestinationAccountType);

            if (sourceAccount != null && destinationAccount != null && Balance > 0 && sourceAccount.Balance >= Balance)
            {
                sourceAccount.Balance -= Balance;
                destinationAccount.Balance += Balance;
                Console.WriteLine($"Överfört: {Balance} SEK från konto: {sourceAccount.Name} till kontot: {destinationAccount.Name}");
            }
            else
            {
                Console.WriteLine("Överföring misslyckades. Kontrollera att du har tillräckligt med täckning och att kontona är giltiga.");
            }
        }
    }

}