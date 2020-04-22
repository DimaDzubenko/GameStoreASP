namespace GameStore.Domain.Entities
{
    /// <summary>
    /// Mодель для таблицы БД Games.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int GameId { get; set; }
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Категория.
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Цена.
        /// </summary>
        public decimal Price { get; set; }
    }
}
