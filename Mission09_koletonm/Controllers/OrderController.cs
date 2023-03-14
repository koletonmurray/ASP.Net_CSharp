using Microsoft.AspNetCore.Mvc;
using Mission09_koletonm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_koletonm.Controllers
{
    // Brand new controller to control the checkout view and what to do when we post, get
    // Reference the Order repository to pull in that repository for checkout purposes
    public class OrderController : Controller
    {
        private IOrderRepository repo { get; set; }
        private Basket basket { get; set; }
        public OrderController(IOrderRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                order.Lines = basket.Items.ToArray();
                repo.SaveOrder(order);
                basket.ClearBasket();

                return RedirectToPage("/OrderComplete");
            }

            else
            {
                return View();
            }
        }
    }
}
