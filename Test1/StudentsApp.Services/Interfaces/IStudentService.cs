using StudentsApp.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsApp.Services.Interfaces
{
    public interface IStudentService
    {
        List<Student> GetAll();
        Student GetById(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(int studentId);
    }
}
