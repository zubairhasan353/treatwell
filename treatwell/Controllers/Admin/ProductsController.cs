using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using treatwell.Models;

namespace treatwell.Controllers.Admin
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;
        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Products
        public ActionResult Index()
        {
            var prodList = _context.Products.ToList();
            return View(prodList);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            if (ModelState.IsValid)
            {
                var ProductsinDB = _context.Products.SingleOrDefault(c => c.Id == id);
                if (ProductsinDB == null)
                    return RedirectToAction("Index");
                return View(ProductsinDB);
            }
            else
                return RedirectToAction("Index");
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Products Products)
        {
            try
            {
                // TODO: Add insert logic here
                Products.ApplicationUserCreatedById = "4af95f1c-0f73-4df9-bb6d-166a07b6e5f4";
                Products.ApplicationUserCreatedDate = DateTime.Now;
                Products.ApplicationUserLastUpdatedById = Products.ApplicationUserCreatedById;
                Products.ApplicationUserLastUpdatedDate = DateTime.Now;

                _context.Products.Add(Products);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            var ProductsinDB = _context.Products.SingleOrDefault(c => c.Id == id);
            return View(ProductsinDB);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Products Products)
        {
            try
            {
                // TODO: Add update logic here
                var ProductsinDB = _context.Products.Single(c => c.Id == Products.Id);
                ProductsinDB.ProductName = Products.ProductName;
                ProductsinDB.Ingrediants = Products.Ingrediants;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            var ProductsinDB = _context.Products.SingleOrDefault(c => c.Id == id);
            if (ProductsinDB == null)
            {
                return HttpNotFound();
            }
            return View(ProductsinDB);
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Products Products)
        {
            try
            {
                // TODO: Add delete logic here
                var ProductsinDB = _context.Products.Single(c => c.Id == Products.Id);
                _context.Products.Remove(ProductsinDB);
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