using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialsModelLibrary.UserExceptions
{
    public class InvalidPasswordException : Exception
    {
        string message;
        public InvalidPasswordException()
        {
            message = "Invalid Password!";
        }
        public override string Message => message;
    }
}
