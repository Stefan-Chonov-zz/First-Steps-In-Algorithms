using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaViki_DAL
{
    public static class PizzasDAL
    {
        public static List<Product> GetPizzas()
        {
            PizzaVikiCategoriesEntities pizzaVikiDB = new PizzaVikiCategoriesEntities();

            int pizzasID = pizzaVikiDB.Categories.FirstOrDefault(x => x.Name.Equals("Pizzas")).id;            
            
            var pizzas =
                from product in pizzaVikiDB.Products
                where product.CategoryID == pizzasID
                select product;

            return pizzas.ToList();            
        }

        public static void AddPizza(string name, string backgroundImagePath, string ingredients)
        {
            PizzaVikiCategoriesEntities pizzaVikiDB = new PizzaVikiCategoriesEntities();

            int pizzasID = pizzaVikiDB.Categories.FirstOrDefault(x => x.Name.Equals("Pizzas")).id; 

            pizzaVikiDB.Products.AddObject(new Product()
            {
                CategoryID = pizzasID,
                Name = name,
                BackgroundImagePath = backgroundImagePath,
                Ingredients = ingredients
            });

            pizzaVikiDB.SaveChanges();
        }
    }
}
