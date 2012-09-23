using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaViki_DAL
{
    public static class EntityUtility
    {
        public static List<Product> GetProductsByCategory(string categoryName)
        {
            PizzaVikiCategoriesEntities pizzaVikiDB = new PizzaVikiCategoriesEntities();

            int categoryID = pizzaVikiDB.Categories.Single(x => x.Name.Equals(categoryName)).id;

            var products =
                from product in pizzaVikiDB.Products
                where product.CategoryID == categoryID
                select product;

            return products.ToList();
        }

        public static void AddProduct(
            string categoryName, string productName, 
            string backgroundImagePath, string ingredients,
            string lowestPrice, string averagePrice,
            string highestPrice, float? weight)
        {
            PizzaVikiCategoriesEntities pizzaVikiDB = new PizzaVikiCategoriesEntities();

            int categoryID = pizzaVikiDB.Categories.Single(x => x.Name.Equals(categoryName)).id;

            pizzaVikiDB.Products.AddObject(new Product()
            {
                CategoryID = categoryID,
                Name = productName,
                BackgroundImagePath = backgroundImagePath,
                Ingredients = ingredients,
                LowestPrice = lowestPrice,
                AveragePrice = averagePrice,
                HighestPrice = highestPrice,
                Weight = weight,
            });

            pizzaVikiDB.SaveChanges();
        }
    }
}
