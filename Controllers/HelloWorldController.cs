using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
  IHelloWorldService helloWorldService;

  private readonly ILogger<WeatherForecastController> _logger;


  public HelloWorldController(IHelloWorldService helloWorld, ILogger<WeatherForecastController> logger)
  {
    helloWorldService = helloWorld;
    _logger = logger;
  }

  [HttpGet]
  public IActionResult Get()
  {
    _logger.LogInformation("Returning HelloWorld");
    return Ok(helloWorldService.GetHelloWorld());
  }
}