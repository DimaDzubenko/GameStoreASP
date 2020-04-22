using GameStore.Domain.Entities;
using System.Data.Entity;

namespace GameStore.Domain.Concrete
{
    /// <summary>
    /// Клас асоциации моделей с базой данных.
    /// </summary>
    public class EFDbContext : DbContext
    {
        /// <summary>
        /// Свойство по работе с таблицей Games.
        /// </summary>
        public DbSet<Game> Games { get; set; }
    }
}
