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
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                    .OrderBy(b => b.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
