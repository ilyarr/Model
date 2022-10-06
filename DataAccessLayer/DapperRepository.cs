using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DapperRepository : IRepository<Student>
    {
        string ConnectionString =
            @"Data Source=LAPTOP-389S4GT0\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;Integrated Security=SSPI;";

        public async Task<Student> Create(Student stud)
        {
            using (SqlConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var response = await db.QueryFirstOrDefaultAsync<Student>(
                    @"INSERT INTO [dbo].[Students] ([Name], [Group], [Speciality])
                    VALUES (@Name, @Group, @Speciality)",
                    new { stud.Name, stud.Group, stud.Speciality });
                return response;
            }
        }

        public async Task<Student> Delete(Student stud)
        {
            using (SqlConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var response = await db.QueryFirstOrDefaultAsync<Student>(
                    @"DELETE FROM [dbo].[Students]
                    WHERE ID = @ID",
                    new { stud.ID });
                return response;
            }
        }

        public IEnumerable<Student> Read()
        {
            using (SqlConnection db = new SqlConnection(ConnectionString))
            {
                db.Open();
                var response = db.Query<Student>(@"
                    SELECT * FROM [dbo].[Students]");
                return response;
            }
        }
    }
}
