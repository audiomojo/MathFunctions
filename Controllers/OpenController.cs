using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OpenController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("open for business");
    }
}