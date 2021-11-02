using System;
using System.Collections.Generic;
using ApiClient.Models;

namespace ApiClient.Repositories
{
    public interface IEmployeeApi
    {
        List<Employee> GetAllEmployees(); 
        Employee GetEmployee(Guid id);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Guid id);
    }
}
