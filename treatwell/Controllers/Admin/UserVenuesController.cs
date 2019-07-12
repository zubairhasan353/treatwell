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
    public class UserVenuesController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public UserVenuesController()
        {

        }
        // GET: UserVenues
        public ActionResult Index()
        {
            var uvList = _context.UserVenues.Include(c => c.Venues).
                Include(d => d.User).ToList();
            return View(uvList);
        }

        // GET: UserVenues/Details/5
        public ActionResult Details(int id)
        {
            var uv = _context.UserVenues.Include(c => c.Venues).Include(d => d.User).SingleOrDefault(c => c.Id == id);

            if (uv == null)
                return Index();

            return View(uv);
        }

        // GET: UserVenues/Create
        public ActionResult Create(UserVenues userVenues)
        {
            var viewModel = new UserVenuesViewModel
            {
                UserVenues = userVenues,
                User = _context.Users.ToList(),
                Venues = _context.venues.ToList()
            };
            return View("Create", viewModel);
        }

        // POST: UserVenues/Create
        [HttpPost]
        public ActionResult Create(UserVenues userVenues, string PostMethod)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new UserVenuesViewModel
                    {
                        UserVenues = userVenues,
                        User = _context.Users.ToList(),
                        Venues = _context.venues.ToList()
                    };
                }

                var linqQuery = _context.UserVenues.Count(u => u.UserId == userVenues.UserId && u.VenuesId == userVenues.VenuesId);

                if (linqQuery != 0)
                {
                    var viewModel = new UserVenuesViewModel
                    {
                        UserVenues = userVenues,
                        User = _context.Users.ToList(),
                        Venues = _context.venues.ToList()
                    };

                    viewModel.ErrorMessage = "ERROR: Employee against venue has already stored in the database............";
                    return View("Create", viewModel);
                }
                
                userVenues.ApplicationUserCreatedById = "4af95f1c-0f73-4df9-bb6d-166a07b6e5f4";
                userVenues.ApplicationUserCreatedDate = DateTime.Now;
                userVenues.ApplicationUserLastUpdatedById = userVenues.ApplicationUserCreatedById;
                userVenues.ApplicationUserLastUpdatedDate = DateTime.Now;
                        // TODO: Add insert logic here
                _context.UserVenues.Add(userVenues);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserVenues/Edit/5
        public ActionResult Edit(int id)
        {
            var userVenues = _context.UserVenues.SingleOrDefault(c => c.Id == id);

            if (userVenues == null)
                return HttpNotFound();

            var viewModel = new UserVenuesViewModel
            {
                UserVenues = userVenues,
                User = _context.Users.ToList(),
                Venues = _context.venues.ToList()
            };

            return View(viewModel);
        }

        // POST: UserVenues/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserVenues userVenues)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new UserVenuesViewModel
                    {
                        UserVenues = userVenues,
                        User = _context.Users.ToList(),
                        Venues = _context.venues.ToList()
                    };

                    //return View("CustomerForm", viewModel);
                }

                var linqQuery = _context.UserVenues.Count(u => u.UserId == userVenues.UserId && u.VenuesId == userVenues.VenuesId);

                if (linqQuery != 0)
                {
                    var viewModel = new UserVenuesViewModel
                    {
                        UserVenues = userVenues,
                        User = _context.Users.ToList(),
                        Venues = _context.venues.ToList()
                    };

                    viewModel.ErrorMessage = "ERROR: Employee against venue has already stored in the database............";
                    return View("Create", viewModel);
                }

                // TODO: Add update logic here
                var uvinDb = _context.UserVenues.Single(s => s.Id == userVenues.Id);
                uvinDb.UserId = userVenues.UserId;
                uvinDb.VenuesId = userVenues.VenuesId;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: UserVenues/Delete/5
        public ActionResult Delete(int id)
        {
            var uv = _context.UserVenues.Include(c => c.Venues).Include(d => d.User).SingleOrDefault(c => c.Id == id);

            if (uv == null)
                return RedirectToAction("Index");

            return View(uv);
        }

        // POST: UserVenues/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserVenues userVenues)
        {
            try
            {
                // TODO: Add delete logic here
                var uvDb = _context.UserVenues.Single(c => c.Id == userVenues.Id);
                _context.UserVenues.Remove(uvDb);
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
