using System;

namespace KataSeven
{
    class Program
    {
        static void Main(string[] args)
        {
            PowerCalculator calculator = new PowerCalculator();

            Console.WriteLine("Number: 420, Exponent: 3");
            string answer = calculator.CalculateSequence(420, 3);
            Console.WriteLine($"Output: {answer}");
            Console.WriteLine();

            Console.WriteLine("Number: 420, Exponent: 4");
            answer = calculator.CalculateSequence(420, 4);
            Console.WriteLine($"Output: {answer}");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
