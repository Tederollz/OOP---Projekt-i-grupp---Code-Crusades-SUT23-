using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    public class ExchangeRate
    {
        public static Decimal CurrentRate { get; set; }

        public ExchangeRate(decimal currentRate)
        {
            CurrentRate = currentRate;
        }

        public static void SetExchangeRate()
        {
            Console.Write($"\n\tKursen är just ny {CurrentRate} från SEK till USD" +
                $"\n\tVad vill du ändra kursen till: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal input))
            {
                CurrentRate = input;
                Console.WriteLine($"\n\tDen nya kursen är nu: {Math.Round(CurrentRate, 2)}");
            }
            else
            {
                Console.WriteLine("\n\tInvalid input. Please enter a valid decimal number.");
                Console.ReadKey();
            }

        }
    }
}
