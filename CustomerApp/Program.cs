using CustomerApp.Contracts;
using CustomerApp.Domain;
using CustomerApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Nelibur.ObjectMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CustomerDbContext>(options => options.UseInMemoryDatabase("customers"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "Customer API",
        Description = "Handling customer interactions",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => 
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer API V1");
});

app.MapGet("/", () => "Hello World!");

TinyMapper.Bind<CustomerDto, Customer>(config => 
{
    config.Bind(source => source.EmailAddress, target => target.Email);
});

app.Run();
