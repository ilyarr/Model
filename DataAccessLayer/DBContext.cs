using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ninject;

namespace DataAccessLayer
{
    public class DBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        [Inject]
        public DBContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-389S4GT0\SQLEXPRESS;Database=test;TrustServerCertificate=True;Integrated Security=SSPI;");
        }
    }
}
