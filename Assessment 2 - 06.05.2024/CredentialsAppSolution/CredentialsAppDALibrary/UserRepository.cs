using CredentialsModelLibrary;

namespace CredentialsAppDALibrary
{
    public class UserRepository : AbstractRepository<int, User>
    {
        public override async Task<User> Delete(int key)
        {
            User user = await GetByKey(key);
            if (user != null)
            {
                items.Remove(user);
                return user;
            }
            return null;
        }

        public override async Task<User> GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            return null;
        }

        public override async Task<User> Update(User user)
        {
            int index = items.FindIndex((element) => element.Id == user.Id);
            if (index != -1)
            {
                items[index] = user;
                return user;
            }
            return null;
        }
    }
}
