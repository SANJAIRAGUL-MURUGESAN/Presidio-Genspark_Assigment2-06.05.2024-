using CredentialsAppDALibrary;
using CredentialsModelLibrary;
using CredentialsModelLibrary.UserExceptions;

namespace CredentialsBLLibrary
{
    public class UserBL : IUserService
    {
        readonly IRepository<int, User> _UserRepository;
        List<String> AllowedLocations = new List<String>();
        List<int> AlreadyLoggedInUsers = new List<int>();
        public UserBL(IRepository<int, User> userRepository)
        {
            _UserRepository = userRepository;
            AllowedLocations.Add("Coimbatore");
            AllowedLocations.Add("Chennai");
        }

        public async Task<User> AddUser(User user)
        {
            var list = await _UserRepository.GetAll();
            foreach (var item in list)
            {
                if (item.Username == user.Username)
                {
                    throw new UserAlreadyRegisteredException();
                }
            }
            for (int i = 0; i < AllowedLocations.Count; i++)
            {
                if (AllowedLocations[i] == user.Location)
                {
                    _UserRepository.Add(user);
                    return user;
                }
            }
            throw new RegisteringFromInvalidLocation();
        }   
 

        public async Task<User> UserLogin(int key,string password,string location)
        {
            var list = await _UserRepository.GetByKey(key);
            if(list != null)
            {
                if(list.IncorrectAttempt > 3)
                {
                    throw new BlockedUserException();
                }
                int Flag = 0;
                for (int i = 0; i < AllowedLocations.Count; i++)
                {
                    if (AllowedLocations[i] == location)
                    {
                        Flag = 1; break;
                    }
                }
                if(Flag == 0)
                {
                    list.IncorrectAttempt = list.IncorrectAttempt + 1;
                    throw new LoginFromInvalidLocationException();
                }
                else
                {
                    int Flag2 = 0;
                    for(int j = 0; j < AlreadyLoggedInUsers.Count; j++)
                    {
                        if (AlreadyLoggedInUsers[j] == key)
                        {
                            list.IncorrectAttempt = list.IncorrectAttempt + 1;
                            Flag2 = 1; break;
                            
                        }
                    }
                    if(Flag2 == 1)
                    {
                        throw new AlreadyLoggedInException();
                    }
                    else
                    {
                        if (password == list.Password)
                        {
                            list.IncorrectAttempt = 0;
                            AlreadyLoggedInUsers.Add(key);
                            return list;
                        }
                        else
                        {
                            list.IncorrectAttempt = list.IncorrectAttempt + 1;
                            throw new InvalidPasswordException();
                        }
                    }
                }
            }
            throw new NoUserFoundWithGivenIDException();
        }

        public async Task<User> UserLogout(int key)
        {
            var result = await _UserRepository.GetByKey(key);
            if(result != null)
            {
                int Flag = 0;
                for (int j = 0; j < AlreadyLoggedInUsers.Count; j++)
                {
                    if (AlreadyLoggedInUsers[j] == result.Id)
                    {
                        Flag = 1;
                        break;
                    }
                }
                if (Flag == 1)
                {
                    AlreadyLoggedInUsers.Remove(result.Id);
                    return result;
                }
                throw new NotLoggedInException();
            }
            throw new NoUserFoundWithGivenIDException();
        }

        public async Task<User> DeleteUser(User user)
        {
            var Deleted_User = await _UserRepository.Delete(user.Id);
            if (Deleted_User != null) {
                return Deleted_User;
            }
            throw new NoUserFoundWithGivenIDException();
        }

        public async Task<User> GetByKey(int key)
        {
            var user = await _UserRepository.GetByKey(key);
            if (user != null)
            {
                return user;
            }
            throw new NoUserFoundWithGivenIDException();
        }

        public async Task<ICollection<User>> GetAll()
        {
            var result = await _UserRepository.GetAll();
            if(result != null)
            {
                return result;
            }
            throw new NoUserFoundException();
        }

        public async Task<User> UpdateUser(User user)
        {
            var Updated_User = await _UserRepository.Update(user);
            if (user != null)
            {
                return Updated_User;
            }
            throw new NoUserFoundWithGivenIDException();
        }
    }
}
