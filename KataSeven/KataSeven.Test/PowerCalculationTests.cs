using System;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace KataSeven.Test
{
    public class PowerCalculationTests
    {
        private readonly PowerCalculator _calculator;
        public PowerCalculationTests()
        {
            _calculator = new PowerCalculator();
        }

        [Theory]
        [InlineData(420,3,"153")]
        [InlineData(13,2,"1")]
        public void PowerCalculateCanReturnRepeatingNumber(int startNumber,int exponent,string solution)
        {
            _calculator.CalculateSequence(startNumber, exponent).Should().Be(solution);
        }

        [Theory]
        [InlineData(420, 4, "13139,6725,4338,4514,1138,4179,9219")]
        [InlineData(20, 2, "20,4,16,37,58,89,145,42")]
        public void PowerCalculateCanReturnSequence(int startNumber, int exponent, string solution)
        {
            _calculator.CalculateSequence(startNumber, exponent).Should().Be(solution);
        }

        [Fact]
        public void SequenceCanBeFound()
        {
            var searchSequence = new List<string> { "1", "2", "3", "4", "1", "2", "3", "4" };
            string returnSequence = _calculator.SearchForStringSequence(searchSequence);
            returnSequence.Should().Be("1,2,3,4");
        }

        [Fact]
        public void SequenceCanBeFoundWithRougeNumbersAtStart()
        {
            var searchSequence = new List<string> { "10", "9", "1", "2", "3", "4", "1", "2", "3", "4" };
            string returnSequence = _calculator.SearchForStringSequence(searchSequence);
            returnSequence.Should().Be("1,2,3,4");
        }

        [Fact]
        public void SequenceCanBeFoundWithOddNumberOfItems()
        {
            var searchSequence = new List<string> { "6", "10", "9", "1", "2", "3", "4", "1", "2", "3", "4" };
            string returnSequence = _calculator.SearchForStringSequence(searchSequence);
            returnSequence.Should().Be("1,2,3,4");
        }
    }
}
