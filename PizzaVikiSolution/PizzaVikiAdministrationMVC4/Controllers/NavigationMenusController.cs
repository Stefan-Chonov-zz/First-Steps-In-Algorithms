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
    public class NavigationMenusController : Controller
    {
        private PizzaVikiCategoriesEntities db = new PizzaVikiCategoriesEntities();

        //
        // GET: /NavigationMenus/

        public ActionResult Index()
        {
            return View(db.NavigationMenus.ToList());
        }

        //
        // GET: /NavigationMenus/Details/5

        public ActionResult Details(int id = 0)
        {
            NavigationMenu navigationmenu = db.NavigationMenus.Single(n => n.id == id);
            if (navigationmenu == null)
            {
                return HttpNotFound();
            }
            return View(navigationmenu);
        }

        //
        // GET: /NavigationMenus/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NavigationMenus/Create

        [HttpPost]
        public ActionResult Create(NavigationMenu navigationmenu)
        {
            if (ModelState.IsValid)
            {
                db.NavigationMenus.AddObject(navigationmenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(navigationmenu);
        }

        //
        // GET: /NavigationMenus/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NavigationMenu navigationmenu = db.NavigationMenus.Single(n => n.id == id);
            if (navigationmenu == null)
            {
                return HttpNotFound();
            }
            return View(navigationmenu);
        }

        //
        // POST: /NavigationMenus/Edit/5

        [HttpPost]
        public ActionResult Edit(NavigationMenu navigationmenu)
        {
            if (ModelState.IsValid)
            {
                db.NavigationMenus.Attach(navigationmenu);
                db.ObjectStateManager.ChangeObjectState(navigationmenu, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(navigationmenu);
        }

        //
        // GET: /NavigationMenus/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NavigationMenu navigationmenu = db.NavigationMenus.Single(n => n.id == id);
            if (navigationmenu == null)
            {
                return HttpNotFound();
            }
            return View(navigationmenu);
        }

        //
        // POST: /NavigationMenus/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NavigationMenu navigationmenu = db.NavigationMenus.Single(n => n.id == id);
            db.NavigationMenus.DeleteObject(navigationmenu);
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