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
        public IRepository<Student> repository { set; get; }

        public Logic(IRepository<Student> repository)
        {
            this.repository = repository;
        }

        public void AddStudent(string name, string speciality, string group)
        {
            repository.Create(new Student { Name = name, Group = group, Speciality = speciality });
        }
        public void DeleteStudent(int index)
        {
            repository.Delete(repository.Read().ToList()[index]);
        }
        public List<string> ListOfStudents()
        {
            List<string> list = new List<string>();
            List<Student> students = repository.Read().ToList();

            foreach (Student stud in students)
            {
                list.Add(stud.Name);
                list.Add(stud.Speciality);
                list.Add(stud.Group);
            }
            return list;
        }

        public List<string> GetSpeciality()
        {
            List<Student> students = repository.Read().ToList();

            List<string> names = new List<string>(students
                                         .GroupBy(stud => stud.Speciality)
                                         .Select(g => g.Key));
            return names;
        }
    }
}
