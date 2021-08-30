using StudentsApp.Persistence.Interfaces;
using StudentsApp.Persistence.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StudentsApp.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        [XmlArray("StudentList"), XmlArrayItem(typeof(Student), ElementName = "Students")]
        public List<Student> StudentList { get; set; }

        public void Add(Student student)
        {
            StudentList = GetAll().ToList();

            var increment = 0;

            if (StudentList.Count > 0)
            {
                increment = StudentList.Max(x => x.StudentId) + 1;
            }
            else
            {
                increment = 1;
            }

            student.StudentId = increment;

            StudentList.Add(student);

            XmlSerializer writer = new XmlSerializer(typeof(List<Student>));

            var path = Environment.CurrentDirectory + "//Students.xml";
            using (FileStream file = System.IO.File.Create(path))
            {
                writer.Serialize(file, StudentList);
            };
        }

        public void Delete(int id)
        {
            StudentList = GetAll().ToList();

            var updatedStudent = StudentList.FirstOrDefault(x => x.StudentId == id);

            StudentList.Remove(updatedStudent);

            XmlSerializer writer = new XmlSerializer(typeof(List<Student>));

            var path = Environment.CurrentDirectory + "//Students.xml";
            using (FileStream file = System.IO.File.Create(path))
            {
                writer.Serialize(file, StudentList);
            };
        }

        public IEnumerable<Student> GetAll()
        {
            if (!File.Exists(Environment.CurrentDirectory + "//Students.xml"))
            {
                StudentList = new List<Student>();
                return StudentList;
            }

            string xml = File.ReadAllText(Environment.CurrentDirectory + "//Students.xml");
            var serializer = new XmlSerializer(typeof(List<Student>));
            List<Student> result;

            using (TextReader reader = new StringReader(xml))
            {
                result = (List<Student>)serializer.Deserialize(reader);
            }

            return result;
        }

        public void Update(Student student)
        {
            StudentList = GetAll().ToList();

            var updatedStudent = StudentList.FirstOrDefault(x => x.StudentId == student.StudentId);

            StudentList.Remove(updatedStudent);

            updatedStudent.Name = student.Name;
            updatedStudent.Surname = student.Surname;
            updatedStudent.CellNumber = student.CellNumber;
            updatedStudent.EmailAddress = student.EmailAddress;
            updatedStudent.IDNumber = student.IDNumber;

            StudentList.Add(student);

            XmlSerializer writer = new XmlSerializer(typeof(List<Student>));

            var path = Environment.CurrentDirectory + "//Students.xml";
            using (FileStream file = System.IO.File.Create(path))
            {
                writer.Serialize(file, StudentList);
            };
        }
    }
}
