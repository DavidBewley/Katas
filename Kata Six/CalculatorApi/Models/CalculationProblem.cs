using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorApi.Models
{
    public class CalculationProblem
    {
        public Guid Id { get; set; }
        public int NumberOne { get; set; }
        public int NumberTwo { get; set; }
        public int Solution { get; set; }

        public CalculationProblem()
        {

        }

        public CalculationProblem(bool newProblem)
        {
            if (newProblem)
            {
                Random rnd = new Random();
                Id = Guid.NewGuid();
                NumberOne = rnd.Next(1, 999);
                NumberTwo = rnd.Next(1, 999);
                Solution = NumberOne + NumberTwo;
            }
        }
    }
}
