using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class Transfer
    {
        public string Account { get; set; }
        public decimal Balance { get; set; }
    }

    public BankAccount(string account, double balance)
    {
        Account = account;
        Balance = balance;
    }

    public void TransferMoney(double amount, BankAccount targetAccount)
    {
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            targetAccount.Balance += amount;
            Console.WriteLine($"Överfört: {amount} SEK ifrån: {Account} till kontot: {targetAccount.Account}");
        }
        else
        {
            Console.WriteLine("Du har inte tillräckligt med täcking för att överföra");
        }
    }
}