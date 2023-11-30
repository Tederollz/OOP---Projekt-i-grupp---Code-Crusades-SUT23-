namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    public class CreateUser
    {
        public static void AddUser()
        {
            Console.Write("\n\tAnge Användarnamn: ");
            string username = Console.ReadLine();

            Console.Write("\n\tAnge pin: ");
            string pin = Console.ReadLine();

            Console.Write("\n\tAnge roll (true för admin, false för customer): ");
            bool role;
            while (!bool.TryParse(Console.ReadLine(), out role))
            {
                Console.WriteLine("\n\tOgiltigt input. Ange true för admin, false för customer.");
            }

            Customer newCustomer = new Customer(username, pin, role);
            newCustomer.Accounts = new List<Accounts>();

            Start.CustomerList.Add(newCustomer);

            Console.WriteLine($"\n\tAnvändare {username} Skapats!");
        }
    }
}
