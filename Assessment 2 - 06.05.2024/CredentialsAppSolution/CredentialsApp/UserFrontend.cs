using CredentialsAppDALibrary;
using CredentialsBLLibrary;
using CredentialsModelLibrary;
using CredentialsModelLibrary.UserExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialsApp
{
    public class UserFrontend
    {
        IRepository<int, User> Userrepository;
        IUserService UserService;

        public UserFrontend()
        {
            Userrepository = new UserRepository();
            UserService = new UserBL(Userrepository);
        }

        public async Task RegisterCustomer()
        {
            try
            {
                var Result = await UserService.GetAll();
                int id = (Result.Count) + 1;
                User user = new User();
                Console.WriteLine("Enter Username :");
                string username = Console.ReadLine();
                Console.WriteLine("Enter Password :");
                string password = Console.ReadLine();
                Console.WriteLine("Enter Email :");
                string email = Console.ReadLine();
                Console.WriteLine("Enter Location :");
                string location = Console.ReadLine();
                user.Id = id;
                user.Username = username;
                user.Password = password;
                user.Email = email;
                user.Location = location; ;
                User Result2 = await UserService.AddUser(user);
                Console.WriteLine($"{Result2.Email} Registered Successfully!");
            }catch(UserAlreadyRegisteredException Uare)
            {
                Console.WriteLine(Uare.Message);
            }
            catch(RegisteringFromInvalidLocation Rfil)
            {
                Console.WriteLine(Rfil.Message);
            }
        }

        public async Task GetUserByID()
        {
            try
            {
                Console.WriteLine("Enter the ID of the User: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var Result = await UserService.GetByKey(id);
                Console.WriteLine($"Username : {Result.Username}");
            }
            catch (NoUserFoundWithGivenIDException Nufwgi)
            {
                Console.WriteLine(Nufwgi.Message);
            }
        }

        public async Task GetAllUsers()
        {
            try
            {
                var Result = await UserService.GetAll();
                Console.WriteLine($"Totol Users Count : {Result.Count}");
            }catch(NoUserFoundException Nufe)
            {
                Console.WriteLine(Nufe.Message);
            }
        }

        public async Task LoginCustomer()
        {
            try
            {
                Console.WriteLine("Enter ID : ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Password :");
                string password = Console.ReadLine();
                Console.WriteLine("Enter Location:");
                string location = Console.ReadLine();
                var result = await UserService.UserLogin(id, password, location);
                if(result != null)
                {
                    Console.WriteLine($"Login Succesfull - Username : {result.Username}");
                }
            }
            catch (BlockedUserException Bue)
            {
                Console.WriteLine(Bue.Message);
            }
            catch (LoginFromInvalidLocationException Lfile)
            {
                Console.WriteLine(Lfile.Message);
            }
            catch (AlreadyLoggedInException Ale)
            {
                Console.WriteLine(Ale.Message);
            }
            catch(InvalidPasswordException Ipe)
            {
                Console.WriteLine(Ipe.Message);
            }
            catch(NoUserFoundWithGivenIDException Nuf)
            {
                Console.WriteLine(Nuf.Message);
            }
        }

        public async Task LogoutCustomer()
        {
            try
            {
                Console.WriteLine("Enter Id of User:");
                int id = Convert.ToInt32(Console.ReadLine());
                var result = await UserService.UserLogout(id);
                if (result != null)
                {
                    Console.WriteLine($"{result.Username} Logged Out Successfully!");
                }
            }
            catch (NotLoggedInException Nlie)
            {
                Console.WriteLine(Nlie.Message);
            }
            catch(NoUserFoundWithGivenIDException Nufwgi)
            {
                Console.WriteLine(Nufwgi.Message);
            }
        }
    }
}
