using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialsModelLibrary.UserExceptions
{
    public class NoUserFoundWithGivenIDException : Exception
    {
        string message;
        public NoUserFoundWithGivenIDException()
        {
            message = "No User Found with Given ID!";
        }
        public override string Message => message;
    }
}
