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
    public class CategoriesViewStylesController : Controller
    {
        private PizzaVikiCategoriesEntities db = new PizzaVikiCategoriesEntities();

        //
        // GET: /CategoriesViewStyles/

        public ActionResult Index()
        {
            var categoriesviewstyles = db.CategoriesViewStyles.Include("Category");
            return View(categoriesviewstyles.ToList());
        }

        //
        // GET: /CategoriesViewStyles/Details/5

        public ActionResult Details(int id = 0)
        {
            CategoryViewStyle categoryviewstyle = db.CategoriesViewStyles.Single(c => c.id == id);
            if (categoryviewstyle == null)
            {
                return HttpNotFound();
            }
            return View(categoryviewstyle);
        }

        //
        // GET: /CategoriesViewStyles/Create

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "id", "Name");
            return View();
        }

        //
        // POST: /CategoriesViewStyles/Create

        [HttpPost]
        public ActionResult Create(CategoryViewStyle categoryviewstyle)
        {
            if (ModelState.IsValid)
            {
                db.CategoriesViewStyles.AddObject(categoryviewstyle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "id", "Name", categoryviewstyle.CategoryID);
            return View(categoryviewstyle);
        }

        //
        // GET: /CategoriesViewStyles/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CategoryViewStyle categoryviewstyle = db.CategoriesViewStyles.Single(c => c.id == id);
            if (categoryviewstyle == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "id", "Name", categoryviewstyle.CategoryID);
            return View(categoryviewstyle);
        }

        //
        // POST: /CategoriesViewStyles/Edit/5

        [HttpPost]
        public ActionResult Edit(CategoryViewStyle categoryviewstyle)
        {
            if (ModelState.IsValid)
            {
                db.CategoriesViewStyles.Attach(categoryviewstyle);
                db.ObjectStateManager.ChangeObjectState(categoryviewstyle, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "id", "Name", categoryviewstyle.CategoryID);
            return View(categoryviewstyle);
        }

        //
        // GET: /CategoriesViewStyles/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CategoryViewStyle categoryviewstyle = db.CategoriesViewStyles.Single(c => c.id == id);
            if (categoryviewstyle == null)
            {
                return HttpNotFound();
            }
            return View(categoryviewstyle);
        }

        //
        // POST: /CategoriesViewStyles/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryViewStyle categoryviewstyle = db.CategoriesViewStyles.Single(c => c.id == id);
            db.CategoriesViewStyles.DeleteObject(categoryviewstyle);
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