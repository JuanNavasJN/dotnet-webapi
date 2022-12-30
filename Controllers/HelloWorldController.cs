using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
  IHelloWorldService helloWorldService;

  TasksContext dbContext;

  private readonly ILogger<WeatherForecastController> _logger;


  public HelloWorldController(IHelloWorldService helloWorld, ILogger<WeatherForecastController> logger, TasksContext db)
  {
    helloWorldService = helloWorld;
    _logger = logger;
    dbContext= db;
  }

  [HttpGet]
  public IActionResult Get()
  {
    _logger.LogInformation("Returning HelloWorld");
    return Ok(helloWorldService.GetHelloWorld());
  }

  [HttpGet]
  [Route("createdb")]
  public IActionResult CreateDatabase()
  {
    dbContext.Database.EnsureCreated();

    return Ok();
  }
}