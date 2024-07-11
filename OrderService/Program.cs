using Microsoft.EntityFrameworkCore;
using OrderService.Data;

var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы в контейнер DI (Dependency Injection)
builder.Services.AddControllers();
// Добавляем сервис для работы с базой данных с помощью SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    // Указываем строку подключения из конфигурационного файла
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// Добавляем поддержку OpenAPI/Swagger для генерации документации и тестирования API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Конфигурируем конвейер обработки HTTP запросов
if (app.Environment.IsDevelopment())
{
    // Включаем Swagger и Swagger UI только в режиме разработки
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
