using Microsoft.EntityFrameworkCore;
using OrderService.Data;

var builder = WebApplication.CreateBuilder(args);

// ��������� ������� � ��������� DI (Dependency Injection)
builder.Services.AddControllers();
// ��������� ������ ��� ������ � ����� ������ � ������� SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    // ��������� ������ ����������� �� ����������������� �����
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// ��������� ��������� OpenAPI/Swagger ��� ��������� ������������ � ������������ API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ������������� �������� ��������� HTTP ��������
if (app.Environment.IsDevelopment())
{
    // �������� Swagger � Swagger UI ������ � ������ ����������
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
