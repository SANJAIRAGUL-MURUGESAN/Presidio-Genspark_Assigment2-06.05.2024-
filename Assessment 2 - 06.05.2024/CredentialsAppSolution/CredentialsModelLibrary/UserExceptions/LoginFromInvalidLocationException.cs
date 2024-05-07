using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialsModelLibrary.UserExceptions
{
    public class LoginFromInvalidLocationException : Exception
    {
        string message;
        public LoginFromInvalidLocationException()
        {
            message = "Logging In with your location is not Allowed!";
        }
        public override string Message => message;
    }
}
