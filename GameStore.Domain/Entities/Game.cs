using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GameStore.Domain.Entities
{
    /// <summary>
    /// Mодель для таблицы БД Games.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Id.
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int GameId { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, введите название игры")]
        public string Name { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Пожалуйста, введите описание для игры")]
        public string Description { get; set; }

        /// <summary>
        /// Категория.
        /// </summary>
        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Пожалуйста, укажите категорию для игры")]
        public string Category { get; set; }

        /// <summary>
        /// Цена.
        /// </summary>
        [Display(Name = "Цена (uah)")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public decimal Price { get; set; }

        /// <summary>
        /// Картинка.
        /// </summary>
        public byte[] ImageData { get; set; }

        /// <summary>
        /// Формат картинки.
        /// </summary>
        public string ImageMimeType { get; set; }
    }
}
