namespace API_Тепляков.Model
{
    /// <summary>
    /// Пользователи
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Код пользователя
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }
    }
}
