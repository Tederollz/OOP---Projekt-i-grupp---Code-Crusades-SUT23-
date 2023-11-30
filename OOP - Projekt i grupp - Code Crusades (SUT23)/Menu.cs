using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class Menu
    {
        public static void startMenuForUser()
        {
            bool IsAdmin = UserContext.CurrentUser.Role;
            List<string> Menulist = new List<string>();

            if (IsAdmin == true)
            {
                Menulist.Add("\tNy användaer");
                Menulist.Add("\tsätt Valutakurs");
                Menulist.Add("\tLogga ut");
                Menulist.Add("\tAvsluta");
                while (true)

                    case 0:
                        Console.WriteLine("Ny användare");
                        CreateUser.AddUser();
                        Console.ReadKey();
                        break;
                    case 1:
                        Console.WriteLine("sätt valuta");
                        break;
                    case 2:
                        Console.WriteLine("Du loggas ut\nTryck Enter");
                        Console.Read();
                        User.Login();
                        break;
                    case 3:
                        Console.WriteLine("Programmet avslutas\nTryck Enter för att avsluta programmet");
                        Console.Read();
                        Environment.Exit(0);
                        break;
                }
            }
            else
            {



                Menulist.Add("\tSe konton");
                Menulist.Add("\tÖverföring");
                Menulist.Add("\tÖppna nytt konto");
                Menulist.Add("\tÖverföringshistorik");
                Menulist.Add("\tLåneförfrågan");
                Menulist.Add("\tLogga ut");
                Menulist.Add("\tAvsluta");
                while (true)
  
                    int menuSelected = startMenuCustomer(Menulist);

                    switch (menuSelected)
                    {
                        case 0:
                            Console.WriteLine("Konton");
                            PrintAccounts.PrintAcc();
                            break;
                        case 1:
                            Console.WriteLine("Överföring");
                            Transfer.TransferMoney();
                            break;
                        case 2:
                            Console.WriteLine("Öppna nytt konto");
                            SavingsAccount.CreateSavingsAccount();
                            break;
                        case 3:
                            Console.WriteLine("Överföringshistorik");
                            break;
                        case 4:
                            Console.WriteLine("Låneförfrågan");
                            //RequestLoan.Loan();
                            break;
                        case 5:
                            Console.WriteLine("Du loggas ut\nTryck Enter");
                            Console.Read();
                            User.Login();
                            break;
                        case 6:
                            Console.WriteLine("Programmet avslutas\nTryck Enter för att avsluta programmet");
                            Console.Read();
                            Environment.Exit(0);
                            break;

                    }


                }
            }
        }
        public static int startMenuCustomer(List<string> MenuList)
        {
            int menuSelected = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Gör ditt val med piltangenterna och tryck Enter för att välja\n");
                for (int i = 0; i < MenuList.Count; i++)
                {
                    if (menuSelected == i)
                    {
                        Console.WriteLine("-->" + MenuList[i]);
                    }
                    else
                    {
                        Console.WriteLine(MenuList[i]);
                    }
                }
                var keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelected != MenuList.Count - 1)
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

                    return menuSelected;

                }
            }
        }
    }
}
