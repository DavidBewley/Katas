using System;
using System.Threading.Tasks;
using ApiClient.Processors;
using ApiClient.Repositories;

namespace ApiClient
{
    class Program
    {
        static async Task Main()
        {
            var ui = new UiHelper();
            var employeeApi = new EmployeeApi("http://51.148.170.137:9111/");
            var processor = new CommandProcessor(employeeApi);

            while (true)
            {
                var commandInt = ui.ShowMenu();
                switch (commandInt)
                {
                    case 6:
                        return;

                    case 1:
                        Console.WriteLine(await processor.DisplayEmployeeList());
                        break;
                    case 2:
                        var getId = ui.GetGuidId();
                        if (getId != Guid.Empty)
                            Console.WriteLine(await processor.DisplaySingleEmployee(getId));
                        break;
                    case 3:
                        var createEmployee = ui.GetCreateEmployee();
                        if (createEmployee != null)
                            Console.WriteLine(await processor.CreateNewEmployee(createEmployee));
                        break;
                    case 4:
                        var updateEmployee = ui.GetUpdateEmployee();
                        if (updateEmployee != null)
                            Console.WriteLine(await processor.UpdateEmployee(updateEmployee));
                        break;
                    case 5:
                        var deleteId = ui.GetGuidId();
                        if (deleteId != Guid.Empty)
                            Console.WriteLine(await processor.DeleteEmployee(deleteId));
                        break;
                }

                Console.WriteLine("Press enter to continue");
                Console.ReadKey();
            }
        }
    }
}
