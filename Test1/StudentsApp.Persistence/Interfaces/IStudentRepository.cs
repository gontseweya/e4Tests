using StudentsApp.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsApp.Persistence.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
    }
}
