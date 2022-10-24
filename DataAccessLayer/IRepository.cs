using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccessLayer
{
    public interface IRepository<T> where T: class, IDomainObject
    {
        T Create(T person);
        IEnumerable<T> Read();
        T Delete(T person);
    }
}
