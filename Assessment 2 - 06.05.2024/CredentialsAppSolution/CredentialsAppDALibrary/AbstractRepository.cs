using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialsAppDALibrary
{
    public abstract class AbstractRepository<K, T> : IRepository<K, T>
    {
        public List<T> items = new List<T>();

        public int GenerateID()
        {
            int Count = items.Count;
            return Count + 1;
        }
        public virtual async Task<T> Add(T item)
        {
            items.Add(item);
            return item;
        }
        public virtual async Task<ICollection<T>> GetAll()
        {
            items.Sort();
            return items;
        }
        public abstract Task<T> Delete(K key);

        public abstract Task<T> GetByKey(K key);

        public abstract Task<T> Update(T item);
    }
}
