using Microsoft.AspNetCore.Mvc;
using Library.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models.LibraryModels;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Identity;
using Library.Models.IdentityModels;

namespace Library.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        // эта штука не вся статичная, можно формировать 
        private Dictionary<string, NavigationItem> NavigationsItems => new Dictionary<string, NavigationItem>
        {
            ["ListBooks"] = new NavigationItem
            {
                Text = "Главная",
                Controller = "",
                Action = "",
                IsActive = (item, routeData) => routeData?.Values["Controller"] as string == "Book" && routeData?.Values["Action"] as string == "List"
            },
        };
        private IRepository<Genre> repositoryGenre;

        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        public NavigationMenuViewComponent(IRepository<Genre> repo, UserManager<AppUser> userMgr)
        {
            userManager = userMgr;
            repositoryGenre = repo;
        }

        private void AddGenresInBookNavigation()
        {
            var genres = new Dictionary<string, NavigationItem>();

            foreach (var genre in repositoryGenre
                .GetAll()
                .Distinct()
                .OrderBy(x => x))
            {
                genres.Add("ListBooksGenre" + genre.Name
                    , new NavigationItem
                    {
                        Text = genre.Name,
                        Controller = "Book",
                        Action = "List",
                        Parameters = new Dictionary<string, string>
                        {
                            ["genreId"] = $"{genre.Id}",
                            ["page"] = $"{1}",
                        }
                    });
            }

            NavigationsItems["ListBooks"].ChildNavigationItems = genres;
        }

        public IViewComponentResult Invoke()
        {
            AddGenresInBookNavigation();
            var navigationItemsRole = (User.Identity as AppRole).NavigationsItems?.Split(';');
            return View(new NavigationViewModel{
                Items = NavigationsItems.Where(navItem => navigationItemsRole.Contains(navItem.Key)).Select(navItem => navItem.Value),
                RouteData = RouteData
                }
            );
        }
    }

    public class NavigationItem
    {
        public string Text { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public Func<NavigationItem, RouteData, bool> IsActive { get; set; }
        public Dictionary<string, NavigationItem> ChildNavigationItems { get; set; }
    }

    public class NavigationViewModel
    {
        public IEnumerable<NavigationItem> Items { get; set; }
        public RouteData RouteData { get; set; }
    }
}
