using Microsoft.AspNetCore.Mvc;
using webapi.Services;
using webapi.Models;

namespace webapi.Controllers;

[Route("api/[controller]")]
public class TaskController: ControllerBase
{
  ITaskService taskService;

  public TaskController(ITaskService service)
  {
    taskService = service;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(taskService.GetAll());
  }

  [HttpPost]
  public IActionResult Post([FromBody] MyTask task)
  {
    taskService.Save(task);
    return Ok();
  }

  [HttpPut("{id}")]
  public IActionResult Put(Guid id, [FromBody] MyTask task)
  {
    taskService.Update(id, task);
    return Ok();
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(Guid id)
  {
    taskService.Delete(id);
    return Ok();
  }
}