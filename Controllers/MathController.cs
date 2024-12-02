using Microsoft.AspNetCore.Mvc;
using MathFunctions.Models;

[ApiController]
[Route("api/[controller]")]
public class MathController : ControllerBase
{
    [HttpPost("add")]
    public IActionResult Add([FromBody] MathRequest request)
    {
        if (request.Numbers == null || !request.Numbers.Any())
            return BadRequest("The numbers list cannot be empty.");

        var result = request.Numbers.Sum();
        return Ok(new { Result = result });
    }

    [HttpPost("subtract")]
    public IActionResult Subtract([FromBody] MathRequest request)
    {
        if (request.Numbers == null || !request.Numbers.Any())
            return BadRequest("The numbers list cannot be empty.");

        var result = request.Numbers.Aggregate((a, b) => a - b);
        return Ok(new { Result = result });
    }

    [HttpPost("multiply")]
    public IActionResult Multiply([FromBody] MathRequest request)
    {
        if (request.Numbers == null || !request.Numbers.Any())
            return BadRequest("The numbers list cannot be empty.");

        var result = request.Numbers.Aggregate((a, b) => a * b);
        return Ok(new { Result = result });
    }

    [HttpPost("divide")]
    public IActionResult Divide([FromBody] MathRequest request)
    {
        if (request.Numbers == null || !request.Numbers.Any())
            return BadRequest("The numbers list cannot be empty.");

        if (request.Numbers.Contains(0))
            return BadRequest("Division by zero is not allowed.");

        var result = request.Numbers.Aggregate((a, b) => a / b);
        return Ok(new { Result = result });
    }
}