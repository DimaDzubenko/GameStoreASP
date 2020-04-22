using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
using System.Collections.Generic;

namespace GameStore.Domain.Concrete
{
    /// <summary>
    /// Клас хранилище реализует интерфейс IGameRepository и использует экземпляр EFDbContext для извлечения данных из базы посредством Entity Framework.
    /// </summary>
    public class EFGameRepository : IGameRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Game> Games
        {
            get { return context.Games; }
        }
    }
}
