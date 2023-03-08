using Microsoft.AspNetCore.Mvc;
using Mission09_koletonm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_koletonm.Components
{
    // Create a ViewComponent to pass the categories to the sidebar to sort by book category
    public class CategoriesViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }
        public CategoriesViewComponent (IBookstoreRepository temp)
        {
            repo = temp;
        }
        
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCat = RouteData?.Values["category"];

            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
