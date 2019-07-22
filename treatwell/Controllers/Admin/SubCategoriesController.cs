using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using treatwell.Models;
using treatwell.ViewModels;
using System.Data.Entity;

namespace treatwell.Controllers.Admin
{
    [Authorize]
    public class SubCategoriesController : Controller
    {
        private ApplicationDbContext _context;
        public SubCategoriesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: SubCategories
        public ActionResult Index()
        {
            var subCatList = _context.subCategories.Include(c => c.Category).ToList();
            return View(subCatList);
        }

        // GET: SubCategories/Details/5
        public ActionResult Details(int id)
        {
            var subCat = _context.subCategories.Include(c => c.Category).SingleOrDefault(c => c.Id == id);

            if (subCat == null)
                return Index();

            return View(subCat);
        }

        // GET: SubCategories/Create
        public ActionResult Create(SubCategories subCategories)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CatSubCatViewModel
                {
                    subCategories = subCategories,
                    categories = _context.categories.ToList()
                };
                return View("Create", viewModel);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: SubCategories/Create
        [HttpPost]
        public ActionResult Create(SubCategories subCategories, string PostMethod)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new CatSubCatViewModel
                    {
                        subCategories = subCategories,
                        categories = _context.categories.ToList()
                    };
                }
                subCategories.ApplicationUserCreatedById = "4af95f1c-0f73-4df9-bb6d-166a07b6e5f4";
                subCategories.ApplicationUserCreatedDate = DateTime.Now;
                subCategories.ApplicationUserLastUpdatedById = subCategories.ApplicationUserCreatedById;
                subCategories.ApplicationUserLastUpdatedDate = DateTime.Now;
                // TODO: Add insert logic here
                _context.subCategories.Add(subCategories);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SubCategories/Edit/5
        public ActionResult Edit(int id)
        {
            var subCat = _context.subCategories.SingleOrDefault(c => c.Id == id);

            if (subCat == null)
                return HttpNotFound();

            var viewModel = new CatSubCatViewModel
            {
                subCategories = subCat,
                categories = _context.categories.ToList()
            };

            return View(viewModel);
        }

        // POST: SubCategories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SubCategories subCategories)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new CatSubCatViewModel
                    {
                        subCategories = subCategories,
                        categories = _context.categories.ToList()
                    };

                    //return View("CustomerForm", viewModel);
                }
                // TODO: Add update logic here
                var subcatinDb = _context.subCategories.Single(s => s.Id == subCategories.Id);
                subcatinDb.CategoryID = subCategories.CategoryID;
                subcatinDb.SubCatDesc = subCategories.SubCatDesc;
                subcatinDb.TimeInMinutes = subCategories.TimeInMinutes;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: SubCategories/Delete/5
        public ActionResult Delete(int id)
        {
            var subcat = _context.subCategories.Include(c => c.Category).SingleOrDefault(c => c.Id == id);

            if (subcat== null)
                return HttpNotFound();

            return View(subcat);
        }

        // POST: SubCategories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SubCategories subCategories)
        {
            try
            {
                // TODO: Add delete logic here
                var subCatinDb = _context.subCategories.Single(c => c.Id == subCategories.Id);
                _context.subCategories.Remove(subCatinDb);
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
