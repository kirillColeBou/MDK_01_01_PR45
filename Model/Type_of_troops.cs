using System;
using System.ComponentModel.DataAnnotations;

namespace API_Тепляков.Model
{
    /// <summary>
    /// Виды войск
    /// </summary>
    public class Type_of_troops
    {
        /// <summary>
        /// Код
        /// </summary>
        [Key]
        public int Id_type_of_troops { get; set; }
        /// <summary>
        /// Название типа войск
        /// </summary>
        public string Name_type_of_troops { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Количество служащих
        /// </summary>
        public int Count_serviceman { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime Date_foundation { get; set; }
    }
}
