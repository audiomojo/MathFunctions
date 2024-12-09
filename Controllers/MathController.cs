using Microsoft.AspNetCore.Mvc;
using MathFunctions.Models;
using System.Numerics;

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

    [HttpPost("power")]
    public IActionResult Power([FromBody] PowerRequest request)
    {
        if (request.Base == 0 && request.Power == 0)
            return BadRequest("0 to the power of 0 is undefined.");

        var result = Math.Pow(request.Base, request.Power);

        if (double.IsInfinity(result))
            return BadRequest("The result is too large to be represented as a valid JSON number.");

        return Ok(new { Result = result });
    }

    [HttpPost("fibonacci")]
    public IActionResult Fibonacci([FromBody] FibonacciRequest request)
    {
        if (request.Count < 1 || request.Count > 100)
            return BadRequest("The count must be between 1 and 100.");

        var fibonacciNumbers = GenerateFibonacci(request.Count);
        return Ok(new { Fibonacci = string.Join(",", fibonacciNumbers) });
    }

    private List<BigInteger> GenerateFibonacci(int count)
    {
        var fibonacciNumbers = new List<BigInteger> { 0, 1 };
        for (int i = 2; i < count; i++)
        {
            fibonacciNumbers.Add(fibonacciNumbers[i - 1] + fibonacciNumbers[i - 2]);
        }
        return fibonacciNumbers.Take(count).ToList();
    }
}