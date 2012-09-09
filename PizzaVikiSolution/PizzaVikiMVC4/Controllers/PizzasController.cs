using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaViki_DAL;

namespace PizzaVikiMVC4.Controllers
{
    public class PizzasController : Controller
    {
        //
        // GET: /Pizzas/

        public ActionResult Pizzas()
        {            
            List<Product> pizzas = PizzasDAL.GetPizzas();
            List<PhoneOrder> phoneOrders = PhoneOrdersDAL.GetPhoneOrders();
            List<NavigationMenu> navigationMenu = NavigationMenuDAL.GetNavigationMenus();

            ProductsNavigationMenusAndPhoneOrders pizzasAndPhoneOrders = new ProductsNavigationMenusAndPhoneOrders();
            pizzasAndPhoneOrders.Products = pizzas;
            pizzasAndPhoneOrders.PhoneOrders = phoneOrders;
            pizzasAndPhoneOrders.NavigationMenus = navigationMenu;


            return View(pizzasAndPhoneOrders);
        }
    }
}
