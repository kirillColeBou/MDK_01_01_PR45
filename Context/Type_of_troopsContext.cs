using API_Тепляков.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Тепляков.Context
{
    public class Type_of_troopsContext : DbContext
    {
        /// <summary>
        /// Данные из базы данных
        /// </summary>
        public DbSet<Type_of_troops> Type_of_troops { get; set; }
        /// <summary>
        /// Конструктор контекста
        /// </summary>
        public Type_of_troopsContext()
        {
            Database.EnsureCreated();
            Type_of_troops.Load();
        }
        /// <summary>
        /// Переопределяем метод конфигурации
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=student.permaviat.ru;Trusted_Connection=False;Database=base1_ISP_21_2_23;User=sa;Pwd=3frQxZ83o#");
    }
}
