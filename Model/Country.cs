using System.ComponentModel.DataAnnotations;

namespace API_Тепляков.Model
{
    /// <summary>
    /// Страны
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Код
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Страна
        /// </summary>
        public string Name { get; set; }
    }
}
