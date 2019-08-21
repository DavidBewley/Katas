using FluentAssertions;
using Xunit;

namespace MagicalSquares.Test
{
    public class SolvingTests
    {
        [Theory]
        [InlineData("4,8,2,4,5,7,6,1,6", 4)]
        [InlineData("4,9,2,3,5,7,8,1,5", 1)]
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
