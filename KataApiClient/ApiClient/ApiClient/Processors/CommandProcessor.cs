using System;
using System.Collections.Generic;
using ApiClient.Models;
using ApiClient.Repositories;

namespace ApiClient.Processors
{
    public class CommandProcessor
    {
        private readonly IEmployeeApi _employeeApi;

        public CommandProcessor(IEmployeeApi employeeApi)
        {
            _employeeApi = employeeApi;
        }

        public List<Employee> GetEmployeeList() 
            => _employeeApi.GetAllEmployees();

        public Employee GetEmployee(Guid id) 
            => _employeeApi.GetEmployee(id);

        public void CreateEmployee(Employee employee) 
            => _employeeApi.CreateEmployee(employee);

        public void UpdateEmployee(Employee employee)
            => _employeeApi.UpdateEmployee(employee);

        public void DeleteEmployee(Guid id)
            => _employeeApi.DeleteEmployee(id);
    }
}
