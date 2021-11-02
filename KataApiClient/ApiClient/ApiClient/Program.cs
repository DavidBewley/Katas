using System;

namespace ApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var commandInt = ShowMenu();
                if(commandInt == 6)
                    return;
            }
        }

        public static int ShowMenu()
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
    }
}
