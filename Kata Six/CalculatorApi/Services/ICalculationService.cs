using CalculatorApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorApi.Services
{
    public interface ICalculationService
    {
        CalculationProblem GenerateNewProblem();
        CalculationProblem FindCalculationProblem(Guid id);
        bool RemoveCalculation(Guid id);
        bool CheckCalculationIsActive(Guid id);
        void RemoveAllCalculations();
    }
}