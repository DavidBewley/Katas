using FluentAssertions;
using Xunit;

namespace MagicalSquares.Test
{
    public class SolvingTests
    {
        [Theory]
        [InlineData("4,8,2,4,5,7,6,1,6", 4)]
        public void SolvingSquareIsCompletedInLeastMoves(string squareString, int expectedMovesToSolve)
        {
            SolverFactory factory = new SolverFactory();

            var finishedSquare = factory.GetMostEfficientlySolvedSquare(squareString);

            finishedSquare.GetNumberOfChanges().Should().Be(expectedMovesToSolve);
        }
    }
}
