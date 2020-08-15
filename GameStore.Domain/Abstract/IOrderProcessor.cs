using GameStore.Domain.Entities;

namespace GameStore.Domain.Abstract
{
    /// <summary>
    /// Интерфейс реализован для обработки заказов.
    /// </summary>
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
