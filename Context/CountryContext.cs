using API_Тепляков.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Тепляков.Context
{
    public class CountryContext : DbContext
    {
        /// <summary>
        /// Данные из базы данных
        /// </summary>
        public DbSet<Country> Country { get; set; }
        /// <summary>
        /// Конструктор контекста
        /// </summary>
        public CountryContext()
        {
            Database.EnsureCreated();
            Country.Load();
        }
        /// <summary>
        /// Переопределяем метод конфигурации
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=student.permaviat.ru;Trusted_Connection=False;Database=base1_ISP_21_2_23;User=sa;Pwd=3frQxZ83o#");
    }
}
