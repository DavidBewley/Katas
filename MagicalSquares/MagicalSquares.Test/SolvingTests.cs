using FluentAssertions;
using Xunit;

namespace MagicalSquares.Test
{
    public class SolvingTests
    {
        [Theory]
        [InlineData("4,9,2,3,5,7,8,1,5", 1)]
        [InlineData("4,8,2,4,5,7,6,1,6", 4)]
        [InlineData("4,5,8,2,4,1,1,9,7", 14)]
        [InlineData("2,9,8,4,2,7,5,6,7", 21)]
        [InlineData("4,4,7,3,1,5,1,7,9", 20)]
        [InlineData("2,2,7,8,6,4,1,2,9", 16)]
        [InlineData("7,6,5,7,2,8,5,3,4", 18)]
        [InlineData("6,7,8,7,6,2,3,2,3", 17)]
        [InlineData("0,0,0,0,0,0,0,0,0", 45)]
        public void SolvingSquareIsCompletedInLeastMoves(string squareString, int expectedMovesToSolve)
        {
            SolverFactory factory = new SolverFactory();

            var finishedSquare = factory.GetMostEfficientlySolvedSquare(squareString);

            finishedSquare.GetNumberOfChanges().Should().Be(expectedMovesToSolve);
        }

        [Fact]
        public void SolvingSquareIsCompletedInLeastMovesUsingArray()
        {
            SolverFactory factory = new SolverFactory();
            var arraySquare = new[,]
            {
                { 4, 8, 2 },
                { 4, 5, 7 },
                { 6, 1, 6 },
            };

            var finishedSquare = factory.GetMostEfficientlySolvedSquare(arraySquare);

            finishedSquare.GetNumberOfChanges().Should().Be(4);
        }
    }
}
