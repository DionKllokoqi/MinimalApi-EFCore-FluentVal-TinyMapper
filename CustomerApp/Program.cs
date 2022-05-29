using CustomerApp.Contracts;
using CustomerApp.Domain;
using CustomerApp.Endpoints;
using CustomerApp.Infrastructure;
using CustomerApp.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Nelibur.ObjectMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CustomerDbContext>(options => options.UseInMemoryDatabase("customers"));
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer API V1");
    });
}

TinyMapper.Bind<CustomerDto, Customer>(config => 
{
    config.Bind(source => source.EmailAddress, target => target.Email);
});

app.ConfigureApi();

app.Run();
