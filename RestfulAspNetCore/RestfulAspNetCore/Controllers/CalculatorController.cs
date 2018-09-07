using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestfulAspNetCore.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {

        // GET api/values/5
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(result.ToString());


            }
            return BadRequest("Invalid input.");
        }

        // GET api/values/5
        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Subtract(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(result.ToString());

            }
            return BadRequest("Invalid input.");
        }

        // GET api/values/5
        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Divide(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber) && !IsZero(secondNumber))
            {
                var result = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(result.ToString());

            }
            return BadRequest("Invalid input.");
        }

        [HttpGet("square/{firstNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var result = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(result.ToString());

            }
            return BadRequest("Invalid input.");
        }

        private bool IsZero(string secondNumber)
        {
            return Convert.ToDecimal(secondNumber) == 0;
        }

        [HttpGet("mul/{firstNumber}/{secondNumber}")]
        public IActionResult Multiply(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var result = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(result.ToString());

            }
            return BadRequest("Invalid input.");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue = 0;

            if(decimal.TryParse(number, out decimalValue)){
                return decimalValue;
            }

            return 0;
        }

        private bool IsNumeric(string number)
        {
            double numberValue;
            bool isNumber = double.TryParse(number, System.Globalization.NumberStyles.Any,
                                            System.Globalization.NumberFormatInfo.InvariantInfo, out numberValue);

            return isNumber;
        }
    }
}
