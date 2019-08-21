using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicalSquares
{
    public class MagicSquare
    {
        private readonly int[,] _squareArray;
        private readonly int _numberOfChanges;

        public MagicSquare(string squareString)
        {
            _squareArray = new int[3, 3];
            int counter = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _squareArray[i, j] = int.Parse(squareString.Split(',')[counter]);
                    counter++;
                }
            }
        }

        public MagicSquare(int[,] squareArray)
        {
            _squareArray = squareArray;
        }

        private MagicSquare(int[,] squareArray, int numberOfChanges)
        {
            _squareArray = squareArray;
            _numberOfChanges = numberOfChanges;
        }

        public int[,] GetSquareState()
            => _squareArray;

        public int GetNumberOfChanges()
            => _numberOfChanges;

        public MagicSquare ChangeValueOfSquareAtLocation(int x, int y, int newValue)
        {
            var newSquareArray = new int[3, 3];
            Array.Copy(_squareArray, 0, newSquareArray, 0, _squareArray.Length);

            newSquareArray[x, y] = newValue;

            int numberOfChangesFromThisAction = 0;

            if (newSquareArray[x, y] > _squareArray[x, y])
                numberOfChangesFromThisAction = newSquareArray[x, y] - _squareArray[x, y];
            else
                numberOfChangesFromThisAction = _squareArray[x, y] - newSquareArray[x, y];

            return new MagicSquare(newSquareArray, _numberOfChanges + numberOfChangesFromThisAction);
        }

        #region ValidStateChecking
        public bool IsMagic()
        {
            if (_squareArray.Cast<int>().Sum() != 45)
                return false;

            var magicTests = new List<bool>()
            {
                ArraySumsTo15(GetRow(0)),
                ArraySumsTo15(GetRow(1)),
                ArraySumsTo15(GetRow(2)),
                ArraySumsTo15(GetCol(0)),
                ArraySumsTo15(GetCol(1)),
                ArraySumsTo15(GetCol(2)),
                ArraySumsTo15(GetDiagonalLeft()),
                ArraySumsTo15(GetDiagonalRight()),
            };

            return !magicTests.Contains(false);
        }

        private bool ArraySumsTo15(int[] array)
            => array.Sum() == 15;

        private int[] GetRow(int rowNumber)
            => new[] { _squareArray[rowNumber, 0], _squareArray[rowNumber, 1], _squareArray[rowNumber, 2] };

        private int[] GetCol(int colNumber)
            => new[] { _squareArray[0, colNumber], _squareArray[1, colNumber], _squareArray[2, colNumber] };

        private int[] GetDiagonalLeft()
            => new[] { _squareArray[0, 0], _squareArray[1, 1], _squareArray[2, 2] };

        private int[] GetDiagonalRight()
            => new[] { _squareArray[0, 2], _squareArray[1, 1], _squareArray[2, 0] };
        #endregion

        public override string ToString()
        {
            string outputString = "---------\r\n";
            for (int i = 0; i < 3; i++)
            {
                outputString += "| ";
                for (int j = 0; j < 3; j++)
                {
                    outputString += $"{_squareArray[i, j]} "
                    ;
                }
                outputString += "|\r\n";
            }

            outputString += "---------";

            return outputString;
        }
    }
}
