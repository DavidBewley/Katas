using System;

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

        public string GetOperatorShortForm()
        {
            switch (Operator)
            {
                case CalculationType.Addition:
                    return "+";
                case CalculationType.Subtraction:
                    return "-";
                case CalculationType.Multiplication:
                    return "*";
                case CalculationType.Divison:
                    return "/";
                default:
                    return null;
            }
        }
    }
}
