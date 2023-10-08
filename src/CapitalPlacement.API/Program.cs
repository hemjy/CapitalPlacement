using CapitalPlacement.API.Extensions;
using CapitalPlacement.API.Filters;
using CapitalPlacement.Application.Validators;
using CapitalPlacement.Middlewares;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


// Get log settings from appsettings
IConfiguration config = builder.Configuration;
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateLogger();
builder.Logging.ClearProviders();
// Add serilog
builder.Logging.AddSerilog(logger);
// Add services to the container.
builder.Services.AddControllers
    (options =>
    {
        options.Filters.Add<CustomValidationFilterAttribute>();
    })
    .AddFluentValidation(x =>
     {
         x.AutomaticValidationEnabled = true;
         x.RegisterValidatorsFromAssembly(Assembly.GetAssembly(typeof(ProgramDetailValidator)));
     });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProgramServices();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlerMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
