using System;
using System.Collections.Generic;
using System.Text;

namespace KataFive.Models
{
    public class Calculation
    {
        public Guid Id { get; set; }
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public CalculationType Operator { get; set; }

        public Calculation()
        {

        }

        public Calculation(Guid id, int first, int second, CalculationType op)
        {
            Id = id;
            FirstNumber = first;
            SecondNumber = second;
            Operator = op;
        }

        public CalculationResponse GenerateCalculationResponse()
        {
            int result = 0;
            switch (Operator)
            {
                case CalculationType.Addition:
                    result = FirstNumber + SecondNumber;
                    break;
                case CalculationType.Subtraction:
                    result = FirstNumber - SecondNumber;
                    break;
                case CalculationType.Divison:
                    result = FirstNumber / SecondNumber;
                    break;
                case CalculationType.Multiplication:
                    result = FirstNumber * SecondNumber;
                    break;
            }

            return new CalculationResponse(Id, result);
        }
    }
}
