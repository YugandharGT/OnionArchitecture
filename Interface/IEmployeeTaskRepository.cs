using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Interface
{
    public interface IEmployeeTaskRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();

        Task<Employee> GetByIdAsync(int id);

        Task<Employee> InsertAsync(Employee entity);

        Task<Employee> UpdateAsync(Employee entity);

        Task<Employee> RemoveAsync(int id);
    }
}

