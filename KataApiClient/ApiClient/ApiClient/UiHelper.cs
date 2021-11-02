using System;
using ApiClient.Models;

namespace ApiClient
{
    public class UiHelper
    {
        public int ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("===========Employee Client===========");
            Console.WriteLine("=====================================");
            Console.WriteLine("1 - Display all employees");
            Console.WriteLine("2 - Find a single employee by Id");
            Console.WriteLine("3 - Create an employee");
            Console.WriteLine("4 - Update an employee");
            Console.WriteLine("5 - Delete an employee");
            Console.WriteLine("6 - Exit");
            Console.WriteLine();
            Console.WriteLine("Please select an option from the above");

            return int.TryParse(Console.ReadLine(), out var parsedNumber) ? parsedNumber : 0;
        }

        public Guid GetGuidId()
        {
            Console.WriteLine("Please enter the Id of the employee");
            var success = Guid.TryParse(Console.ReadLine(), out Guid parsedId);

            if (success)
                return parsedId;

            Console.WriteLine($"Could not read Id. Ensure it is in the following format: {Guid.Empty}");
            return Guid.Empty;
        }
        
        public Employee GetCreateEmployee()
        {
            var employee = new Employee();
            Console.WriteLine("Please enter the employee name");
            employee.Name = Console.ReadLine();

            Console.WriteLine("Please enter the employee start date");
            var success = DateTime.TryParse(Console.ReadLine(), out DateTime parsedDate);
            if (!success)
            {
                Console.WriteLine($"Could not read the date. Please ensure it is in the following format: {DateTime.Now:dd/MM/yyyy}");
                return null;
            }

            employee.StartDate = parsedDate;
            return employee;
        }

        public Employee GetUpdateEmployee()
        {
            var employee = new Employee();
            Console.WriteLine("Please enter the Id of the employee (This cannot change and must match what is currently in the data store)");
            var idSuccess = Guid.TryParse(Console.ReadLine(), out Guid parsedId);
            if (!idSuccess)
            {
                Console.WriteLine($"Could not read Id. Ensure it is in the following format: {Guid.Empty}");
                return null;
            }
            employee.Id = parsedId;

            Console.WriteLine("Please enter the new employee name");
            employee.Name = Console.ReadLine();

            Console.WriteLine("Please enter the new employee start date");
            var success = DateTime.TryParse(Console.ReadLine(), out DateTime parsedDate);
            if (!success)
            {
                Console.WriteLine($"Could not read the date. Please ensure it is in the following format: {DateTime.Now:dd/MM/yyyy}");
                return null;
            }

            employee.StartDate = parsedDate;
            return employee;
        }
    }
}
