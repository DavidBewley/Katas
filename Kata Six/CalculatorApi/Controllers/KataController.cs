using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers
{
    [Route("[controller]/[action]")]
    public class KataController : Controller
    {
        [HttpGet]
        public IActionResult KataFive()
        {
            return View();
        }
    }
}