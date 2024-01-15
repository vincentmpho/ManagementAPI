using ManagementAPI.Data;
using ManagementAPI.Repository;
using ManagementAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inject Repository
builder.Services.AddScoped<IMyTasks, MyTaskRepository>();

//inject connection string

builder.Services.AddDbContext<TaskDbContext>(Options =>
Options.UseSqlServer(builder.Configuration.GetConnectionString("ManagementStringConnection")));

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
