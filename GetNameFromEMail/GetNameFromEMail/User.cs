using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GetNameFromEMail
{
    public class User
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User()
        {
            
        }
        public User(string email, string firstName, string lastName)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"{Email},{FirstName},{LastName}";
        }
    }
}
