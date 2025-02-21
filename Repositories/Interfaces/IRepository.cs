using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> Insert(T entity);
        Task<T> Update(int id, T entity);
        Task<IEnumerable<T>> Get();
    }
}
