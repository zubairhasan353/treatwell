using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using treatwell.Models;
using System.IO;
using treatwell.ViewModels;
using System.Security.Cryptography;
using System.Text;

namespace treatwell.Controllers.Admin
{
    [Authorize]
    public class VenuesController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public VenuesController()
        {

        }
            // GET: Venues
        public ActionResult Index()
        {
            var venueList = _context.venues.Include(c => c.City).ToList();
            return View(venueList);
        }

        // GET: Venues/Details/5
        public ActionResult Details(int id)
        {
            var venue = _context.venues.Include(c => c.City).SingleOrDefault(c => c.Id == id);

            if (venue == null)
                return Index();

            return View(venue);
        }

        // GET: Venues/Create
        public ActionResult Create(Venues venues)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new VenueCitiesViewModel
                {
                    Venues = venues,
                    Cities = _context.Cities.ToList()
                };
                return View("Create", viewModel);
            }
            else
                return RedirectToAction("Index");
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // POST: Venues/Create
        [HttpPost]
        public ActionResult Create(Venues venues, HttpPostedFileBase ImagePath)
        {
           try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new VenueCitiesViewModel
                    {
                        Venues = venues,
                        Cities = _context.Cities.ToList()
                    };
                }

                venues.ApplicationUserCreatedById = "4af95f1c-0f73-4df9-bb6d-166a07b6e5f4";
                venues.ApplicationUserCreatedDate = DateTime.Now;
                venues.ApplicationUserLastUpdatedById = venues.ApplicationUserCreatedById;
                venues.ApplicationUserLastUpdatedDate = DateTime.Now;
                // TODO: Add insert logic here
                _context.venues.Add(venues);
                _context.SaveChanges();
                return RedirectToAction("CreateImages/" + venues.Id);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateImages(int Id)
        {
            var imageList = _context.VenueImages.Where(vm => vm.VenuesId == Id).ToList();
            return View(imageList);
        }

        [HttpPost]
        public ActionResult CreateImages(VenueImages vm, int Id, HttpPostedFileBase ImagePath)
        {
            string FullPath;
            string HashedData;

            if (ImagePath != null)
            {
                string extension = Path.GetExtension(ImagePath.FileName);
                HashedData = ComputeSha256Hash(ImagePath.FileName);
                FullPath = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(HashedData)) + extension;
                ImagePath.SaveAs(FullPath);
                FullPath = "~/Images/" + Path.GetFileName(HashedData) + extension;

                vm.VenuesId = Id;
                vm.ImagePath = FullPath;
                vm.ApplicationUserCreatedById = "4af95f1c-0f73-4df9-bb6d-166a07b6e5f4";
                vm.ApplicationUserCreatedDate = DateTime.Now;
                vm.ApplicationUserLastUpdatedById = vm.ApplicationUserCreatedById;
                vm.ApplicationUserLastUpdatedDate = DateTime.Now;

                _context.VenueImages.Add(vm);
                _context.SaveChanges();
            }

            return RedirectToAction("CreateImages/" + Id);
        }

        public ActionResult EditImage(int Id)                                               //Id = ImageId
        {
            var venueImage = _context.VenueImages.SingleOrDefault(v => v.Id == Id);
            return View(venueImage);
        }

        [HttpPost]
        public ActionResult EditImage(VenueImages vm, int Id, HttpPostedFileBase ImagePath)         //Id = ImageId
        {
            string FullPath;
            string HashedData;
            var VenueId = _context.VenueImages.SingleOrDefault(v => v.Id == vm.Id).VenuesId;

            if (ImagePath != null)
            {
                string extension = Path.GetExtension(ImagePath.FileName);
                HashedData = ComputeSha256Hash(ImagePath.FileName);
                FullPath = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(HashedData)) + extension;
                ImagePath.SaveAs(FullPath);
                FullPath = "~/Images/" + Path.GetFileName(HashedData) + extension;

                vm.ApplicationUserLastUpdatedById = vm.ApplicationUserCreatedById;
                vm.ApplicationUserLastUpdatedDate = DateTime.Now;

                var imageinDb = _context.VenueImages.Single(v => v.Id == vm.Id);
                imageinDb.ImagePath = FullPath;
                _context.SaveChanges();
            }
            return RedirectToAction("CreateImages/" + VenueId);
        }

        public ActionResult DeleteImage(int id)
        {
            var venueImage = _context.VenueImages.SingleOrDefault(c => c.Id == id);
            if (venueImage == null)
                return HttpNotFound();

            return View(venueImage);
        }

        // POST: VenuesImages/Delete/5
        [HttpPost]
        public ActionResult DeleteImage(int id, VenueImages vm)
        {
            try
            {
                var venueImage = _context.VenueImages.Single(c => c.Id == vm.Id);
                var VenueId = _context.VenueImages.SingleOrDefault(v => v.Id == vm.Id).VenuesId;
                _context.VenueImages.Remove(venueImage);
                _context.SaveChanges();
                return RedirectToAction("CreateImages/" + VenueId);
            }
            catch
            {
                return View();
            }
        }

    // GET: Venues/Edit/5
    public ActionResult Edit(int id)
        {
            var venues = _context.venues.SingleOrDefault(c => c.Id == id);

            if (venues == null)
                return HttpNotFound();

            var viewModel = new VenueCitiesViewModel 
            {
                Venues = venues,
                Cities = _context.Cities.ToList()
            };

            return View(viewModel);
        }

        // POST: Venues/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Venues venues)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new VenueCitiesViewModel
                    {
                        Venues = venues,
                        Cities = _context.Cities.ToList()
                    };

                    //return View("CustomerForm", viewModel);
                }
                // TODO: Add update logic here
                var venueinDb = _context.venues.Single(v => v.Id == venues.Id);
                venueinDb.VenueName = venues.VenueName;
                venueinDb.Address = venues.Address;
                venueinDb.Street = venues.Street;
                venueinDb.Sector = venues.Sector;
                venueinDb.CityId = venues.CityId;
                venueinDb.Introduction = venues.Introduction;
                venueinDb.ContactNo = venues.ContactNo;
                //venueinDb.ImagePath = venues.ImagePath;

                _context.SaveChanges();
                return RedirectToAction("CreateImages/" + id);
            }
            catch
            {
                return View();
            }
        }

        // GET: Venues/Delete/5
        public ActionResult Delete(int id)
        {
            var venue = _context.venues.Include(c => c.City).SingleOrDefault(c => c.Id == id);

            if (venue == null)
                return HttpNotFound();

            return View(venue);
        }

        // POST: Venues/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Venues venues)
        {
            try
            {
                // TODO: Add delete logic here
                var venuesinDb = _context.venues.Single(c => c.Id == venues.Id);
                _context.venues.Remove(venuesinDb);
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
