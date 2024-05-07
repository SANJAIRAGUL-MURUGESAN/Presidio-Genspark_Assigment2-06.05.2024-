using CredentialsModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialsBLLibrary
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(User user);
        Task<User> GetByKey(int key);
        Task<ICollection<User>> GetAll();
        Task<User> UserLogin(int key,string password,string location);
        Task<User> UserLogout(int key);
    }
}
