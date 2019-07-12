using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace KataSeven
{
    public class PowerCalculator
    {
        public string CalculateSequence(int startingNumber, int exponent,[Optional] bool printFullSequence)
        {
            string finalSequence = "";
            List<string> sequence = new List<string> { startingNumber.ToString() };

            while (finalSequence == "")
            {
                sequence.Add(CalculateNextNumberInSequence(sequence.Last(), exponent));
                finalSequence = SearchForStringSequence(sequence);
            }

            if(printFullSequence)
                Console.WriteLine(CreateStringFromList(sequence));

            return finalSequence;
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

        public string SearchForStringSequence(List<string> sequence)
        {
            if (sequence.Count > 2)
            {
                if (sequence.Last() == sequence[sequence.Count - 2])
                    return sequence.Last();
            }

            if (sequence.Count <= 4)
                return "";

            var remainingSequence = new List<string>(sequence);
            for (int index = 0; index < sequence.Count; index++)
            {
                var compareSequence = new List<string>();
                foreach (var number in remainingSequence)
                {
                    compareSequence.Add(number);
                    if (compareSequence.Count % 2 == 1 || compareSequence.Count < 4)
                        continue;

                    var firstHalfOfCurrentSequence = CreateStringFromList(compareSequence.Take(compareSequence.Count / 2).ToList());
                    var secondHalfOfCurrentSequence = CreateStringFromList(compareSequence.Skip(compareSequence.Count / 2).ToList());
                    if (firstHalfOfCurrentSequence == secondHalfOfCurrentSequence)
                        return firstHalfOfCurrentSequence;
                }
                remainingSequence.RemoveAt(0);
            }
            return "";
        }

        private string CreateStringFromList(List<string> sequence)
        {
            string sequenceAsString = "";
            for (int counter = 0; counter < sequence.Count - 1; counter++)
            {
                sequenceAsString += $"{sequence[counter]},";
            }
            sequenceAsString += sequence.Last();

            return sequenceAsString;
        }
    }
}
