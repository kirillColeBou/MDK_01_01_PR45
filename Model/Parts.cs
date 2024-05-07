using System;
using System.ComponentModel.DataAnnotations;

namespace API_Тепляков.Model
{
    /// <summary>
    /// Части
    /// </summary>
    public class Parts
    {
        /// <summary>
        /// Код
        /// </summary>
        [Key]
        public int Id_part { get; set; }
        /// <summary>
        /// Место дислокации
        /// </summary>
        public int Locations { get; set; }
        /// <summary>
        /// Рота
        /// </summary>
        public int Companies { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime Date_of_foundation { get; set; }
    }
}
