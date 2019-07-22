using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using treatwell.Models;
using treatwell.ViewModels;

namespace treatwell.Controllers.Admin
{
    [Authorize]
    public class EmployeeAbsentController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public EmployeeAbsentController()
        {

        }
        // GET: EmployeeAbsent
        public ActionResult Index()
        {
            var EmpAbsentList = _context.EmployeeAbsents.Include(c => c.Employee).ToList();
            return View(EmpAbsentList);
        }

        // GET: EmployeeAbsent/Details/5
        public ActionResult Details(int id)
        {
            var EmpAbsent = _context.EmployeeAbsents.Include(c => c.Employee).SingleOrDefault(c => c.Id == id);

            if (EmpAbsent == null)
                return Index();

            if (id == 0)
                RedirectToAction("Index");
            return View(EmpAbsent);
        }

        // GET: EmployeeAbsent/Create
        public ActionResult Create(EmployeeAbsent employeeAbsent)
        {
            var viewModel = new EmployeeAbsentViewModel
        {
            EmployeeAbsent = employeeAbsent,
            Employee = _context.Users.ToList()
        };
        return View("Create", viewModel);
        }

        // POST: EmployeeAbsent/Create
        [HttpPost]
        public ActionResult Create(EmployeeAbsent employeeAbsent, string PostMethod)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new EmployeeAbsentViewModel
                    {
                        EmployeeAbsent = employeeAbsent,
                        Employee = _context.Users.ToList()
                    };
                }

                employeeAbsent.ApplicationUserCreatedById = "4af95f1c-0f73-4df9-bb6d-166a07b6e5f4";
                employeeAbsent.ApplicationUserCreatedDate = DateTime.Now;
                employeeAbsent.ApplicationUserLastUpdatedById = employeeAbsent.ApplicationUserCreatedById;
                employeeAbsent.ApplicationUserLastUpdatedDate = DateTime.Now;
                // TODO: Add insert logic here
                _context.EmployeeAbsents.Add(employeeAbsent);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: EmployeeAbsent/Edit/5
        public ActionResult Edit(int id)
        {
            var employeeAbsent = _context.EmployeeAbsents.SingleOrDefault(c => c.Id == id);

            if (employeeAbsent == null)
                return RedirectToAction("Index");

            var viewModel = new EmployeeAbsentViewModel
            {
                EmployeeAbsent = employeeAbsent,
                Employee = _context.Users.ToList()
            };

            return View(viewModel);
        }

        // POST: EmployeeAbsent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployeeAbsent employeeAbsent)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new EmployeeAbsentViewModel
                    {
                        EmployeeAbsent = employeeAbsent,
                        Employee = _context.Users.ToList()
                    };

                    //return View("CustomerForm", viewModel);
                }
                // TODO: Add update logic here
                var EmpAbsentinDb = _context.EmployeeAbsents.Single(v => v.Id == employeeAbsent.Id);
                EmpAbsentinDb.EmployeeId = employeeAbsent.EmployeeId;
                EmpAbsentinDb.AbsentOn = employeeAbsent.AbsentOn;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeAbsent/Delete/5
        public ActionResult Delete(int id)
        {
            var EmpAbsent = _context.EmployeeAbsents.Include(c => c.Employee).SingleOrDefault(c => c.Id == id);

            if (EmpAbsent == null)
                return RedirectToAction("Index");

            return View(EmpAbsent);
        }

        // POST: EmployeeAbsent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EmployeeAbsent employeeAbsent)
        {
            try
            {
                // TODO: Add delete logic here
                var EmpAbsentinDb = _context.EmployeeAbsents.Single(c => c.Id == employeeAbsent.Id);
                _context.EmployeeAbsents.Remove(EmpAbsentinDb);
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
