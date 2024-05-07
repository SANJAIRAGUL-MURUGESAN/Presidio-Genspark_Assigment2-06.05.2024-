using CredentialsModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CredentialsAppDALibrary
{
    public interface IRepository<k, T>
    {
        Task<T> Add(T item);
        Task<ICollection<T>> GetAll();
        Task<T> GetByKey(k key);
        Task<T> Update(T item);
        Task<T> Delete(k key);

    }
}
