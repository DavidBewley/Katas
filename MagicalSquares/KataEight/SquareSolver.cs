namespace MagicalSquares
{
    public class SquareSolver
    {
        public MagicSquare Square { get; set; }

        public SquareSolver(string squareString, ISolvingPattern pattern)
        {
            Square = pattern.ApplyPattern(new MagicSquare(squareString));
        }

        public MagicSquare ReturnSolvedSquare()
            => Square;
    }
}
