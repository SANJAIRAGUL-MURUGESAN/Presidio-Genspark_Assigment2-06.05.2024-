using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialsModelLibrary.UserExceptions
{
    public class UserAlreadyRegisteredException : Exception
    {
        string message;
        public UserAlreadyRegisteredException()
        {
            message = "User Already Registered!";
        }
        public override string Message => message;
    }
}
