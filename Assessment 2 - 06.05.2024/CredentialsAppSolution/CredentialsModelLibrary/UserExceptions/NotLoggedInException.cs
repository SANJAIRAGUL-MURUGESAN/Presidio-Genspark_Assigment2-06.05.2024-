using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialsModelLibrary.UserExceptions
{
    public class NotLoggedInException : Exception
    {
        string message;
        public NotLoggedInException()
        {
            message = "You are Not Logged In to Logout!";
        }
        public override string Message => message;
    }
}
