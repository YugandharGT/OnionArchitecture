using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.ClientService
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> Add();

        Task<Employee> Edit();

        Task<Employee> Delete();

        Task<Employee> GetById();
    }
}
