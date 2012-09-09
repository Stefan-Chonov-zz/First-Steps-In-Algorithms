using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaViki_DAL
{
    public static class CategoriesDAL
    {
        public static List<Category> GetCategories()
        {            
            PizzaVikiCategoriesEntities pizzaVikiDB = new PizzaVikiCategoriesEntities();

            return pizzaVikiDB.Categories.ToList();
        }

        public static void AddCategory(string name, string backgroundImagePath, string link, string title)
        {
            PizzaVikiCategoriesEntities pizzaVikiDB = new PizzaVikiCategoriesEntities();
            pizzaVikiDB.Categories.AddObject(new Category()
            {
                Name = name,
                BackgroundImagePath = backgroundImagePath,
                Link = link,
                Title = title
            });

            pizzaVikiDB.SaveChanges();
        }
    }
}
