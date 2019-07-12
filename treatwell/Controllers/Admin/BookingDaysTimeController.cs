using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace treatwell.Controllers.Admin
{
    public class BookingDaysTimeController : Controller
    {
        // GET: BookingDaysTime
        public ActionResult Index()
        {
            return View();
        }

        // GET: BookingDaysTime/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookingDaysTime/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingDaysTime/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingDaysTime/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookingDaysTime/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingDaysTime/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookingDaysTime/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
