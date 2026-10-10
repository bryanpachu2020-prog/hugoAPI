using Microsoft.EntityFrameworkCore;
using WebApplicationhugo2.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL")));

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(); // Agrega esto para generar la documentación de Swagger

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(); // Agrega esto
    app.UseSwaggerUI(); // Agrega esto para ver la interfaz gráfica
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();