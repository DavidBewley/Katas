using System.Collections.Generic;
using System.Linq;

namespace KataSeven._2
{
    public class SequenceFinder
    {
        public PowerSequence Sequence { get; private set; }
        public string FinalString { get; set; }

        public SequenceFinder(int startingNumber, int exponent)
        {
            Sequence = new PowerSequence(startingNumber, exponent);
        }

        public PowerSequence CalculateFinalSequence()
        {
            string testingSequence = "";
            while (testingSequence == "")
            {
                Sequence = Sequence.CalculateNextNumber();
                testingSequence = SearchForStringSequence(Sequence.GetPowerSequence());
            }

            FinalString = testingSequence;
            return Sequence;
        }

        private string SearchForStringSequence(List<string> sequence)
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

                    var firstHalfOfCurrentSequence = GetSequenceAsString(compareSequence.Take(compareSequence.Count / 2).ToList());
                    var secondHalfOfCurrentSequence = GetSequenceAsString(compareSequence.Skip(compareSequence.Count / 2).ToList());
                    if (firstHalfOfCurrentSequence == secondHalfOfCurrentSequence)
                        return firstHalfOfCurrentSequence;
                }
                remainingSequence.RemoveAt(0);
            }
            return "";
        }

        public string GetSequenceAsString()
        {
            return FinalString;

            var sequence = Sequence.GetPowerSequence();
            string sequenceAsString = "";
            for (int counter = 0; counter < sequence.Count - 1; counter++)
            {
                sequenceAsString += $"{sequence[counter]},";
            }
            sequenceAsString += sequence.Last();

            return sequenceAsString;
        }

        private string GetSequenceAsString(List<string> sequence)
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
