using System.Collections.Generic;
using System.Linq;

namespace MagicalSquares
{
    public class SolverFactory
    {
        private string _startingString;

        public MagicSquare GetMostEfficientlySolvedSquare(string startingString)
        {
            _startingString = startingString;
            var allSolvers = GenerateAllSolvers();
            var allSquares = allSolvers.Select(s => s.ReturnSolvedSquare()).ToList();

            return allSquares.OrderBy(s => s.GetNumberOfChanges()).FirstOrDefault();
        }

        public MagicSquare GetMostEfficientlySolvedSquare(int[,] startingArray)
        {
            string convertedSquare = "";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    convertedSquare += $"{startingArray[i, j].ToString()},";
                }
            }
            convertedSquare = convertedSquare.TrimEnd(',');

            return GetMostEfficientlySolvedSquare(convertedSquare);
        }

        private List<SquareSolver> GenerateAllSolvers()
            => new List<SquareSolver>
            {
                new SquareSolver(_startingString,new PatternOne()),
                new SquareSolver(_startingString,new PatternTwo()),
                new SquareSolver(_startingString,new PatternThree()),
                new SquareSolver(_startingString,new PatternFour()),
                new SquareSolver(_startingString,new PatternFive()),
                new SquareSolver(_startingString,new PatternSix()),
                new SquareSolver(_startingString,new PatternSeven()),
                new SquareSolver(_startingString,new PatternEight()),
            };
    }
}
