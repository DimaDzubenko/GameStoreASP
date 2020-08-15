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
        private IOrderProcessor orderProcessor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        public CartController(IGameRepository repo, IOrderProcessor processor)
        {
            repository = repo;
            orderProcessor = processor;
        }


        /// <summary>
        /// Метод для отображения содержимого Cart
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        /// <summary>
        /// Метод
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult AddToCart(Cart cart, int gameId, string returnUrl)
        {
            Game game = repository.Games
                .FirstOrDefault(g => g.GameId == gameId);

            if (game != null)
            {
                cart.AddItem(game, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// Метод
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult RemoveFromCart(Cart cart, int gameId, string returnUrl)
        {
            Game game = repository.Games
                .FirstOrDefault(g => g.GameId == gameId);

            if (game != null)
            {
                cart.RemoveLine(game);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// Метод визиализирующий представление отображающие информацию корзины.
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        /// <summary>
        /// Метод возвращает стандартное представление, передавая ему новый объект ShippingDetails в качестве модели представления.
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="shippingDetails"></param>
        /// <returns></returns>
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        /// <summary>
        /// Метод для запроса POST
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="shippingDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}