using Microsoft.EntityFrameworkCore;
using OrderAccumulator.Data;
using OrderAccumulator.Repositories;
using OrderAccumulator.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrdersDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
    );
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddCors(o => o.AddPolicy("AllowLocalPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowLocalPolicy");

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<OrdersDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

app.Run();
