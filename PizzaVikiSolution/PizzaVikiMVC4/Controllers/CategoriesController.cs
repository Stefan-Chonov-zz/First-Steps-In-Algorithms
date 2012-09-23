using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaViki_DAL;

namespace PizzaVikiMVC4.Controllers
{
    public class CategoriesController : Controller
    {
        //
        // GET: /Categories/        

        public ActionResult Category(string categoryName)
        {
            //CategoryViewStyles categoryViewStyles = new CategoryViewStyles()
            //{
            //    BackgroundImagePath = CategoriesViewStylesDAL.GetBackgroundImage(categoryName),
            //    HeaderBackgroundImagePath = CategoriesViewStylesDAL.GetHeaderBackgroundImage(categoryName),
            //    CategoryTitleImage = CategoriesViewStylesDAL.GetCategoryTitleImage(categoryName),
            //};            


            List<Product> products = EntityUtility.GetProductsByCategory(categoryName);
            List<Category> categories = CategoriesDAL.GetCategories();            
            List<PhoneOrder> phoneOrders = PhoneOrdersDAL.GetPhoneOrders();

            CategoryViewStyle categoryViewStyles = CategoriesViewStylesDAL.GetCategoryViewStyles(categoryName);

            ProductsCategoriesAndPhoneOrders productsCategoriesAndPhoneOrders = new ProductsCategoriesAndPhoneOrders();
            productsCategoriesAndPhoneOrders.CategoryName = categoryName;
            productsCategoriesAndPhoneOrders.CategoryTitle = categories.Single(x => x.Name.Equals(categoryName)).Title;
            productsCategoriesAndPhoneOrders.CategoryViewStyles = categoryViewStyles;
            productsCategoriesAndPhoneOrders.Products = products;
            productsCategoriesAndPhoneOrders.Categories = categories;
            productsCategoriesAndPhoneOrders.PhoneOrders = phoneOrders;
            
            return View(productsCategoriesAndPhoneOrders);
        }
        
        [HttpPost]
        public string TestMethod(string id)
        {

            return String.Empty;
        }
    }
}
