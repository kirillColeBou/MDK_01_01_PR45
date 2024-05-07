using System.ComponentModel.DataAnnotations;

namespace API_Тепляков.Model
{
    /// <summary>
    /// Техника
    /// </summary>
    public class Technique
    {
        /// <summary>
        /// Код
        /// </summary>
        [Key]
        public int Id_technique { get; set; }
        /// <summary>
        /// Название техники
        /// </summary>
        public string Name_technique { get; set; }
        /// <summary>
        /// Рота
        /// </summary>
        public int Companies { get; set; }
        /// <summary>
        /// Характеристики
        /// </summary>
        public string Characteristics { get; set; }
    }
}
