using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class RequestLoan
    {
        public static decimal InterestRate = 0.05m;     //A decimal to control the interest rate

        public static void Loan()
        {
            decimal totalCapital = UserContext.CurrentUser.Accounts.Sum(account => account.Balance);
            decimal maxLoan = totalCapital * 5;
            Console.Write($"\n\tDu kan maximalt låna {maxLoan:0.00}" +
                $"\n\tAnge önskat belopp: ");

            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out decimal loanInput) && loanInput > 0)
                {
                    if (loanInput <= maxLoan)
                    {
                        decimal interest = CalculateInterest(loanInput);
                        Console.Clear();
                        Console.WriteLine($"\n\tRäntesatsen ligger på {InterestRate * 100}%. Det innebär att räntan för lånet är {interest}");                        
                        Loan newLoan = new Loan(loanInput, InterestRate);
                        UserContext.CurrentUser.AddLoan(newLoan);
                        DepositLoan(loanInput);
                    } 
                    else
                    {
                        Console.WriteLine($"\n\tDu kan maximalt låna {maxLoan:0.00}.");
                    }
                } 
                else
                {
                    Console.WriteLine("\n\tFel inmatning, försök igen.");
                }
            }
        }
        public static decimal CalculateInterest(decimal loanAmount)
        {
            return loanAmount * InterestRate;
        }
        public static void DepositLoan(decimal loanAmount)
        {
            Console.WriteLine("\n\tPå vilket konto vill du sätta in pengarna?\n");

            Console.WriteLine("\n\tDina konton & saldo:");
            foreach (var account in UserContext.CurrentUser.Accounts)
            {

                Console.WriteLine($"\n\t{account.Name}: {account.Balance:0.00} {account.Currency}");
            }
            
            Console.WriteLine(" ");
            Console.WriteLine("\n\tTryck Enter för att välja konton");
            Console.ReadKey();
            
            int selectedIndex = 0;

            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.WriteLine("\n\tVilket konto vill du lägga lånet på?\n");

                for (int i = 0; i < UserContext.CurrentUser.Accounts.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.Write("--> ");
                    }
                    else
                    {
                        Console.Write("    ");
                    }

                    Console.WriteLine($"\t{UserContext.CurrentUser.Accounts[i].Name}: {UserContext.CurrentUser.Accounts[i].Balance}" +
                        $" {UserContext.CurrentUser.Accounts[i].Currency}");
                }

                key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow && selectedIndex > 0)
                {
                    selectedIndex--;
                }
                else if (key.Key == ConsoleKey.DownArrow && selectedIndex < UserContext.CurrentUser.Accounts.Count - 1)
                {
                    selectedIndex++;
                }

            } while (key.Key != ConsoleKey.Enter);

            var chosenAccount = UserContext.CurrentUser.Accounts[selectedIndex];
            chosenAccount.Balance += loanAmount;

            Console.Clear();
            Console.WriteLine($"\n\t{loanAmount:0.00} {chosenAccount.Currency} sattes in på {chosenAccount.Name}.");
            Console.WriteLine($"\n\tNytt saldo: {Math.Round(chosenAccount.Balance, 2)}");
            Console.ReadKey();

            string logDetails = $"\n\tFrån : \t\tBank(Lån)\n" +
                $"\tTill : \t\t{chosenAccount.Name}\n" +
                $"\tÖverfört : \t{chosenAccount.Balance:0.00} {chosenAccount.Currency}\n" +
                $"\tDatum : \t{DateTime.Now}\n\n";

            TransferLog transferLog = new TransferLog(logDetails);
            UserContext.CurrentUser.LogTransfer(transferLog);

            Console.Clear();
            Menu.startMenuForUser();
        }

        public static void UpdateInterest()
        {
            Console.WriteLine("\n\tAnge den nya räntesatsen (som en procent, t.ex. 5 för 5%):");
            if (decimal.TryParse(Console.ReadLine(), out decimal input) && input >= 0 && input <= 100)
            {
                InterestRate = input / 100;
                Console.WriteLine($"\n\tRäntesatsen har uppdaterats till {InterestRate * 100}%.");
            } else
            {
                Console.WriteLine("\n\tFelaktig inmatning, ange ett värde mellan 0 och 100.");
            }
        }
    }

}
