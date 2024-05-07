using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialsModelLibrary.UserExceptions
{
    public class NoUserFoundException : Exception
    {
     
            string message;
            public NoUserFoundException()
            {
                message = "There are No Users Found!";
            }
            public override string Message => message;
    }
}
