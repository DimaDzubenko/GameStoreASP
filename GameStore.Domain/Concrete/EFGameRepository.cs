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
        readonly EFDbContext context = new EFDbContext();

        public IEnumerable<Game> Games
        {
            get { return context.Games; }
        }

        public void SaveGame(Game game)
        {
            if (game.GameId == 0)
                context.Games.Add(game);
            else
            {
                Game dbEntry = context.Games.Find(game.GameId);
                if (dbEntry != null)
                {
                    dbEntry.Name = game.Name;
                    dbEntry.Description = game.Description;
                    dbEntry.Price = game.Price;
                    dbEntry.Category = game.Category;
                    dbEntry.ImageData = game.ImageData;
                    dbEntry.ImageMimeType = game.ImageMimeType;
                }
            }
            context.SaveChanges();
        }

        public Game DeleteGame(int gameId)
        {
            Game dbEntry = context.Games.Find(gameId);
            if (dbEntry != null)
            {
                context.Games.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
