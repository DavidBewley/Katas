using System;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<string> DisplayEmployeeList()
            => (await _employeeApi.GetAllEmployees()).Aggregate("", (current, employee)
                => current + employee);

        public async Task<string> DisplaySingleEmployee(Guid id)
            => (await _employeeApi.GetEmployee(id)).ToString();

        public async Task<string> CreateNewEmployee(Employee employee)
        {
            var responseEmployee = await _employeeApi.CreateEmployee(employee);
            return $"Created Employee!\r\n{responseEmployee}";
        }

        public async Task<string> UpdateEmployee(Employee employee)
        {
            var responseEmployee = await _employeeApi.UpdateEmployee(employee);
            return $"Updated Employee!\r\n{responseEmployee}";
        }

        public async Task<string> DeleteEmployee(Guid id)
        {
            await _employeeApi.DeleteEmployee(id);
            return $"Deleted Employee!";
        }
    }
}
