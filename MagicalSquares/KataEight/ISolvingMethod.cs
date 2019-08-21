namespace MagicalSquares
{
    public static class PatternHelper
    {
        public static MagicSquare ApplyPattern(string patternToMatch, MagicSquare square)
        {
            int counter = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    square = square.ChangeValueOfSquareAtLocation(i, j, int.Parse(patternToMatch.Split(',')[counter]));
                    counter++;
                }
            }

            return square;
        }
    }

    public interface ISolvingPattern
    {
        MagicSquare ApplyPattern(MagicSquare square);
    }

    public class PatternOne : ISolvingPattern
    {
        private readonly string _patternToMatch = "8,1,6,3,5,7,4,9,2";
        public MagicSquare ApplyPattern(MagicSquare square)
            => PatternHelper.ApplyPattern(_patternToMatch, square);
    }

    public class PatternTwo : ISolvingPattern
    {
        private readonly string _patternToMatch = "6,1,8,7,5,3,2,9,4";
        public MagicSquare ApplyPattern(MagicSquare square)
            => PatternHelper.ApplyPattern(_patternToMatch, square);
    }

    public class PatternThree : ISolvingPattern
    {
        private readonly string _patternToMatch = "4,9,2,3,5,7,8,1,6";
        public MagicSquare ApplyPattern(MagicSquare square)
            => PatternHelper.ApplyPattern(_patternToMatch, square);
    }

    public class PatternFour : ISolvingPattern
    {
        private readonly string _patternToMatch = "2,9,4,7,5,3,6,1,8";
        public MagicSquare ApplyPattern(MagicSquare square)
            => PatternHelper.ApplyPattern(_patternToMatch, square);
    }

    public class PatternFive : ISolvingPattern
    {
        private readonly string _patternToMatch = "8,3,4,1,5,9,6,7,2";
        public MagicSquare ApplyPattern(MagicSquare square)
            => PatternHelper.ApplyPattern(_patternToMatch, square);
    }

    public class PatternSix : ISolvingPattern
    {
        private readonly string _patternToMatch = "4,3,8,9,5,1,2,7,6";
        public MagicSquare ApplyPattern(MagicSquare square)
            => PatternHelper.ApplyPattern(_patternToMatch, square);
    }

    public class PatternSeven : ISolvingPattern
    {
        private readonly string _patternToMatch = "6,7,2,1,5,9,8,3,4";
        public MagicSquare ApplyPattern(MagicSquare square)
            => PatternHelper.ApplyPattern(_patternToMatch, square);
    }

    public class PatternEight : ISolvingPattern
    {
        private readonly string _patternToMatch = "2,7,6,9,5,1,4,3,8";
        public MagicSquare ApplyPattern(MagicSquare square)
            => PatternHelper.ApplyPattern(_patternToMatch, square);
    }
}
