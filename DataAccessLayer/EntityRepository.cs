using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private DbContext _context;
        private DbSet<T> _dbSet;


        public EntityRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T Create(T stud)
        {
            _dbSet.Add(stud);
            _context.SaveChanges();

            return stud;
        }

        public T Delete(T stud)
        {
            _dbSet.Remove(stud);
            _context.SaveChanges();

            return stud;
        }

        public IEnumerable<T> Read()
        {
            List<T> people = _dbSet.ToList();
            _context.SaveChanges();

            return people;
        }
    }
}
