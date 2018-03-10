using Library.Models.LibraryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.ViewModels
{
    public class BasketIndexViewModel
    {
        public Basket Basket { get; set; }
        public string ReturnUrl { get; set; }
    }
}
