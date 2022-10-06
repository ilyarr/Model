using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer;

namespace BusinessLogic
{
    public class Logic
    {
        //public IRepository<Student> repository = new EntityRepository<Student>(new DBContext());
        public IRepository<Student> repository = new DapperRepository();

        //List<Student> students = new List<Student>();
        public void AddStudent(string name, string speciality, string group)
        {
            //students.Add(new Student { Name = name, Group = group, Speciality = speciality });
            Task.Run(() => repository.Create(new Student { Name = name, Group = group, Speciality = speciality }));
        }
        public void DeleteStudent(int index)
        {
            //Student stud = students[index];
            Task.Run(() => repository.Delete(repository.Read().ToList()[index]));
            //students.Remove(students[index]);            
        }
        public List<string> ListOfStudents()
        {
            List<string> list = new List<string>();

            foreach (Student stud in repository.Read().ToList())
            {
                list.Add(stud.Name);
                list.Add(stud.Speciality);
                list.Add(stud.Group);
            }
            return list;
        }

        public List<string> GetSpeciality()
        {
            List<string> names = new List<string>(repository.Read()
                                         .GroupBy(stud => stud.Speciality)
                                         .Select(g => g.Key)
                                         .ToList());
            return names;
        }
    }
}
