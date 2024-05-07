using API_Тепляков.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Тепляков.Context
{
    public class TechniqueContext : DbContext
    {
        /// <summary>
        /// Данные из базы данных
        /// </summary>
        public DbSet<Technique> Technique { get; set; }
        /// <summary>
        /// Конструктор контекста
        /// </summary>
        public TechniqueContext()
        {
            Database.EnsureCreated();
            Technique.Load();
        }
        /// <summary>
        /// Переопределяем метод конфигурации
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=DESKTOP-UIE24UG\\SQLEXPRESS;Trusted_Connection=False;Database=military_district;User=sa;Pwd=Asdfg123");
    }
}
