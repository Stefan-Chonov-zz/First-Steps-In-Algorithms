using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaViki_DAL;

namespace PizzaVikiMVC4.Controllers
{
    public class KatmiController : Controller
    {
        //
        // GET: /Katmi/

        public ActionResult Katmi()
        {
            List<Product> katmi = KatmiDAL.GetKatmi();
            List<NavigationMenu> navigationMenus = NavigationMenuDAL.GetNavigationMenus();
            List<PhoneOrder> phoneOrders = PhoneOrdersDAL.GetPhoneOrders();

            ProductsNavigationMenusAndPhoneOrders productsMenuPhoneOrders = new ProductsNavigationMenusAndPhoneOrders();
            productsMenuPhoneOrders.Products = katmi;
            productsMenuPhoneOrders.NavigationMenus = navigationMenus;
            productsMenuPhoneOrders.PhoneOrders = phoneOrders;

            return View(productsMenuPhoneOrders);
        }
    }
}
