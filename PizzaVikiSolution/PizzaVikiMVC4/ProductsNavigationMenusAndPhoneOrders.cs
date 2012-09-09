using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaViki_DAL;

namespace PizzaVikiMVC4
{
    public class ProductsNavigationMenusAndPhoneOrders
    {
        private List<Product> products;
        private List<PhoneOrder> phoneOrders;
        private List<NavigationMenu> navigationMenus;

        public ProductsNavigationMenusAndPhoneOrders()
        {
            this.products = new List<Product>();
            this.phoneOrders = new List<PhoneOrder>();
            this.navigationMenus = new List<NavigationMenu>();
        }

        public List<Product> Products
        {
            get
            {
                return this.products;
            }
            set
            {
                this.products = value;
            }
        }

        public List<PhoneOrder> PhoneOrders
        {
            get
            {
                return this.phoneOrders;
            }
            set
            {
                this.phoneOrders = value;
            }
        }

        public List<NavigationMenu> NavigationMenus
        {
            get
            {
                return this.navigationMenus;
            }
            set
            {
                this.navigationMenus = value;
            }
        }
    }
}