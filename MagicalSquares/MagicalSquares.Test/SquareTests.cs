using FluentAssertions;
using Xunit;

namespace MagicalSquares.Test
{
    public class SquareTests
    {
        [Fact]
        public void SquareCanBeGeneratedUsingStringConstructor()
        {
            MagicSquare square = new MagicSquare("4,9,2,3,5,7,8,1,5");

            var squareState = square.GetSquareState();

            squareState.Should().HaveCount(9);
            squareState[0, 0].Should().Be(4);
            squareState[1, 0].Should().Be(3);
            squareState[2, 0].Should().Be(8);
            squareState[2, 2].Should().Be(5);
        }

        [Fact]
        public void SquareCanBeGeneratedUsingArrayConstructor()
        {
            MagicSquare square = new MagicSquare(
                new[,]
                {
                    { 4, 9, 2 },
                    { 3, 5, 7 },
                    { 8, 1, 5 },
                });

            var squareState = square.GetSquareState();

            squareState.Should().HaveCount(9);
            squareState[0, 0].Should().Be(4);
            squareState[1, 0].Should().Be(3);
            squareState[2, 0].Should().Be(8);
            squareState[2, 2].Should().Be(5);
        }

        [Theory]
        [InlineData("4,9,2,3,5,7,8,1,5", 5, 1)]
        [InlineData("4,9,2,3,5,7,8,1,5", 9, 5)]
        [InlineData("4,9,2,3,5,7,8,1,5", 3, 1)]
        [InlineData("4,9,2,3,5,7,8,1,5", 4, 0)]
        public void ChangeValueOfSquareReturnsCorrectNumberOfChanges(string stringSequence, int changeValue, int expectedChangeValue)
        {
            MagicSquare square = new MagicSquare(stringSequence);

            square = square.ChangeValueOfSquareAtLocation(0, 0, changeValue);

            square.GetNumberOfChanges().Should().Be(expectedChangeValue);
        }

        [Fact]
        public void MultipleChangesOutputCorrectChangeValue()
        {
            MagicSquare square = new MagicSquare("4,9,2,3,5,7,8,1,5");

            square = square
                .ChangeValueOfSquareAtLocation(0, 0, 5)
                .ChangeValueOfSquareAtLocation(0, 0, 7)
                .ChangeValueOfSquareAtLocation(2, 2, 7);

            square.GetNumberOfChanges().Should().Be(5);
        }

        [Theory]
        [InlineData("8,1,6,3,5,7,4,9,2", true)]
        [InlineData("9,1,6,3,5,7,4,9,2", false)]
        [InlineData("8,1,6,4,5,7,4,9,2", false)]
        [InlineData("8,1,6,3,5,7,5,9,2", false)]
        public void IsMagicReturnsCorrectSquareState(string stringSequence, bool shouldBeMagic)
        {
            MagicSquare square = new MagicSquare(stringSequence);

            bool isMagic = square.IsMagic();

            isMagic.Should().Be(shouldBeMagic);
        }
    }
}
