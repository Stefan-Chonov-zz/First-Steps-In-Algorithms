using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaViki_DAL
{
    public static class SaladsDAL
    {
        public static List<Product> GetSalads()
        {
            PizzaVikiCategoriesEntities pizzaVikiDB = new PizzaVikiCategoriesEntities();

            return pizzaVikiDB.Products.ToList();
        }

        public static void AddSalad(
            string name, float weight, 
            string backgroundImagePath, 
            string ingredients, float price)
        {
            PizzaVikiCategoriesEntities pizzaVikiDB = new PizzaVikiCategoriesEntities();
            pizzaVikiDB.Products.AddObject(new Product()
            {
                Name = name,
                Weight = weight,
                BackgroundImagePath = backgroundImagePath,
                Ingredients = ingredients,
                LowestPrice = price
            });

            pizzaVikiDB.SaveChanges();
        }
    }
}
