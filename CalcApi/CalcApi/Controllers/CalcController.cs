// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalcApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

[Route("[controller]")]
[ApiController]
public class CalcController : ControllerBase
{
    [HttpGet]
    public ActionResult<decimal> Get(string calc, decimal numberOne, decimal numberTwo)
    {
        try
        {
            if (calc is string && numberOne is decimal && numberTwo is decimal)
            {
                switch (calc)
                {
                    case "plus": return Ok(numberOne + numberTwo);
                    case "minus": return Ok(numberOne - numberTwo);
                    case "divide":
                        if (numberTwo == 0)
                            return BadRequest("Don't divide by zero!");
                        return Ok(numberOne / numberTwo);
                    case "multiply": return Ok(numberOne * numberTwo);
                    default:
                        return BadRequest("Wrong parameters, first input +, -, / or * and then two numbers.");
                }
            }
            return BadRequest("Wrong parameters, first input +, -, / or * and then two numbers.");

        }
        catch (Exception e)
        {

            return BadRequest("Wrong parameters, first input +, -, / or * and then two numbers.");
        }
    }
}
