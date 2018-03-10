using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models.LibraryModels;
using Library.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private IRepository<Book> repoBook;

        public BookController(IRepository<Book> repos)
        {
            repoBook = repos;
        }

        public IActionResult List()
        {
            return View(repoBook.GetAll());
        }
    }
}