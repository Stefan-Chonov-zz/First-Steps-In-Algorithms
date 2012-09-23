using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaViki_DAL;

namespace PizzaVikiMVC4
{
    public class ProductsCategoriesAndPhoneOrders
    {
        private string categoryName;
        private string categoryTitle;

        private CategoryViewStyle categoryViewStyles;

        private List<Product> products;
        private List<Category> categories;        
        private List<PhoneOrder> phoneOrders;

        public ProductsCategoriesAndPhoneOrders()
        {
            this.categoryName = null;
            this.categoryTitle = null;

            this.categoryViewStyles = new CategoryViewStyle();

            this.products = new List<Product>();
            this.categories = new List<Category>();            
            this.phoneOrders = new List<PhoneOrder>();
        }

        public string CategoryName
        {
            get
            {
                return this.categoryName;
            }
            set
            {
                this.categoryName = value;
            }
        }

        public string CategoryTitle
        {
            get
            {
                return this.categoryTitle;
            }
            set
            {
                this.categoryTitle = value;
            }
        }

        public CategoryViewStyle CategoryViewStyles
        {
            get
            {
                return this.categoryViewStyles;
            }
            set
            {
                this.categoryViewStyles = value;
            }
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
    }
}