using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorApi.Models;

namespace CalculatorApi.Services.Implementation
{
    public class CalculationService : ICalculationService
    {
        private List<CalculationProblem> _calculationProblemList;

        public CalculationService()
        {
            _calculationProblemList = new List<CalculationProblem>();
        }

        public bool CheckCalculationIsActive(Guid id)
        {
            if (_calculationProblemList.Where(c => c.Id == id).ToList().Count > 0)
            {
                return true;
            }
            return false;
        }

        public CalculationProblem FindCalculationProblem(Guid id)
        {
            var calcualtionProblem = _calculationProblemList.FirstOrDefault(c => c.Id == id);
            return calcualtionProblem == null ? null : calcualtionProblem;
        }

        public CalculationProblem GenerateNewProblem()
        {
            var calculation = new CalculationProblem(true);
            _calculationProblemList.Add(calculation);
            return calculation;
        }

        public void RemoveAllCalculations()
        {
            _calculationProblemList.Clear();
        }

        public bool RemoveCalculation(Guid id)
        {
            var calculationProblem = _calculationProblemList.FirstOrDefault(c => c.Id == id);
            if (calculationProblem == null)
                return false;

            _calculationProblemList.Remove(calculationProblem);
            return true;
        }
    }
}
