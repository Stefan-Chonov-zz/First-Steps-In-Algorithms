using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaViki_DAL
{
    public static class PizzasDAL
    {
        private const string CATEGORY_NAME = "Pizzas";

        public static List<Product> GetPizzas()
        {
            List<Product> pizzas = EntityUtility.GetProductsByCategory(CATEGORY_NAME);

            return pizzas;            
        }

        public static void AddPizza(string name, string backgroundImagePath, string ingredients)
        {
            EntityUtility.AddProduct(CATEGORY_NAME, name, backgroundImagePath, ingredients, null, null, null, null);
        }
    }
}
