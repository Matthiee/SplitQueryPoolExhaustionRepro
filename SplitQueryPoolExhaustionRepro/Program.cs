using Microsoft.EntityFrameworkCore;
using SplitQueryPoolExhaustionRepro;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PizzaDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("PizzaConnection"),
                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

builder.Services.AddScoped<IPizzaService, PizzaService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
