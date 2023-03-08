using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission09_koletonm.Models;
using Mission09_koletonm.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

// Created by: Koleton Murray
// Project: Mission 9 - Online Bookstore

namespace Mission09_koletonm.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }

        // When the index page is loaded grab the book info from the database through our repository and feed it to the view
        // Generate the pagination for 10 books/ page
        public IActionResult Index(string category, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                // Adjusted the books being passed into the Index because we added categories and need to pass them in each time 
                Books = repo.Books
                    .Where(b => b.Category == category || category == null)
                    .OrderBy(b => b.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PageInfo = new PageInfo
                {
                    // Modiified the total NumBooks so the categories and pagination are correct
                    TotalNumBooks = 
                        (category == null
                        ? repo.Books.Count()
                        : repo.Books.Where(x => x.Category == category).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
