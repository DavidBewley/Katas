using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KataFive.Models;
using Newtonsoft.Json;

namespace KataFive.Clients.Implementation
{
    public class CalculatorService : ICalculatorService
    {
        private readonly HttpClient _client;

        public CalculatorService()
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri("Https://DavidBewley.co.uk/api/")
            };
        }

        public CalculatorService(string baseUrl)
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public async Task<string> GetAliveRequest()
        {
            var response = await _client.GetAsync("alive");
            if (response.StatusCode == HttpStatusCode.OK)
                return await response.Content.ReadAsStringAsync();

            return null;
        }

        public async Task<Calculation> GetCalculationProblem()
        {
            var response = await _client.GetAsync("calculation/getcalculationproblem");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                Calculation calculation = new Calculation();
                calculation.Id = Guid.Parse(responseString.Split("\r\n")[0]);
                calculation.Operator = DetermineOperator(responseString);
                responseString = responseString.Split("\r\n")[1];
                calculation.FirstNumber = int.Parse(responseString.Split('+', '-', '/', '*')[0].Trim());
                calculation.SecondNumber = int.Parse(responseString.Split('+', '-', '/', '*')[1].Trim());

                return calculation;
            }

            return null;
        }

        public async Task<int> GetCalculationRequest(int numberOne, int numberTwo, CalculationType calculationType)
        {
            string endpoint = DetermineEndpoint(calculationType);
            var response = await _client.GetAsync($"calculation/{endpoint}?numberone={numberOne}&numbertwo={numberTwo}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                return int.Parse(stringResponse);
            }

            throw new Exception(await response.Content.ReadAsStringAsync());
        }

        public async Task<int> GetEchoNumberRequest(int number)
        {
            var response = await _client.GetAsync($"calculation/echonumber?number={number}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                return int.Parse(stringResponse);
            }

            throw new Exception(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> PostCalculationResponse(CalculationResponse calcResponse)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri($"{_client.BaseAddress}calculation/SubmitSolution"));
            var json = JsonConvert.SerializeObject(calcResponse);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> SolveCalculationProblem()
        {
            Calculation calc = await GetCalculationProblem();
            CalculationResponse calcResponse = await GenerateCalculationResponse(calc);
            return await PostCalculationResponse(calcResponse);
        }

        private string DetermineEndpoint(CalculationType calculationType)
        {
            switch (calculationType)
            {
                case CalculationType.Addition:
                    return "Addition";
                case CalculationType.Subtraction:
                    return "Subtraction";
                case CalculationType.Divison:
                    return "Divison";
                case CalculationType.Multiplication:
                    return "Multiplication";
            }
            return "";
        }

        private CalculationType DetermineOperator(string input)
        {
            if (input.Contains("+"))
                return CalculationType.Addition;
            if (input.Contains("-"))
                return CalculationType.Subtraction;
            if (input.Contains("*"))
                return CalculationType.Multiplication;
            return CalculationType.Divison;
        }

        public async Task<CalculationResponse> GenerateCalculationResponse(Calculation calculation)
        {
            int result = await GetCalculationRequest(calculation.FirstNumber, calculation.SecondNumber,
                calculation.Operator);

            return new CalculationResponse(calculation.Id, result);
        }
    }
}
