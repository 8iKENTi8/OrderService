using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.Data
{
    // Контекст базы данных для взаимодействия с SQLite
    public class AppDbContext : DbContext
    {
        // Конструктор класса, принимающий опции конфигурации DbContext
        // Здесь мы передаем конфигурационные параметры, такие как строка подключения к базе данных
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
    }
}
