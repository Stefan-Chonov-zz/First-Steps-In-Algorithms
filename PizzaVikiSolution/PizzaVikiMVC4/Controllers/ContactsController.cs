using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaViki_DAL;

namespace PizzaVikiMVC4.Controllers
{
    public class ContactsController : Controller
    {
        //
        // GET: /Contacts/

        public ActionResult Contacts()
        {
            List<NavigationMenu> navigationMenus = NavigationMenuDAL.GetNavigationMenus();
            List<PhoneOrder> phoneOrders = PhoneOrdersDAL.GetPhoneOrders();

            NavigationMenusAndPhoneOrders navigationMenusAndPhoneOrders = new NavigationMenusAndPhoneOrders();
            navigationMenusAndPhoneOrders.NavigationMenus = navigationMenus;
            navigationMenusAndPhoneOrders.PhoneOrders = phoneOrders;

            return View(navigationMenusAndPhoneOrders);
        }
    }
}
