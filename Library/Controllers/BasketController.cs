using Library.Models.LibraryModels;
using Library.Models.Repository;
using Library.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class BasketController : Controller
    {
        private IRepository<Book> repoBook;
        private Basket basket;

        public BasketController(IRepository<Book> repo, Basket basketService)
        {
            repoBook = repo;
            basket = basketService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new BasketIndexViewModel
            {
                Basket = basket,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToBasket(Guid bookId, string returnUrl)
        {
            var book = repoBook.Get(bookId);
            if (book != null)
            {
                basket.AddItem(book, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromBasket(Guid bookId,
                string returnUrl)
        {
            var book = repoBook.Get(bookId);
            if (book != null)
            {
                basket.RemoveLine(book);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
