using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class Start
    {
        public static List<User> CustomerList { get; set; }

        public static void StartBank()
        {
            ExchangeRate.CurrentRate = 0.096m;

            // Initialize the list of customers
            CustomerList = new List<User>
            {
                new User("Admin", "Admin1234", true),

                new User("JohnDoe", "1234", false)
            {
                Accounts =
                {
                    new Accounts("Lönekonto(SEK)", 1000, "SEK"),
                    new Accounts("Lönekonto(USD)", 500, "USD")
                }
            },
            new User("JaneSmith", "5678", false)
            {
                Accounts =
                {
                    new Accounts("Lönekonto(SEK)", 1500, "SEK"),
                    new Accounts("Lönekonto(USD)", 800, "USD")
                }
            },
            new User("AliceJones", "9876", false)
            {
                Accounts =
                {
                    new Accounts("Lönekonto(SEK)", 2000, "SEK"),
                    new Accounts("Lönekonto(USD)", 1200, "USD")
                }
            },
            new User("BobJohnson", "5432", false)
            {
                Accounts =
                {
                    new Accounts("Lönekonto(SEK)", 800, "SEK"),
                    new Accounts("Lönekonto(USD)", 300, "USD")
                }
            },
            new User("EveDavis", "8765", false)
            {
                Accounts =
                {
                    new Accounts("Lönekonto(SEK)", 2500, "SEK"),
                    new Accounts("Lönekonto(USD)", 1500, "USD")
                }
            }
        };
            User.Login();
        }
    }
}
