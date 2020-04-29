using System.Linq;
using System.Web.Mvc;
using GameStore.Domain.Entities;
using GameStore.Domain.Abstract;
using GameStore.WebUI.Models;

namespace GameStore.WebUI.Controllers
{
    /// <summary>
    /// Класс контроллера для обработки щелчков на кнопках "Добавить в корзину".
    /// </summary>
    public class CartController : Controller
    {
        private IGameRepository repository;

        /// <summary>
        /// Метод для отображения содержимого Cart
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        public CartController(IGameRepository repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Метод
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult AddToCart(int gameId, string returnUrl)
        {
            Game game = repository.Games
                .FirstOrDefault(g => g.GameId == gameId);

            if (game != null)
            {
                GetCart().AddItem(game, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// Метод
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult RemoveFromCart(int gameId, string returnUrl)
        {
            Game game = repository.Games
                .FirstOrDefault(g => g.GameId == gameId);

            if (game != null)
            {
                GetCart().RemoveLine(game);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// Метод для сохранения и извлечения объектов Cart применяется средство состояния сеанса ASP.NET.
        /// </summary>
        /// <returns></returns>
        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}