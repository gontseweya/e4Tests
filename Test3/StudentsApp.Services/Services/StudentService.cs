using StudentsApp.Persistence.Interfaces;
using StudentsApp.Persistence.Models;
using StudentsApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsApp.Services.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public void Add(Student student)
        {
            _studentRepository.Add(student);
        }

        public void Delete(int studentId)
        {
            _studentRepository.Delete(studentId);
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll().ToList();
        }

        public Student GetById(int id)
        {
            return _studentRepository.GetAll().FirstOrDefault(x => x.StudentId == id);
        }

        public void Update(Student student)
        {
            _studentRepository.Update(student);
        }
    }
}
