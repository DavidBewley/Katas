using FluentAssertions;
using KataFive.Clients;
using KataFive.Clients.Implementation;
using KataFive.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace KataFive.Tests
{
    public class IntegrationTests
    {
        private readonly ICalculatorService _client;
        private readonly Random _random;

        public IntegrationTests()
        {
            _client = new CalculatorService();
            _random = new Random();
        }

        [Fact]
        public async void SendAliveRequest_ReturnsMessage()
        {
            var response = await _client.GetAliveRequest();
            response.Should().BeOfType(typeof(string));
            response.Should().Be("Connection successful");
        }

        [Fact]
        public async void SendEchoNumberRequest_ReturnsSameNumber()
        {
            int number = _random.Next(int.MinValue, int.MaxValue);
            var response = await _client.GetEchoNumberRequest(number);
            response.Should().BeOfType(typeof(int));
            response.Should().Be(number);
        }

        [Fact]
        public async void SendAdditionRequest_ReturnsCorrectResult()
        {
            var response = await _client.GetCalculationRequest(2, 2, CalculationType.Addition);
            response.Should().BeOfType(typeof(int));
            response.Should().Be(4);
        }

        [Fact]
        public async void SendAdditionRequestRandom_ReturnsCorrectResult()
        {
            int numberOne = _random.Next(int.MinValue / 2, int.MaxValue / 2);
            int numberTwo = _random.Next(int.MinValue / 2, int.MaxValue / 2);
            int result = numberOne + numberTwo;

            var response = await _client.GetCalculationRequest(numberOne, numberTwo, CalculationType.Addition);
            response.Should().BeOfType(typeof(int));
            response.Should().Be(result);
        }

        [Fact]
        public async void SendSubtractionRequest_ReturnsCorrectResult()
        {
            var response = await _client.GetCalculationRequest(4, 2, CalculationType.Subtraction);
            response.Should().BeOfType(typeof(int));
            response.Should().Be(2);
        }

        [Fact]
        public async void SendMultiplicationRequest_ReturnsCorrectResult()
        {
            var response = await _client.GetCalculationRequest(4, 2, CalculationType.Multiplication);
            response.Should().BeOfType(typeof(int));
            response.Should().Be(8);
        }

        [Fact]
        public async void SendDivisonRequest_ReturnsCorrectResult()
        {
            var response = await _client.GetCalculationRequest(4, 2, CalculationType.Divison);
            response.Should().BeOfType(typeof(int));
            response.Should().Be(2);
        }

        [Fact]
        public async void SendGetCalculationRequest_ReturnsCalculation()
        {
            var response = await _client.GetCalculationProblem();
            response.Should().BeOfType(typeof(Calculation));
            response.Id.Should().NotBe(Guid.Empty);
        }

        [Fact]
        public async void SolveCalculationRequest_ReturnsCorrectResult()
        {
            var response = await _client.SolveCalculationProblem();
            response.Should().BeOfType(typeof(string));
            response.Should().Be("Correct!");
        }
    }
}
