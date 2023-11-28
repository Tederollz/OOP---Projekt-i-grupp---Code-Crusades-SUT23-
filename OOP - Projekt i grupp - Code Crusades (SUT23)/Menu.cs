using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class Menu
    {
        public static void startMenuCustomer()
        {
            string[] mainMenu = new string[] { "\tSe konton", "\tÖverföring", "\tÖppna nytt konto", "\tÖverföringshistorik", "\tLåneförfrågan", "\tAvsluta" };
            // string[] AdminMenu = new string[] {"\tNy användare", "\tsätt Valutakurs", "\tAvsluta"};

            //List<Array> menu = new List<Array>() {mainMenu, AdminMenu };

            int menuSelected = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Gör ditt val med piltangenterna och tryck Enter för att välja\n");
                for (int i = 0; i < mainMenu.Length; i++)
                {
                    if (menuSelected == i)
                    {
                        Console.WriteLine("-->" + mainMenu[i]);
                    }
                    else
                    {
                        Console.WriteLine(mainMenu[i]);
                    }
                }
                var keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelected != mainMenu.Length - 1)
                {
                    menuSelected++;
                }
                else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelected >= 1)
                {
                    menuSelected--;
                }
                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    switch (menuSelected)
                    {
                        case 0:
                            Console.WriteLine("Konton");
                            break;
                        case 1:
                            Console.WriteLine("Överföring");
                            break;
                        case 2:
                            Console.WriteLine("Öppna nytt konto");
                            break;
                        case 3:
                            Console.WriteLine("Överföringshistorik");
                            break;
                        case 4:
                            Console.WriteLine("Låneförfrågan");
                            break;
                        case 5:
                            Console.WriteLine("Du logags ut\nTryck Enter för att");
                            Console.Read();
                            User.Login();
                            break;
                    }
                }
            }
        }
    }
}
