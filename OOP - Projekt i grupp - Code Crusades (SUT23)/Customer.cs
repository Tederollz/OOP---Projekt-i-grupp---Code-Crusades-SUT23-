using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class Customer : User
    {
        public List<Accounts> Accounts { get; set; }

        public Customer(string username, string pin, bool role) : base(username, pin, role)
        {
            Accounts = new List<Accounts>();
        }
    }
}
