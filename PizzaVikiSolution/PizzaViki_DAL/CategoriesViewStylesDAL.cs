using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaViki_DAL
{
    public static class CategoriesViewStylesDAL
    {
        public static CategoryViewStyle GetCategoryViewStyles(string categoryName)
        {
            PizzaVikiCategoriesEntities pizzaVikiDB = new PizzaVikiCategoriesEntities();

            int categoryID = pizzaVikiDB.Categories.Single(x => x.Name.Equals(categoryName)).id;

            CategoryViewStyle catViewStyle = pizzaVikiDB.CategoriesViewStyles.Single(x => x.CategoryID == categoryID);

            return catViewStyle;
        }
    }
}
