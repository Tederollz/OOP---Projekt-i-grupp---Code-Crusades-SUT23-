using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class Transfer : Customer
    {

        public decimal Balance { get; set; }

        public Transfer(decimal balance, string account)

        {
            Accounts = account;
            Balance = balance;
        }
    }



    public void TransferMoney(decimal amount, Transfer destinationAccount)
    {
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            destinationAccount.Balance += amount;
            Console.WriteLine($"Överfört: {amount} SEK från: {Account} till kontot: {destinationAccount.Account}");
        }
        else
        {
            Console.WriteLine("Du har inte tillräckligt med täckning för att överföra");
        }
    }
}
