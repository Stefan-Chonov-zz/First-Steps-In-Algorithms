using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaViki_DAL;

namespace PizzaVikiMVC4
{
    public class CategoriesAndPhoneOrders
    {
        private List<Category> categories;
        private List<PhoneOrder> phoneOrders;
        private List<Category> navigationMenus;
        private List<SubArea> subAreas;

        public CategoriesAndPhoneOrders()
        {
            this.categories = new List<Category>();
            this.phoneOrders = new List<PhoneOrder>();
            this.navigationMenus = new List<Category>();
        }

        public List<Category> Categories
        {
            get
            {
                return this.categories;
            }
            set
            {
                this.categories = value;
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

        public List<Category> NavigationMenus
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

        public List<SubArea> SubAreas 
        {
            get
            {
                return this.subAreas;
            }
            set
            {
                this.subAreas = value;
            }
        }
    }
}