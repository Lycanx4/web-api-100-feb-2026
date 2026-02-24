using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers;

public class StatusController : ControllerBase
{
    [HttpGet("/status")]
    public async Task<ActionResult> GetTheStatusAsync()
    {
        return Ok("Look Good");
    }
}
