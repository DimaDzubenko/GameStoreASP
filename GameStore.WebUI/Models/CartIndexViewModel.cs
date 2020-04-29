using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.WebUI.Models
{
    /// <summary>
    /// Класс модели представления для передачи представлению объектов Cart и URL
    /// </summary>
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}