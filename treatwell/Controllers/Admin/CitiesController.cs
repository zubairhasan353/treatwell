using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using treatwell.Models;

namespace treatwell.Controllers.Admin
{
    public class CitiesController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public CitiesController()
        {

        }
        // GET: Cities
        public ActionResult Index()
        {
            var cityList = _context.Cities.ToList();
            return View(cityList);
        }

        // GET: Cities/Details/5
        public ActionResult Details(int id)
        {
            if (ModelState.IsValid)
            {
                var citiesinDb = _context.Cities.SingleOrDefault(c => c.Id == id);
                if (citiesinDb == null)
                    return RedirectToAction("Index");
                return View(citiesinDb);
            }
            else
                return RedirectToAction("Index");
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        [HttpPost]
        public ActionResult Create(Cities cities)
        {
            try
            {
                // TODO: Add insert logic here
                _context.Cities.Add(cities);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int id)
        {
            var citiesinDb = _context.Cities.SingleOrDefault(c => c.Id == id);
            return View(citiesinDb);
        }

        // POST: Cities/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cities cities)
        {
            try
            {
                // TODO: Add update logic here
                var CitiesinDb = _context.Cities.Single(c => c.Id == cities.Id);
                CitiesinDb.CityName = cities.CityName;
                CitiesinDb.PostalCode = cities.PostalCode;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(int id)
        {
            var citiesinDb = _context.Cities.SingleOrDefault(c => c.Id == id);
            if (citiesinDb == null)
            {
                return HttpNotFound();
            }
            return View(citiesinDb);
        }

        // POST: Cities/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Cities cities)
        {
            try
            {
                // TODO: Add delete logic here
                var CitiesinDb = _context.Cities.Single(c => c.Id == cities.Id);
                _context.Cities.Remove(CitiesinDb);
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
