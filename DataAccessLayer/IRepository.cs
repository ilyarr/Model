using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRepository<T>
    {
        Task<T> Create(T person);
        IEnumerable<T> Read();
        Task<T> Delete(T person);
    }
}
