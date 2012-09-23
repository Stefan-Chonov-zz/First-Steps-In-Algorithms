using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaViki_DAL
{
    public static class AreasDAL
    {
        public static List<SubArea> GetSubAreas()
        {
            PizzaVikiCategoriesEntities pizzaVikiDB = new PizzaVikiCategoriesEntities();

            return pizzaVikiDB.SubAreas.ToList();            
        }
    }
}
