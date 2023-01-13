using DataAccess.EFCore;
using DataAccess.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration()
    // add console as logging target
    .WriteTo.Console()
    // add a logging target for warnings and higher severity  logs
    // structured in JSON format
    .WriteTo.File(new JsonFormatter(),
        "important.json",
        restrictedToMinimumLevel: LogEventLevel.Warning)
    // add a rolling file for all logs
    .WriteTo.File("loggingInformation-.logs",
        rollingInterval: RollingInterval.Day)
    // set default minimum level
    .MinimumLevel.Debug()
    .CreateLogger();


builder.Services.AddDbContextFactory<DataContext>(
    options =>
    {
        options.UseNpgsql(@"Server=127.0.0.1;Port=5433;Database=RepositoryPattern;UserId=postgres;", b => b.MigrationsAssembly("RepoositoryPattern.API"));
    });

builder.Services.AddScoped(typeof(GenericRepository<>));
builder.Services.AddScoped<DeveloperRepository>();
builder.Services.AddScoped<ProjectRepository>();
builder.Services.AddScoped<UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();