using API_For_BookLibraryMobileApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Налаштування підключення до бази даних
builder.Services.AddDbContext<BookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Додайте службу контролерів
builder.Services.AddControllers();

// Налаштування Swagger для документації API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Додайте корс (Cross-Origin Resource Sharing) для кращої роботи з клієнтами
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Налаштування середовища для розробки
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Додайте використання корс
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
