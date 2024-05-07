using System.ComponentModel.DataAnnotations;

namespace API_Тепляков.Model
{
    /// <summary>
    /// Места дислокации
    /// </summary>
    public class Locations
    {
        /// <summary>
        /// Код
        /// </summary>
        [Key]
        public int Id_locations { get; set; }
        /// <summary>
        /// Страна
        /// </summary>
        public int Country { get; set; }
        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Занимаемая площадь
        /// </summary>
        public int Square { get; set; }
        /// <summary>
        /// Количество строений
        /// </summary>
        public int Count_structures { get; set; }
    }
}
