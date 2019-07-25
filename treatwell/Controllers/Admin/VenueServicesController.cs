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
    public class VenueServicesController : Controller
    {
        private ApplicationDbContext _context;
        public VenueServicesController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET: VenueServices
        public ActionResult Index()
        {
            var vsList = _context.VenueServices.Include(c => c.Venues).
                Include(d => d.SubCategories).ToList();
            return View(vsList);
        }

        // GET: VenueServices/Details/5
        public ActionResult Details(int id)
        {
            var vs = _context.VenueServices.Include(c => c.Venues).
                Include(d => d.SubCategories).SingleOrDefault(c => c.Id == id);

            if (vs == null)
                return Index();

            return View(vs);
        }

        // GET: VenueServices/Create
        public ActionResult Create(VenueServices vs)
        {
            try
            {
                var viewModel = new VenueServiceViewModel
                {
                    VS = vs,
                    Venues = _context.venues.ToList(),
                    SubCategories = _context.subCategories.ToList()
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
        public ActionResult Create(VenueServices vs, string PostMethod)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var viewModel = new VenueServiceViewModel
                    {
                        VS = vs,
                        Venues = _context.venues.ToList(),
                        SubCategories = _context.subCategories.ToList()
                    };
                }
                vs.ApplicationUserCreatedById = "4af95f1c-0f73-4df9-bb6d-166a07b6e5f4";
                vs.ApplicationUserCreatedDate = DateTime.Now;
                vs.ApplicationUserLastUpdatedById = vs.ApplicationUserCreatedById;
                vs.ApplicationUserLastUpdatedDate = DateTime.Now;
                // TODO: Add insert logic here
                _context.VenueServices.Add(vs);
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
            var vs = _context.VenueServices.SingleOrDefault(c => c.Id == id);

            if (vs == null)
                return HttpNotFound();

            var viewModel = new VenueServiceViewModel
            {
                VS = vs,
                Venues = _context.venues.ToList(),
                SubCategories = _context.subCategories.ToList()
            };

            return View(viewModel);
        }

        // POST: VenueServices/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VenueServices vs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new VenueServiceViewModel
                    {
                        VS = vs,
                        Venues = _context.venues.ToList(),
                        SubCategories = _context.subCategories.ToList()
                    };

                    //return View("CustomerForm", viewModel);
                }
                // TODO: Add update logic here
                var vsinDb = _context.VenueServices.Single(s => s.Id == vs.Id);
                vsinDb.SubCategoriesId = vs.SubCategoriesId;
                vsinDb.VenuesId = vs.VenuesId;
                vsinDb.ActualCostPrice = vs.ActualCostPrice;
                vsinDb.DiscountedPercentage = vs.DiscountedPercentage;

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
            var vs = _context.VenueServices.Include(c => c.Venues).
                Include(d => d.SubCategories).SingleOrDefault(c => c.Id == id);

            if (vs == null)
                return HttpNotFound();

            return View(vs);
        }

        // POST: VenueServices/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, VenueServices vs)
        {
            try
            {
                // TODO: Add delete logic here
                var vsinDb = _context.VenueServices.Single(c => c.Id == vs.Id);
                _context.VenueServices.Remove(vsinDb);
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
