using System;

namespace KataSeven._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 420;
            int exponent = 3;

            Console.WriteLine($"Number: {number}");
            Console.WriteLine($"Exponent: {exponent}");
            SequenceFinder finder = new SequenceFinder(number, exponent);
            finder.CalculateFinalSequence();
            Console.WriteLine($"Result: {finder.GetSequenceAsString()}");

            Console.WriteLine();
            Console.WriteLine();

            number = 2;
            exponent = 4;
            Console.WriteLine($"Number: {number}");
            Console.WriteLine($"Exponent: {exponent}");
            finder = new SequenceFinder(number, exponent);
            finder.CalculateFinalSequence();
            Console.WriteLine($"Result: {finder.GetSequenceAsString()}");

            Console.ReadKey();
        }
    }
}
