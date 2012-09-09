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
    public class PizzasController : Controller
    {
        private PizzaVikiCategoriesEntities db = new PizzaVikiCategoriesEntities();

        //
        // GET: /Pizzas/

        public ActionResult Index()
        {
            var products = db.Products.Include("Category");
            return View(products.ToList());
        }

        //
        // GET: /Pizzas/Details/5

        public ActionResult Details(int id = 0)
        {
            Product product = db.Products.Single(p => p.id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /Pizzas/Create

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "id", "Name");
            return View();
        }

        //
        // POST: /Pizzas/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.AddObject(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "id", "Name", product.CategoryID);
            return View(product);
        }

        //
        // GET: /Pizzas/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Product product = db.Products.Single(p => p.id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "id", "Name", product.CategoryID);
            return View(product);
        }

        //
        // POST: /Pizzas/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Attach(product);
                db.ObjectStateManager.ChangeObjectState(product, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "id", "Name", product.CategoryID);
            return View(product);
        }

        //
        // GET: /Pizzas/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Product product = db.Products.Single(p => p.id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Pizzas/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Single(p => p.id == id);
            db.Products.DeleteObject(product);
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