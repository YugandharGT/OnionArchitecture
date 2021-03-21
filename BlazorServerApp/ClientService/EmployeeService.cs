using Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorServerApp.ClientService
{
    public class EmployeeService : IEmployeeService
    {
        public readonly HttpClient httpClient;
        readonly static string url= "api/Employee/";

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Employee> Add()//Employee employee
        {
            return await httpClient.GetJsonAsync<Employee>(url);
        }

        public async Task<Employee> Delete()
        {
            int id=0;
            return await httpClient.GetJsonAsync<Employee>(string.Concat(url,id));
        }

        public async Task<Employee> Edit()
        {
            int id = 0;//, Employee employee
            return await httpClient.GetJsonAsync<Employee>(string.Concat(url, id));
        }

        public async Task<Employee> GetById()
        {
            int id = 0;
            return await httpClient.GetJsonAsync<Employee>(string.Concat(url, id));
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetJsonAsync<Employee[]>(string.Concat(url));
        }
    }
}
