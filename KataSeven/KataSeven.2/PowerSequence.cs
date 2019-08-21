using System;
using System.Collections.Generic;
using System.Linq;

namespace KataSeven._2
{
    public class PowerSequence
    {
        private readonly List<string> _sequence;
        private readonly int _exponent;

        public PowerSequence(int startingNumber, int exponent)
        {
            _exponent = exponent;
            _sequence = new List<string> { startingNumber.ToString() };
        }

        private PowerSequence(List<string> sequence, int exponent)
        {
            _sequence = sequence;
            _exponent = exponent;
        }

        public PowerSequence CalculateNextNumber()
        {
            _sequence.Add(CalculateNextNumberInSequence(_sequence.Last(), _exponent));
            return new PowerSequence(_sequence, _exponent);
        }

        private string CalculateNextNumberInSequence(string number, int exponent)
        {
            List<char> digits = number.ToList();
            int nextNumber = 0;
            foreach (char digit in digits)
            {
                int intChar = int.Parse(digit.ToString());
                nextNumber += (int)Math.Pow(intChar, exponent);
            }
            return nextNumber.ToString();
        }

        public List<string> GetPowerSequence()
        {
            return _sequence;
        }
    }
}
