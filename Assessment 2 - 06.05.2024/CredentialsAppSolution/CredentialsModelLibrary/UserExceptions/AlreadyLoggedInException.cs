using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialsModelLibrary.UserExceptions
{
    public class AlreadyLoggedInException: Exception
    {
        string message;
        public AlreadyLoggedInException()
        {
            message = "You are Already Logged In!";
        }
        public override string Message => message;
    }
}
