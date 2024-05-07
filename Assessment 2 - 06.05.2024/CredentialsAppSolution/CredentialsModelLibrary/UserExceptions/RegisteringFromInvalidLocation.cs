using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialsModelLibrary.UserExceptions
{
    public class RegisteringFromInvalidLocation : Exception
    {
        string message;
        public RegisteringFromInvalidLocation()
        {
            message = "Registering with your location is not Allowed!";
        }
        public override string Message => message;
    }
}
