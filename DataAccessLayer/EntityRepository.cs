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

        public async Task<T> Create(T stud)
        {
            await _dbSet.AddAsync(stud);
            await _context.SaveChangesAsync();

            return stud;
        }

        public async Task<T> Delete(T stud)
        {
            _dbSet.Remove(stud);
            await _context.SaveChangesAsync();

            return stud;
        }

        public IEnumerable<T> Read()
        {
            List<T> people = _dbSet.ToList();
            _context.SaveChangesAsync();

            return people;
        }
    }
}
