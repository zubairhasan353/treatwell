using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using treatwell.Models;

namespace treatwell.Controllers.Admin
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public CategoriesController()
        {

        }
        // GET: Categories
        public ActionResult Index()
        {
            var catList = _context.categories.ToList();
            return View(catList);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            if (ModelState.IsValid)
            {
                var catinDb = _context.categories.SingleOrDefault(c => c.Id == id);
                if (catinDb == null)
                    return View("Index");
                return View(catinDb);
            }
            else
                return RedirectToAction("Index");
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(Categories cat)
        {
            try
            {
                // TODO: Add insert logic here
                cat.ApplicationUserCreatedById = "4af95f1c-0f73-4df9-bb6d-166a07b6e5f4";
                cat.ApplicationUserCreatedDate = DateTime.Now;
                cat.ApplicationUserLastUpdatedById = cat.ApplicationUserCreatedById;
                cat.ApplicationUserLastUpdatedDate = DateTime.Now;

                _context.categories.Add(cat);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            var catinDb = _context.categories.SingleOrDefault(c => c.Id == id);
            return View(catinDb);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Categories cat)
        {
            try
            {
                // TODO: Add update logic here
                var catinDb = _context.categories.Single(c => c.Id == cat.Id);
                catinDb.CatDesc = cat.CatDesc;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            var catinDb = _context.categories.SingleOrDefault(c => c.Id == id);
            if (catinDb == null)
            {
                return RedirectToAction("Index");
            }
            return View(catinDb);
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Categories cat)
        {
            try
            {
                var catinDb = _context.categories.Single(c => c.Id == cat.Id);
                _context.categories.Remove(catinDb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
