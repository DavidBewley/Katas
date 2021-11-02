using System;
using System.Collections.Generic;
using ApiClient.Models;
using Bogus;

namespace EmployeeTests
{
    public class EmployeeSeed
    {
        private readonly Faker<Employee> _employeeFaker = new Faker<Employee>()
            .RuleFor(e => e.Id, Guid.NewGuid())
            .RuleFor(e => e.Name, f => f.Name.FullName())
            .RuleFor(e => e.StartDate, f => f.Date.Recent(3650));

        public List<Employee> GetDetailedEmployeeList(int numberToGenerate) 
            => _employeeFaker.Generate(numberToGenerate);

        public Employee GetDetailedEmployeeWithId(Guid id)
        {
            var employee = _employeeFaker.Generate();
            employee.Id = id;
            return employee;
        }

        public Employee GetSingleEmployee() 
            => _employeeFaker.Generate();

    }
}
