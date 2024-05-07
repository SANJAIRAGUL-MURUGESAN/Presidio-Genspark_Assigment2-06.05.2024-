using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialsModelLibrary.UserExceptions
{
    public class BlockedUserException : Exception
    {
        string message;
        public BlockedUserException()
        {
            message = "You are Blocked due to more number of Invalid Login Attempt!";
        }
        public override string Message => message;
    }
}
