using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    public class Customer : User
    {
        public List<Accounts> Accounts { get; set; }

        public Customer(string username, string pin, bool role) : base(username, pin, role)
        {
            Accounts = new List<Accounts>();
        }
        public static List<Customer> CreateCustomerList()
        {
            return new List<Customer>
        {
            new Customer("JohnDoe", "1234", false)
            {
                Accounts =
                {
                    new Accounts("Savings", 1000),
                    new Accounts("Checking", 500)
                }
            },
            new Customer("JaneSmith", "5678", false)
            {
                Accounts =
                {
                    new Accounts("Savings", 1500),
                    new Accounts("Checking", 800)
                }
            },
            new Customer("AliceJones", "9876", false)
            {
                Accounts =
                {
                    new Accounts("Savings", 2000),
                    new Accounts("Checking", 1200)
                }
            },
            new Customer("BobJohnson", "5432", false)
            {
                Accounts =
                {
                    new Accounts("Savings", 800),
                    new Accounts("Checking", 300)
                }
            },
            new Customer("EveDavis", "8765", false)
            {
                Accounts =
                {
                    new Accounts("Savings", 2500),
                    new Accounts("Checking", 1500)
                }
            }
        };
        }
    }
}
