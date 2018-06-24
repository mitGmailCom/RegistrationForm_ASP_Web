using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationForm_ASP_Web
{
    
    public class UserClass
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        List<UserClass> ListUsersRegistr = new List<UserClass>();

        public UserClass(string email, string pass, string name, string lname, string city)
        {
            Email = email;
            Password = pass;
            FirstName = name;
            LastName = lname;
            City = city;
        }

        public UserClass(int id, string email, string pass, string name, string lname, string city)
        {
            Id = id;
            Email = email;
            Password = pass;
            FirstName = name;
            LastName = lname;
            City = city;
        }

        public UserClass()
        {
        }

        
        
    }
}