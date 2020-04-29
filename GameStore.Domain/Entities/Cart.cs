using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    /// <summary>
    /// Клас модели Корзины покупок.
    /// </summary>
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        /// <summary>
        /// Метод добавления товара в корзину.
        /// </summary>
        /// <param name="game">Товар</param>
        /// <param name="quantity"></param>
        public void AddItem(Game game, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Game.GameId == game.GameId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Game = game,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        /// <summary>
        /// Метод удаления одного товара с корзины.
        /// </summary>
        /// <param name="game">Товар.</param>
        public void RemoveLine(Game game)
        {
            lineCollection.RemoveAll(l => l.Game.GameId == game.GameId);
        }

        /// <summary>
        /// Метод вычисление общей стоимости товаров в корзине.
        /// </summary>
        /// <returns></returns>
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Game.Price * e.Quantity);

        }

        /// <summary>
        /// Метод очистки корзины.
        /// </summary>
        public void Clear()
        {
            lineCollection.Clear();
        }

        /// <summary>
        /// Свойство которое позволяет обратиться к содержимому корзины.
        /// </summary>
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    /// <summary>
    /// Клас представляющий товар выбранный пользователем и его количество.
    /// </summary>
    public class CartLine
    {
        public Game Game { get; set; }
        public int Quantity { get; set; }
    }
}
