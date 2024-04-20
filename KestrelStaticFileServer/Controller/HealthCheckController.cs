using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KestrelStaticFileServer.Controller;

[ApiController]
public class HealthCheckController: Microsoft.AspNetCore.Mvc.Controller
{
    [HttpGet]
    [Route("/health")]
    public async Task<IActionResult> Get()
    {
        return Ok("OK");
    }
}