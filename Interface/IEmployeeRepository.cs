using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Interface
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();

        Task<Employee> GetById(int? id);

        Task<int> Insert(Employee entity);

        Task Update(int id, Employee entity);

        Task<int> Remove(int? id);
    }
}
