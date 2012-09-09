using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaViki_DAL
{
    public static class PhoneOrdersDAL
    {
        public static List<PhoneOrder> GetPhoneOrders()
        {
            PizzaVikiCategoriesEntities pizzaVikiDB = new PizzaVikiCategoriesEntities();

            return pizzaVikiDB.PhoneOrders.ToList();
        }

        public static void AddPhoneOrder(string operatorName, string logoImages, string phoneNumber)
        {
            PizzaVikiCategoriesEntities pizzaVikiDB = new PizzaVikiCategoriesEntities();
            pizzaVikiDB.PhoneOrders.AddObject(new PhoneOrder()
            {
                OperatorName = operatorName,
                LogoImage = logoImages,
                PhoneNumber = phoneNumber
            });
        }
    }
}
