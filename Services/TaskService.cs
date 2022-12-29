namespace webapi.Services;

using webapi.Models;

public class TaskService : ITaskService
{
  TasksContext context;

  public TaskService(TasksContext dbContext)
  {
    context = dbContext;
  }

  public IEnumerable<MyTask> GetAll()
  { 
    return context.Tasks;
  }

  public async void Save(MyTask task)
  {
    context.Add(task);
    await context.SaveChangesAsync();
  }

  public async void Update(Guid id, MyTask task)
  {
    var currentTask = context.Tasks.Find(id);

    if(currentTask != null)
    {
      currentTask.Title = task.Title;
      currentTask.Description = task.Description;
      currentTask.TaskPriority = task.TaskPriority;
      currentTask.Resume = task.Resume;

      await context.SaveChangesAsync();
    }
  }

   public async void Delete(Guid id)
  {
    var currentTask = context.Tasks.Find(id);

    if(currentTask != null)
    {
      context.Remove(currentTask);
      await context.SaveChangesAsync();
    }
  }

}

public interface ITaskService
{
  IEnumerable<MyTask> GetAll();
  void Save(MyTask task);
  void Update(Guid id, MyTask task);
  void Delete(Guid id);
}