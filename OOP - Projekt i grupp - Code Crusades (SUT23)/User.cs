using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    public class User
    {
        public string Username { get; set; }
        public string Pin { get; set; }
        public bool Role { get; set; }
        public static User CurrentUser { get; set; }

        public User(string username, string pin, bool role)
        {
            Username = username;
            Pin = pin;
            Role = role;
        }
        public static void Login()
        {
            List<Customer> customers = Customer.CreateCustomerList();
            int loginAttempts = 0;
            User currentUser = null;

            Console.Clear();
            Console.WriteLine("\n\tVälkommen till Bankomaten!");
            while (loginAttempts < 3)
            {
                Console.Write("\n\tAnge ditt Användar-ID: ");
                string username = Console.ReadLine();

                Console.Write("\n\tAnge din pinkod: ");
                string pin = Console.ReadLine();

                User UserLogin = customers.Find(u => u.Username == username && u.Pin == pin);

                if (UserLogin != null)
                {
                    currentUser = UserLogin;
                    loginAttempts = 0;
                    Console.WriteLine($"\n\tInloggning lyckades. Välkommen!" +
                        "\n\tTryck \"Enter\" för att Fortsätta ");
                    Console.ReadKey();
                    Menu.startMenuForUser();
                }
                else
                {
                    Console.WriteLine("\n\tFelaktigt användarnamn eller pinkod. Försök igen.");
                    loginAttempts++;
                }
            }
            Console.WriteLine("\n\tFör många felaktiga inloggningsförsök. " +
                "\n\tProgrammet avslutas....");
            Console.ReadKey();
        }
    }






}
