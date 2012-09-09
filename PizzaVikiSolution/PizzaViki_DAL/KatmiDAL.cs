using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaViki_DAL
{
    public static class KatmiDAL
    {
        public static List<Product> GetKatmi()
        {
            PizzaVikiCategoriesEntities pizzaVikiDB = new PizzaVikiCategoriesEntities();

            int katmiID = pizzaVikiDB.Categories.FirstOrDefault(x => x.Name.Equals("Katmi")).id;

            var katmis =
                from product in pizzaVikiDB.Products
                where product.CategoryID == katmiID
                select product;
            
            return katmis.ToList();
        }

        public static void AddKatma(
            string name, string backgroundImagePath, 
            string ingredients, float price)
        {
            PizzaVikiCategoriesEntities pizzaVikiDB = new PizzaVikiCategoriesEntities();

            int katmiID = pizzaVikiDB.Categories.FirstOrDefault(x => x.Name.Equals("Katmi")).id;

            pizzaVikiDB.Products.AddObject(new Product()
            {
                CategoryID = katmiID,
                Name = name,
                BackgroundImagePath = backgroundImagePath,
                Ingredients = ingredients,
                LowestPrice = price
            });

            pizzaVikiDB.SaveChanges();
        }
    }
}
