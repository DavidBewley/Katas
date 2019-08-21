using System;

namespace MagicalSquares
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Magical Squares!");
            string squareString = "0,0,0,0,0,0,0,0,0";

            SolverFactory factory = new SolverFactory();
            var finalSquare = factory.GetMostEfficientlySolvedSquare(squareString);
            Console.WriteLine($"Solved in {finalSquare.GetNumberOfChanges()} moves!");
            
            Console.Read();
        }
    }
}
