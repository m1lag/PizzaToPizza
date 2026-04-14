using Microsoft.EntityFrameworkCore;
using PizzaToPizza.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PizzaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
