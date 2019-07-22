using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using treatwell.Models;
using treatwell.ViewModels;
using System.Data.Entity;
using WebMatrix.Data;

namespace treatwell.Controllers.Admin
{
    [Authorize]
    public class EmployeeAvailabilityController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public EmployeeAvailabilityController()
        {

        }
        // GET: EmployeeAvailability
        public ActionResult Index()
        {
            var EmpAvailList = _context.EmployeeAvailabilities.Include(c => c.UserVenues.User).Include(c => c.UserVenues.Venues).Include(c => c.Day).ToList();
            return View(EmpAvailList);
        }

        // GET: EmployeeAvailability/Details/5
        public ActionResult Details(int id)
        {
            var EmpAvail = _context.EmployeeAvailabilities.Include(c => c.UserVenues.User).Include(c => c.UserVenues.Venues).Include(c => c.Day).SingleOrDefault(c => c.Id == id);

            if (EmpAvail == null)
                return RedirectToAction("Index");

            if (id == 0)
                RedirectToAction("Index");
            return View(EmpAvail);
        }

        // GET: EmployeeAvailability/Create
        public ActionResult Create(EmployeeAvailability employeeAvailability)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EmployeeAvailabilityViewModel
                {
                    EmployeeAvailability = employeeAvailability,
                    UserVenues= _context.UserVenues.ToList(),
                    Days = _context.Days.ToList()
                };
                return View("Create", viewModel);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: EmployeeAvailability/Create
        [HttpPost]
        public ActionResult Create(EmployeeAvailability employeeAvailability, string PostMethod)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new EmployeeAvailabilityViewModel
                    {
                        EmployeeAvailability = employeeAvailability,
                        UserVenues = _context.UserVenues.ToList(),
                        Days = _context.Days.ToList()
                    };
                }
                employeeAvailability.ApplicationUserCreatedById = "4af95f1c-0f73-4df9-bb6d-166a07b6e5f4";
                employeeAvailability.ApplicationUserCreatedDate = DateTime.Now;
                employeeAvailability.ApplicationUserLastUpdatedById = employeeAvailability.ApplicationUserCreatedById;
                employeeAvailability.ApplicationUserLastUpdatedDate = DateTime.Now;
                // TODO: Add insert logic here
                _context.EmployeeAvailabilities.Add(employeeAvailability);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeAvailability/Edit/5
        public ActionResult Edit(int id)
        {
            var employeeAvailability = _context.EmployeeAvailabilities.SingleOrDefault(c => c.Id == id);

            if (employeeAvailability == null)
                return HttpNotFound();

            var viewModel = new EmployeeAvailabilityViewModel
            {
                EmployeeAvailability = employeeAvailability,
                UserVenues = _context.UserVenues.ToList(),
                Days = _context.Days.ToList()
            };

            return View(viewModel);
        }

        // POST: EmployeeAvailability/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployeeAvailability employeeAvailability)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new EmployeeAvailabilityViewModel
                    {
                        EmployeeAvailability = employeeAvailability,
                        UserVenues = _context.UserVenues.ToList(),
                        Days = _context.Days.ToList()
                    };

                    //return View("CustomerForm", viewModel);
                }
                // TODO: Add update logic here
                var EmpAvailinDb = _context.EmployeeAvailabilities.Single(v => v.Id == employeeAvailability.Id);
                EmpAvailinDb.UserVenuesId = employeeAvailability.UserVenuesId;
                EmpAvailinDb.DayID = employeeAvailability.DayID;
                EmpAvailinDb.StartTime = employeeAvailability.StartTime;
                EmpAvailinDb.EndTime = employeeAvailability.EndTime;
                
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeAvailability/Delete/5
        public ActionResult Delete(int id)
        {
            var EmpAvail = _context.EmployeeAvailabilities.Include(c => c.UserVenues).Include(c => c.Day).SingleOrDefault(c => c.Id == id);

            if (EmpAvail == null)
                return HttpNotFound();

            return View(EmpAvail);
        }

        // POST: EmployeeAvailability/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EmployeeAvailability employeeAvailability)
        {
            try
            {
                // TODO: Add delete logic here
                var EmpAvailinDb = _context.EmployeeAvailabilities.Single(c => c.Id == employeeAvailability.Id);
                _context.EmployeeAvailabilities.Remove(EmpAvailinDb);
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
