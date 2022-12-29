using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom dependencies to inject
// Service = Dependency

// builder.Services.AddSingleton
// builder.Services.AddScoped<IHelloWorldService, HellowWorldService>();
builder.Services.AddScoped<IHelloWorldService>(p => new HellowWorldService());
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITaskService, TaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Insert custom middlewares here
// app.UseWelcomePage();
// app.UseTimeMiddleware();

app.MapControllers();

app.Run();
