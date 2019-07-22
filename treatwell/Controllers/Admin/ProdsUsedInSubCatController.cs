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
    public class ProdsUsedInSubCatController : Controller
    {
        private ApplicationDbContext _context;
        public ProdsUsedInSubCatController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: ProdsUsedInSubCat
        public ActionResult Index()
        {
            var pscList = _context.prodsUsedInSubCats.Include(c => c.Product).
                Include(d => d.SubCat).ToList();
            return View(pscList);
        }

        // GET: VenueServices/Details/5
        public ActionResult Details(int id)
        {
            var pscList = _context.prodsUsedInSubCats.Include(c => c.Product).
                Include(d => d.SubCat).SingleOrDefault(c => c.Id == id);

            if (pscList == null)
                return Index();

            return View(pscList);
        }

        // GET: VenueServices/Create
        public ActionResult Create(ProdsUsedInSubCat psc)
        {
            try
            {
                var viewModel = new ProductsSubCatsViewModel
                {
                    Psc = psc,
                    Products = _context.Products.ToList(),
                    SubCat = _context.subCategories.ToList()
                };
                return View("Create", viewModel);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // POST: VenueServices/Create
        [HttpPost]
        public ActionResult Create(ProdsUsedInSubCat psc, string PostMethod)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var viewModel = new ProductsSubCatsViewModel
                    {
                        Psc = psc,
                        Products = _context.Products.ToList(),
                        SubCat = _context.subCategories.ToList()
                    };
                }
                psc.ApplicationUserCreatedById = "4af95f1c-0f73-4df9-bb6d-166a07b6e5f4";
                psc.ApplicationUserCreatedDate = DateTime.Now;
                psc.ApplicationUserLastUpdatedById = psc.ApplicationUserCreatedById;
                psc.ApplicationUserLastUpdatedDate = DateTime.Now;
                // TODO: Add insert logic here
                _context.prodsUsedInSubCats.Add(psc);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: VenueServices/Edit/5
        public ActionResult Edit(int id)
        {
            var psc = _context.prodsUsedInSubCats.SingleOrDefault(c => c.Id == id);

            if (psc == null)
                return HttpNotFound();

            var viewModel = new ProductsSubCatsViewModel
            {
                Psc = psc,
                Products = _context.Products.ToList(),
                SubCat = _context.subCategories.ToList()
            };

            return View(viewModel);
        }

        // POST: VenueServices/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProdsUsedInSubCat psc)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new ProductsSubCatsViewModel
                    {
                        Psc = psc,
                        Products = _context.Products.ToList(),
                        SubCat = _context.subCategories.ToList()
                    };

                    //return View("CustomerForm", viewModel);
                }
                // TODO: Add update logic here
                var pscinDb = _context.prodsUsedInSubCats.Single(s => s.Id == psc.Id);
                pscinDb.SubCatId = psc.SubCatId;
                pscinDb.ProductId = psc.ProductId;
                pscinDb.QtyUsed = psc.QtyUsed;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Index");
            }
        }

        // GET: VenueServices/Delete/5
        public ActionResult Delete(int id)
        {
            var psc = _context.prodsUsedInSubCats.Include(c => c.Product).
                Include(d => d.SubCat).SingleOrDefault(c => c.Id == id);

            if (psc == null)
                return HttpNotFound();

            return View(psc);
        }

        // POST: VenueServices/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProdsUsedInSubCat psc)
        {
            try
            {
                // TODO: Add delete logic here
                var pscinDb = _context.prodsUsedInSubCats.Single(c => c.Id == psc.Id);
                _context.prodsUsedInSubCats.Remove(pscinDb);
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