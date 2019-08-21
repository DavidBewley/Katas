using System;

namespace MagicalSquares
{
    class Program
    {
        static void Main()
        {
            SolverFactory factory = new SolverFactory();

            string squareString = "0,0,0,0,0,0,0,0,0";
            Console.WriteLine($"Solving square with string: {squareString}");

            var finalSquare = factory.GetMostEfficientlySolvedSquare(squareString);
            Console.WriteLine(finalSquare.ToString());
            Console.WriteLine($"Solved in {finalSquare.GetNumberOfChanges()} moves!");
            
            Console.WriteLine();
            Console.WriteLine();

            var arraySquare = new[,]
            {
                { 4, 8, 2 },
                { 4, 5, 7 },
                { 6, 1, 6 },
            };
            Console.WriteLine($"Solving square with string: 4,8,2,4,5,7,6,1,6");
            finalSquare = factory.GetMostEfficientlySolvedSquare(arraySquare);
            Console.WriteLine(finalSquare.ToString());
            Console.WriteLine($"Solved in {finalSquare.GetNumberOfChanges()} moves!");

            Console.Read();
        }
    }
}
