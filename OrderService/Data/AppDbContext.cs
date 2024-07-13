using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.Data
{
    // Контекст базы данных для взаимодействия с SQLite
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet представляет собой набор сущностей Order, которые будут сохранены в таблице Orders
        public DbSet<Order> Orders { get; set; }
        public DbSet<Executor> Executors { get; set; }  

        // Метод для настройки поведения контекста базы данных
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Вызываем метод базового класса для применения стандартных настроек
            base.OnModelCreating(modelBuilder);

            // Настраиваем таблицу для сущности Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.comment).IsRequired(false); // Поле Comment допускает значение null
            });
        }
    }
}
