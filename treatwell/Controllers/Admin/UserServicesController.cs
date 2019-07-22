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
    public class UserServicesController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public UserServicesController()
        {

        }
        // GET: UserServices
        public ActionResult Index()
        {
            var usList = _context.UserServices.Include(c => c.subCategories).
                Include(d => d.User).ToList();
            return View(usList);
        }

        // GET: UserServices/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserServices/Create
        public ActionResult Create(UserServices userServices)
        {
            var viewModel = new UserServicesViewModel
            {
                UserServices = userServices,
                User = _context.Users.ToList(),
                SubCategories = _context.subCategories.ToList()
            };
            return View("Create", viewModel);
        }

        // POST: UserServices/Create
        [HttpPost]
        public ActionResult Create(UserServices userServices, string PostMethod)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new UserServicesViewModel
                    {
                        UserServices = userServices,
                        User = _context.Users.ToList(),
                        SubCategories = _context.subCategories.ToList()
                    };
                    return View("Create", viewModel);
                }

                var linqQuery = _context.UserServices.Count(u => u.UserId == userServices.UserId && u.subCategoriesId == userServices.subCategoriesId);

                if (linqQuery != 0)
                {
                    var viewModel = new UserServicesViewModel
                    {
                        UserServices = userServices,
                        User = _context.Users.ToList(),
                        SubCategories = _context.subCategories.ToList()
                    };

                    viewModel.ErrorMessage = "ERROR: Employee against venue has already stored in the database............";
                    return View("Create", viewModel);
                }

                userServices.ApplicationUserCreatedById = "4af95f1c-0f73-4df9-bb6d-166a07b6e5f4";
                userServices.ApplicationUserCreatedDate = DateTime.Now;
                userServices.ApplicationUserLastUpdatedById = userServices.ApplicationUserCreatedById;
                userServices.ApplicationUserLastUpdatedDate = DateTime.Now;
                // TODO: Add insert logic here
                _context.UserServices.Add(userServices);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserServices/Edit/5
        public ActionResult Edit(int id)
        {
            var userServices = _context.UserServices.SingleOrDefault(c => c.Id == id);

            if (userServices == null)
                return HttpNotFound();

            var viewModel = new UserServicesViewModel
            {
                UserServices = userServices,
                User = _context.Users.ToList(),
                SubCategories = _context.subCategories.ToList()
            };

            return View(viewModel);
        }

        // POST: UserServices/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserServices userServices)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new UserServicesViewModel
                    {
                        UserServices = userServices,
                        User = _context.Users.ToList(),
                        SubCategories = _context.subCategories.ToList()
                    };

                    //return View("CustomerForm", viewModel);
                }

                var linqQuery = _context.UserVenues.Count(u => u.UserId == userServices.UserId && u.VenuesId == userServices.subCategoriesId);

                if (linqQuery != 0)
                {
                    var viewModel = new UserServicesViewModel
                    {
                        UserServices = userServices,
                        User = _context.Users.ToList(),
                        SubCategories = _context.subCategories.ToList()
                    };

                    viewModel.ErrorMessage = "ERROR: Employee against venue has already stored in the database............";
                    return View("Create", viewModel);
                }

                // TODO: Add update logic here
                var usinDb = _context.UserServices.Single(s => s.Id == userServices.Id);
                usinDb.UserId = userServices.UserId;
                usinDb.subCategoriesId = userServices.subCategoriesId;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: UserServices/Delete/5
        public ActionResult Delete(int id)
        {
            var us = _context.UserServices.Include(c => c.subCategories).Include(d => d.User).SingleOrDefault(c => c.Id == id);

            if (us == null)
                return RedirectToAction("Index");

            return View(us);
        }

        // POST: UserServices/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserServices userServices)
        {
            try
            {
                // TODO: Add delete logic here
                var usDb = _context.UserServices.Single(c => c.Id == userServices.Id);
                _context.UserServices.Remove(usDb);
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
