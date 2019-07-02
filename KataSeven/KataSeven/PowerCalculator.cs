using System;
using System.Collections.Generic;
using System.Linq;

namespace KataSeven
{
    public class PowerCalculator
    {
        public string Calculate(int startingNumber, int exponent)
        {
            string output = "";
            List<string> sequence = new List<string>
            {
                startingNumber.ToString()
            };

            while (output == "")
            {
                sequence.Add(CalculateNextInSequence(sequence.Last(), exponent));
                output = SearchForSequence(sequence);
            }

            return output;
        }

        public string CalculateNextInSequence(string number, int exponent)
        {
            List<char> chars = number.ToList();
            int total = 0;
            foreach (char c in chars)
            {
                int intChar = int.Parse(c.ToString());
                total += (int)Math.Pow(intChar, exponent);
            }
            return total.ToString();
        }

        public string SearchForSequence(List<string> sequence)
        {
            if (sequence.Count() < 2)
                return "";

            if (sequence.Last() == sequence[sequence.Count() - 2])
                return sequence.Last();

            

            return "";
        }
    }
}
