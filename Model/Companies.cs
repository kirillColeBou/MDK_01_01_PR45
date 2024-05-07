using System;
using System.ComponentModel.DataAnnotations;

namespace API_Тепляков.Model
{
    /// <summary>
    /// Роты
    /// </summary>
    public class Companies
    {
        /// <summary>
        /// Код
        /// </summary>
        [Key]
        public int Id_companies { get; set; }
        /// <summary>
        /// Название роты
        /// </summary>
        public string Name_companies { get; set; }
        /// <summary>
        /// Командир
        /// </summary>
        public string Commander { get; set; }
        /// <summary>
        /// Тип войск
        /// </summary>
        public int Type_of_troops { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime Date_foundation { get; set; }
        /// <summary>
        /// Дата обновления информации
        /// </summary>
        public DateTime Date_update_information { get; set; }
    }
}
