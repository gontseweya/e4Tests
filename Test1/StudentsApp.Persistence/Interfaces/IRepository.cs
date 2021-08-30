using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentsApp.Persistence.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        void Add(T p);

        void Update(T p);

        void Delete(int id);
    }
}
