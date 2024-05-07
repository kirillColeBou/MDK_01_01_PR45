using System;
using System.ComponentModel.DataAnnotations;

namespace API_Тепляков.Model
{
    /// <summary>
    /// Виды вооружения
    /// </summary>
    public class Weapons
    {
        /// <summary>
        /// Код
        /// </summary>
        [Key]
        public int Id_weapons { get; set; }
        /// <summary>
        /// Название вооружения
        /// </summary>
        public string Name_weapons { get; set; }
        /// <summary>
        /// Рота
        /// </summary>
        public int Companies { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Дата обновления информации
        /// </summary>
        public DateTime Date_update_information { get; set; }
    }
}
