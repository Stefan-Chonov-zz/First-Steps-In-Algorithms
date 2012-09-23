using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaViki_DAL;
using System.Data.Entity;

namespace PizzaVikiMVC4.Controllers
{
    public class HomeController : Controller
    {
        CategoriesAndPhoneOrders categoriesAndPhoneOrders;

        public HomeController()
        {
            this.categoriesAndPhoneOrders = new CategoriesAndPhoneOrders();
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
            List<Category> categories = CategoriesDAL.GetCategories();
            List<PhoneOrder> phoneOrders = PhoneOrdersDAL.GetPhoneOrders();
            List<SubArea> subAreas = AreasDAL.GetSubAreas();
            
            this.categoriesAndPhoneOrders.Categories = categories;
            this.categoriesAndPhoneOrders.PhoneOrders = phoneOrders;
            this.categoriesAndPhoneOrders.SubAreas = subAreas;

            return View(categoriesAndPhoneOrders);
        }
        
        public ActionResult Contacts()
        {
            List<Category> categories = CategoriesDAL.GetCategories();
            List<PhoneOrder> phoneOrders = PhoneOrdersDAL.GetPhoneOrders();

            ProductsCategoriesAndPhoneOrders categoriesAndPhoneOrders = new ProductsCategoriesAndPhoneOrders();
            categoriesAndPhoneOrders.Categories = categories;
            categoriesAndPhoneOrders.PhoneOrders = phoneOrders;

            return View(categoriesAndPhoneOrders);
        }
    }
}
