using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GameStore.Domain.Abstract;

namespace GameStore.WebUI.Controllers
{
    /// <summary>
    /// Класс контроллера  навигации.
    /// </summary>
    public class NavController : Controller
    {
        private IGameRepository repository;

        /// <summary>
        /// Конструктор который принимает в качестве своего аргумента реализацию IGameRepository.
        /// </summary>
        /// <param name="repo">Репозиторий</param>
        public NavController(IGameRepository repo)
        {
            repository = repo;
        }
        
        /// <summary>
        /// Метод который использует запрос LINQ для получения списка категорий из хранилища и передачи их представлению.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="horizontalNav"></param>
        /// <returns></returns>
        public PartialViewResult Menu(string category = null, bool horizontalNav = false)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Games
                .Select(game => game.Category)
                .Distinct()
                .OrderBy(x => x);

            return PartialView("FlexMenu", categories);
        }
    }
}