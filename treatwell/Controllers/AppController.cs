using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using treatwell.Models;
using treatwell.ViewModels;

namespace Angular_MVC.Controllers
{
    public class AppController : Controller
    {
        private ApplicationDbContext _context;
        //public InnerPageViewModel InnerPageViewModel { get; set; }

        public AppController() : base()
        {
            _context = new ApplicationDbContext();

            //this.InnerPageViewModel = new InnerPageViewModel();//has property PageTitle
            //this.ViewData["InnerPageViewModel"] = this.InnerPageViewModel;
        }
        // GET: App
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Discount()
        {
            var cityList = _context.Cities.ToList();
            return View(cityList);
        }

        public ActionResult Business()
        {
            return View();
        }

        public ActionResult SideMenu()
        {
            var cat = _context.categories.ToList();
            List<CatSubViewModel> viewModels = new List<CatSubViewModel>();
            foreach ( var category in cat)
            {
                var sub = _context.subCategories.Where(c => c.CategoryID == category.Id).ToList();
                var viewModel = new CatSubViewModel
                {
                    subCategories = sub,
                    category = category
                };
                viewModels.Add(viewModel);
            }

            return PartialView("~/Views/Shared/_Menu.cshtml", viewModels);
        }

        public ActionResult InnerPage()
        {
            var subCatId = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
            var subCatTable = _context.subCategories.Where(c => c.Id == subCatId).Single(c => c.Id == subCatId);
            var catId = subCatTable.CategoryID;

            var cityList = _context.Cities.Distinct().ToList();
            
            var subcat = _context.subCategories.Where(c => c.CategoryID == catId).ToList();
            var subCatDesc = subCatTable.SubCatDesc;
            var VenueCount = _context.VS.Where(c => c.SubCategoriesId == subCatId).Count();
            var ProductsList = _context.Products.ToList();
            
            var venueServices = _context.VS.Include("Venues").Where(c => c.SubCategoriesId == subCatId).ToList();
            //var venues = _context.VS.Where(c => c.Venues.Id == c.VenuesId).ToList();
            var venuesRaw = (from v in _context.venues
                     join vs in _context.VS on v.Id equals vs.VenuesId
                             where vs.SubCategoriesId == subCatId
                     select new
                     {
                         v.Id,
                         v.VenueName
                     }).ToList();
            List<Venues> venues = new List<Venues>();
            foreach(var obj in venuesRaw)
            {
                Venues venue = new Venues
                {
                    Id = obj.Id,
                    VenueName = obj.VenueName
                };
                venues.Add(venue);
            }

            var viewModel = new InnerPageViewModel
            {
                Cities = cityList,
                Venues = venues,
                SubCategories = subcat, 
                VenueServices = venueServices,
                SubCatDesc = subCatDesc,
                Products = ProductsList,
                SubCatCount = subcat.Count(),
                VenueCount = VenueCount,
                CityCount = _context.Cities.Count()
        };

            return View(viewModel);

            //var cityList = _context.Cities.ToList();
            //return View(cityList);
        }


        //public ActionResult ViewCities()
        //{

        //}
    }
}