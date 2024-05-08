using API_Тепляков.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Тепляков.Context
{
    public class UsersContext : DbContext
    {
        /// <summary>
        /// Данные из базы данных
        /// </summary>
        public DbSet<Users> Users { get;set; }
        /// <summary>
        /// Конструктор контекста
        /// </summary>
        public UsersContext()
        {
            Database.EnsureCreated();
            Users.Load();
        }
        /// <summary>
        /// Переопределяем метод конфигурации
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql("server=localhost;uid=root;database=TaskManager", new MySqlServerVersion(new System.Version(8, 0, 11)));
    }
}
