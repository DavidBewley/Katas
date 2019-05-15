using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorApi.Models;
using CalculatorApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly ICalculationService _calculationService;

        public CalculationController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        [HttpGet]
        public IActionResult EchoNumber([FromQuery]string number)
        {
            try
            {
                return Ok(int.Parse(number));
            }
            catch
            {
                return BadRequest("Please ensure to send a valid integer");
            }
        }

        [HttpGet]
        public IActionResult Addition([FromQuery]string numberOne, [FromQuery]string numberTwo)
        {
            try
            {
                return Ok(int.Parse(numberOne) + int.Parse(numberTwo));
            }
            catch
            {
                return BadRequest("Please ensure 2 valid integers are sent");
            }
        }

        [HttpGet]
        public IActionResult Subtraction([FromQuery]string numberOne, [FromQuery]string numberTwo)
        {
            try
            {
                return Ok(int.Parse(numberOne) - int.Parse(numberTwo));
            }
            catch
            {
                return BadRequest("Please ensure 2 valid integers are sent");
            }
        }

        [HttpGet]
        public IActionResult Divison([FromQuery]string numberOne, [FromQuery]string numberTwo)
        {
            try
            {
                return Ok(int.Parse(numberOne) / int.Parse(numberTwo));
            }
            catch
            {
                return BadRequest("Please ensure 2 valid integers are sent");
            }
        }

        [HttpGet]
        public IActionResult Division([FromQuery]string numberOne, [FromQuery]string numberTwo)
        {
            try
            {
                return Ok(int.Parse(numberOne) / int.Parse(numberTwo));
            }
            catch
            {
                return BadRequest("Please ensure 2 valid integers are sent");
            }
        }

        [HttpGet]
        public IActionResult Multiplication([FromQuery]string numberOne, [FromQuery]string numberTwo)
        {
            try
            {
                return Ok(int.Parse(numberOne) * int.Parse(numberTwo));
            }
            catch
            {
                return BadRequest("Please ensure 2 valid integers are sent");
            }
        }

        [HttpGet]
        public IActionResult GetCalculationProblem()
        {
            var problem = _calculationService.GenerateNewProblem();
            return Ok($"{problem.Id}\r\n{problem.NumberOne} + {problem.NumberTwo}");
        }

        [HttpPost]
        public IActionResult SubmitSolution([FromBody] CalculationSolution solution)
        {
            if (solution.Id == Guid.Empty || solution.SolutionNumber == 0)
                return BadRequest("Please ensure your solution Id and number are correct");

            var calculationProblem = _calculationService.FindCalculationProblem(solution.Id);
            if (calculationProblem == null)
                return BadRequest("Could not find a calculation problem with this Id");

            if (calculationProblem.Solution == solution.SolutionNumber)
            {
                _calculationService.RemoveCalculation(calculationProblem.Id);
                return Ok("Correct!");
            }

            return Ok("Solution number is incorrect!");
        }

        [HttpGet]
        public IActionResult ClearAllCalculations()
        {
            var problem = _calculationService.GenerateNewProblem();
            _calculationService.RemoveAllCalculations();
            return Ok($"List should now be clear - Calculation was generated before list cleared:\r\n{problem.Id}");
        }

        [HttpGet]
        public IActionResult CheckCalculationExists(Guid id)
        {
            bool result =_calculationService.CheckCalculationIsActive(id);
            return Ok($"{id} - Active: {result}");
        }
    }
}