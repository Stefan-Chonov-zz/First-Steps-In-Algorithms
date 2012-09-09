using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaViki_DAL;

namespace PizzaVikiMVC4
{
    public class KatmiMenuPhoneOrders
    {
        //private List<Katmi> katmi;
        private List<NavigationMenu> navigationMenus;
        private List<PhoneOrder> phoneOrders;

        public KatmiMenuPhoneOrders()
        {
            //this.katmi = new List<Katmi>();
            this.navigationMenus = new List<NavigationMenu>();
            this.phoneOrders = new List<PhoneOrder>();
        }

        //public List<Katmi> Katmi
        //{
        //    get
        //    {
        //        return this.katmi;
        //    }
        //    set
        //    {
        //        this.katmi = value;
        //    }
        //}

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
    }
}