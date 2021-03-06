﻿using KataFive.Models;
using System.Threading.Tasks;

namespace KataFive.Clients
{
    public interface ICalculatorService
    {
        Task<string> GetAliveRequest();
        Task<int> GetEchoNumberRequest(int number);
        Task<int> GetCalculationRequest(int numberOne, int numberTwo, CalculationType calculationType);
        Task<Calculation> GetCalculationProblem();
        Task<string> PostCalculationResponse(CalculationResponse calcResponse);
        Task<string> SolveCalculationProblem();
        Task<CalculationResponse> GenerateCalculationResponse(Calculation calculation);
    }
}
