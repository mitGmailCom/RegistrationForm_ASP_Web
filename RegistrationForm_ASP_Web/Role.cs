using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationForm_ASP_Web
{
    public class Role
    {
        public string Name { get; set; }

        public Role(string name)
        {
            Name = name;
        }
        public Role()
        { }
    }
}