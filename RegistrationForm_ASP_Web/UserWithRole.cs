using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationForm_ASP_Web
{
    public class UserWithRole
    {
        protected UserClass UserObject;
        protected Role UserRoleObject;

        public UserWithRole()
        { }

        public UserWithRole(UserClass usrObj,  Role usrRoleObj)
        {
            UserObject = usrObj;
            UserRoleObject = usrRoleObj;
        }

        
    }

   
}