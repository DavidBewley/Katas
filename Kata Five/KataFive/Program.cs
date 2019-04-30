using KataFive.Clients;
using KataFive.Clients.Implementation;
using KataFive.Models;
using System;
using System.Threading.Tasks;

namespace KataFive
{
    static class Program
    {
        public static ICalculatorService CalculatorService;
        static void Main()
        {
            MainAsync().Wait();
        }

        public static async Task MainAsync()
        {
            CalculatorService = new CalculatorService("Https://DavidBewley.co.uk/api/");

            Console.WriteLine($"Sending Alive Request: {await CalculatorService.GetAliveRequest()}");
            Console.WriteLine($"Sending Echo Request (5): {await CalculatorService.GetEchoNumberRequest(5)}");
            Console.WriteLine();
            Console.WriteLine($"Sending Addition Request (5+12): {await CalculatorService.GetCalculationRequest(5, 12, CalculationType.Addition)}");
            Console.WriteLine($"Sending Subtraction Request (10-2): {await CalculatorService.GetCalculationRequest(10, 2, CalculationType.Subtraction)}");
            Console.WriteLine($"Sending Multiplication Request (9*2): {await CalculatorService.GetCalculationRequest(9, 2, CalculationType.Multiplication)}");
            Console.WriteLine($"Sending Division Request (12/3): {await CalculatorService.GetCalculationRequest(12, 3, CalculationType.Divison)}");
            Console.WriteLine();

            Console.WriteLine($"Sending Get Calculation Request: ");
            Calculation calculation = await CalculatorService.GetCalculationProblem();
            Console.WriteLine($"{calculation.Id}: {calculation.FirstNumber} {calculation.GetOperatorShortForm()} {calculation.SecondNumber}");

            CalculationResponse response = await CalculatorService.GenerateCalculationResponse(calculation);
            Console.WriteLine($"Sending Solve Calculation Request (Answer: {response.Answer}): {await CalculatorService.PostCalculationResponse(response)}");

            Console.ReadKey();
        }
    }
}
