using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StudentsApp.Persistence.Models
{
    [XmlRoot("Student")]
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IDNumber { get; set; }
        public string CellNumber { get; set; }

        public string EmailAddress { get; set; }
    }
}
