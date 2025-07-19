using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SecretController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult GetSecret()
    {
        return Ok("This is a protected secret message.");
    }
}
