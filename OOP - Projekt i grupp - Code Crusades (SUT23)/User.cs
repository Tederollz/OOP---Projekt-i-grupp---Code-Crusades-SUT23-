using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class User
    {
        public string Username { get; set; }
        public string Pin { get; set; }
        public bool Role { get; set; }

        public User(string username, string pin, bool role)
        {
            Username = username;
            Pin = pin;
            Role = role;
        }
    }






}
