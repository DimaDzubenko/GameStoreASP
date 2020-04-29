using System.Collections.Generic;
using GameStore.Domain.Entities;

namespace GameStore.WebUI.Models
{
    /// <summary>
    /// Клас модели представления PagingInfo
    /// </summary>
    public class GamesListViewModel
    {
        /// <summary>
        /// Список продуктов.
        /// </summary>
        public IEnumerable<Game> Games { get; set; }
        /// <summary>
        /// Количество страниц.
        /// </summary>
        public PagingInfo PagingInfo { get; set; }
        /// <summary>
        /// Выбранная категория.
        /// </summary>
        public string CurrentCategory { get; set; }
    }
}