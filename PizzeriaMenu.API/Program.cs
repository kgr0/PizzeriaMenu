using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PizzeriaMenu.API.Extensions;
using PizzeriaMenu.Application.Handlers.Menu;
using PizzeriaMenu.Database;
using static PizzeriaMenu.Application.Handlers.Menu.Post;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMediatR(new[]
    {
        typeof(Program),
        typeof(GetAll)
    }.Select(static t => t.Assembly)
    .ToArray());

builder.Services
            .AddDbContext<Context>(options => { options.UseSqlite(builder.Configuration.GetConnectionString("ConnectionSqlite")); });


builder.Services
    .AddControllers()
    .AddFluentValidation(
    static fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<Program>();
    });


builder.Services
    .AddAutoMapper(typeof(PizzeriaMenu.API.MapperProfiles.PizzaToDto)); ;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();