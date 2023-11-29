using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class Start
    {
        public static List<Customer> CustomerList { get; set; }

        public static void StartBank()
        {
            // Initialize the list of customers
            CustomerList = new List<Customer>
            {
                new Customer("Admin", "Admin1234", true),

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
            User.Login();
        }
    }
}
