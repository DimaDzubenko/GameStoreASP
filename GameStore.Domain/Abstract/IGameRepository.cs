using GameStore.Domain.Entities;
using System.Collections.Generic;

namespace GameStore.Domain.Abstract
{
    /// <summary>
    /// Инерфейс для  получения последовательности объектов Game.
    /// </summary>
    public interface IGameRepository
    {
        IEnumerable<Game> Games { get; }
        void SaveGame(Game game);
        Game DeleteGame(int gameId);
    }
}
