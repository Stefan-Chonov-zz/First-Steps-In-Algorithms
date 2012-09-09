using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaViki_DAL
{
    public static class NavigationMenuDAL
    {
        public static List<NavigationMenu> GetNavigationMenus()
        {
            PizzaVikiCategoriesEntities pizzaVikiDB = new PizzaVikiCategoriesEntities();

            return pizzaVikiDB.NavigationMenus.ToList();
        }

        public static void AddNavigation(string title, string link, string text)
        {
            PizzaVikiCategoriesEntities pizzaVikiDB = new PizzaVikiCategoriesEntities();
            pizzaVikiDB.NavigationMenus.AddObject(new NavigationMenu()
            {
                Title = title,
                Link = link,
                Text = text,
            });
        }
    }
}
