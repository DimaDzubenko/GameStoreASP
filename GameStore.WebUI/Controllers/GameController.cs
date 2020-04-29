using GameStore.Domain.Abstract;
using GameStore.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace GameStore.WebUI.Controllers
{
    /// <summary>
    /// Контроллер для модели Game.
    /// </summary>
    public class GameController : Controller
    {
        private IGameRepository repository;
        /// <summary>
        /// Количество товаров на странице.
        /// </summary>
        public int pageSize = 4;

        /// <summary>
        /// Конструктор который объявляет зависимость от интерфейса IGameRepository
        /// </summary>
        /// <param name="repo">Репоситорий.</param>
        public GameController(IGameRepository repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Метод который будет визуализировать представление, отображающее полный список товаров, и информацией о разбиении на страницы.
        /// </summary>
        /// <returns>Список товаров.</returns>
        public ViewResult List(string category, int page = 1)
        {
            GamesListViewModel model = new GamesListViewModel
            {
                Games = repository.Games
                        .Where(p => category == null || p.Category == category)
                        .OrderBy(game => game.GameId)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
                    repository.Games.Count() :
                    repository.Games.Where(game => game.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}