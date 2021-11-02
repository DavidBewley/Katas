using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiClient.Models;

namespace ApiClient.Repositories
{
    public interface IEmployeeApi
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployee(Guid id);
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task DeleteEmployee(Guid id);
    }
}
