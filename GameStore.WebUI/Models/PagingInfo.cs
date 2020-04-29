using System;

namespace GameStore.WebUI.Models
{
    /// <summary>
    /// Клас модели для обеспичения передачи представления информации о количестве доступных страниц.
    /// </summary>
    public class PagingInfo
    {
        // Кол-во товаров
        public int TotalItems { get; set; }

        // Кол-во товаров на одной странице
        public int ItemsPerPage { get; set; }

        // Номер текущей страницы
        public int CurrentPage { get; set; }

        // Общее кол-во страниц
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}