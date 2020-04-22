using GameStore.Domain.Abstract;
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
        /// Конструктор который объявляет зависимость от интерфейса IGameRepository
        /// </summary>
        /// <param name="repo">Репоситорий.</param>
        public GameController(IGameRepository repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Метод который будет визуализировать представление, отображающее полный список товаров.
        /// </summary>
        /// <returns>Список товаров.</returns>
        public ViewResult List()
        {
            return View(repository.Games);
        }
    }
}