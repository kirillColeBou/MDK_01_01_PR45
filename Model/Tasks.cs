﻿using System;
using System.ComponentModel.DataAnnotations;

namespace API_Тепляков.Model
{
    /// <summary>
    /// Задачи
    /// </summary>
    public class Tasks
    {
        /// <summary>
        /// Код
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Приоритет
        /// </summary>
        public int PriorityId { get; set; }
        /// <summary>
        /// Дата выполнения
        /// </summary>
        public DateTime DateExecute { get; set; }
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Выполнено
        /// </summary>
        public bool Done { get; set; }
    }
}