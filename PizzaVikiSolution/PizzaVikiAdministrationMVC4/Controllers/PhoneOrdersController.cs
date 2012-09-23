using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaViki_DAL;

namespace PizzaVikiAdministrationMVC4.Controllers
{
    public class PhoneOrdersController : Controller
    {
        private PizzaVikiCategoriesEntities db = new PizzaVikiCategoriesEntities();

        //
        // GET: /PhoneOrders/

        public ActionResult Index()
        {
            return View(db.PhoneOrders.ToList());
        }

        //
        // GET: /PhoneOrders/Details/5

        public ActionResult Details(int id = 0)
        {
            PhoneOrder phoneorder = db.PhoneOrders.Single(p => p.id == id);
            if (phoneorder == null)
            {
                return HttpNotFound();
            }
            return View(phoneorder);
        }

        //
        // GET: /PhoneOrders/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PhoneOrders/Create

        [HttpPost]
        public ActionResult Create(PhoneOrder phoneorder)
        {
            if (ModelState.IsValid)
            {
                db.PhoneOrders.AddObject(phoneorder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phoneorder);
        }

        //
        // GET: /PhoneOrders/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PhoneOrder phoneorder = db.PhoneOrders.Single(p => p.id == id);
            if (phoneorder == null)
            {
                return HttpNotFound();
            }
            return View(phoneorder);
        }

        //
        // POST: /PhoneOrders/Edit/5

        [HttpPost]
        public ActionResult Edit(PhoneOrder phoneorder)
        {
            if (ModelState.IsValid)
            {
                db.PhoneOrders.Attach(phoneorder);
                db.ObjectStateManager.ChangeObjectState(phoneorder, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phoneorder);
        }

        //
        // GET: /PhoneOrders/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PhoneOrder phoneorder = db.PhoneOrders.Single(p => p.id == id);
            if (phoneorder == null)
            {
                return HttpNotFound();
            }
            return View(phoneorder);
        }

        //
        // POST: /PhoneOrders/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PhoneOrder phoneorder = db.PhoneOrders.Single(p => p.id == id);
            db.PhoneOrders.DeleteObject(phoneorder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}