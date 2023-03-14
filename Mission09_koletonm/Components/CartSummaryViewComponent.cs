using Microsoft.AspNetCore.Mvc;
using Mission09_koletonm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_koletonm.Components
{
    // Passes the basket to the CartSummary default.cshtml page to generate the cart summary
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket basket;
        public CartSummaryViewComponent(Basket basketService)
        {
            basket = basketService;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}