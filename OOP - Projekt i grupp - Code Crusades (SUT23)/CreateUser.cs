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

            bool role = false;

            User newCustomer = new User(username, pin, role);
            newCustomer.Accounts = new List<Accounts>();

            Start.CustomerList.Add(newCustomer);

            Console.WriteLine($"\n\tAnvändare {username} Skapats!");
            Console.ReadKey();
        }
    }
}
