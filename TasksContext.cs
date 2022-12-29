using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi;

public class TasksContext: DbContext
{
    public DbSet<Category> Categories {get;set;}
    public DbSet<MyTask> Tasks {get;set;}

    public TasksContext(DbContextOptions<TasksContext> options) :base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Category> categoriesInit = new List<Category>();
        categoriesInit.Add(new Category() { CategoryId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), Name = "Actividades pendientes", Weight = 20});
        categoriesInit.Add(new Category() { CategoryId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), Name = "Actividades personales", Weight = 50});


        modelBuilder.Entity<Category>(category=> 
        {
            category.ToTable("Category");
            category.HasKey(p=> p.CategoryId);

            category.Property(p=> p.Name).IsRequired().HasMaxLength(150);

            category.Property(p=> p.Description).IsRequired(false);

            category.Property(p=> p.Weight);

            category.HasData(categoriesInit);
        });

        List<MyTask> tasksInit = new List<MyTask>();

        tasksInit.Add(new MyTask() { TaskId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), CategoryId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), TaskPriority = Priority.Medium, Title = "Pago de servicios publicos", CreatedAt = DateTime.Now });
        tasksInit.Add(new MyTask() { TaskId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb411"), CategoryId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), TaskPriority = Priority.Low, Title = "Terminar de ver pelicula en netflix", CreatedAt = DateTime.Now });

        modelBuilder.Entity<MyTask>(task=>
        {
            task.ToTable("Task");
            task.HasKey(p=> p.TaskId);

            task.HasOne(p=> p.Category).WithMany(p=> p.Tasks).HasForeignKey(p=> p.CategoryId);

            task.Property(p=> p.Title).IsRequired().HasMaxLength(200);

            task.Property(p=> p.Description).IsRequired(false);

            task.Property(p=> p.TaskPriority);

            task.Property(p=> p.CreatedAt);

            task.Ignore(p=> p.Resume);

            task.HasData(tasksInit);

        });

    }

}