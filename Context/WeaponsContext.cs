﻿using API_Тепляков.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Тепляков.Context
{
    public class WeaponsContext : DbContext
    {
        /// <summary>
        /// Данные из базы данных
        /// </summary>
        public DbSet<Weapons> Weapons { get; set; }
        /// <summary>
        /// Конструктор контекста
        /// </summary>
        public WeaponsContext()
        {
            Database.EnsureCreated();
            Weapons.Load();
        }
        /// <summary>
        /// Переопределяем метод конфигурации
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=DESKTOP-UIE24UG\\SQLEXPRESS;Trusted_Connection=False;Database=military_district;User=sa;Pwd=Asdfg123");
    }
}
