using API_Тепляков.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Тепляков.Context
{
    public class TasksContext : DbContext
    {
        /// <summary>
        /// Данные из базы данных
        /// </summary>
        public DbSet<Tasks> Tasks { get; set; }
        /// <summary>
        /// Конструктор контекста
        /// </summary>
        public TasksContext()
        {
            Database.EnsureCreated();
            Tasks.Load();
        }
        /// <summary>
        /// Переопределяем метод конфигурации
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql("server=127.0.0.1;port=3303;uid=root;database=TaskManager", new MySqlServerVersion(new System.Version(8, 0, 11)));
    }
}
