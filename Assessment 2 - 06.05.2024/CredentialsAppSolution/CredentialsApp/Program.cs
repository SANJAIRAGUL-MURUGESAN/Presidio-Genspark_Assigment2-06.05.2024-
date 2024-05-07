namespace CredentialsApp
{
    public class Program
    {
        public void UserOperations()
        {

        }
        static async Task Main(string[] args)
        {
            UserFrontend Userfrontend = new UserFrontend();
            Console.WriteLine("Case 1 : User Register");
            Console.WriteLine("Case 2 : User Login");
            Console.WriteLine("Case 3 : USer Logout");
            Console.WriteLine("Case 4 : Get All Users");
            Console.WriteLine("Case 5 : Get User By ID");
            bool value = true;
            while (value)
            {
                Console.WriteLine("Enter Your Option :");
                int Input = Convert.ToInt32(Console.ReadLine());
                switch (Input)
                {
                    case 1:
                        Userfrontend.RegisterCustomer();
                        break;
                    case 2:
                        Userfrontend.LoginCustomer();
                        break;
                    case 3:
                        Userfrontend.LogoutCustomer();
                        break;
                    case 4:
                        Userfrontend.GetAllUsers();
                        break;
                    case 5:
                        Userfrontend.GetUserByID();
                        break;
                    default:
                        value = false;
                        break;
                }
            }
            
        }
    }
}
