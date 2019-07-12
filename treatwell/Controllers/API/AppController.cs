using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using treatwell.Models;
using treatwell.ViewModels;

namespace treatwell.Controllers.API
{
    public class AppController : ApiController
    {
        private ApplicationDbContext _context;
        public AppController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Checked(int[] serviceId, int[] cityId)
        {
            int catId = 0;
            var viewModel = new InnerPageViewModel();
            for (int i = 0; i < serviceId.Length; i++)
            {
                //var cpredicate = PredicateBuilder.False<Cities>();
                Expression<Func<Cities, bool>> cpredicate = item => false;

                var subCatId = serviceId[i];
                var subCatTable = _context.subCategories.Where(c => c.Id == subCatId).Single(c => c.Id == subCatId);
                catId = subCatTable.CategoryID;

                var subCatDesc = subCatTable.SubCatDesc;
                var VenueCount = _context.VS.Where(c => c.SubCategoriesId == subCatId).Count();

                var temp = _context.VS.Include("Venues").Where(c => c.SubCategoriesId == subCatId);
                for(int j = 0; j < cityId.Length; j++)
                {
                    var tmp = cityId[j];
                    temp = temp.Where(d => d.Venues.CityId == tmp);
                }

                var venueServices = temp.ToList();
                var venuesRaw = (from v in _context.venues
                                 join vs in _context.VS on v.Id equals vs.VenuesId
                                 where vs.SubCategoriesId == subCatId
                                 select new
                                 {
                                     v.Id,
                                     v.VenueName
                                 }).ToList();
                List<Venues> venues = new List<Venues>();
                foreach (var obj in venuesRaw)
                {
                    Venues venue = new Venues
                    {
                        Id = obj.Id,
                        VenueName = obj.VenueName
                    };
                    venues.Add(venue);

                }

                viewModel.Venues.AddRange(venues);
                viewModel.VenueServices.AddRange(venueServices);
                viewModel.SubCatDesc = subCatDesc;
                viewModel.VenueCount = VenueCount;
            }
            var cityList = _context.Cities.Distinct().ToList();
            var ProductsList = _context.Products.ToList();
            var subcat = _context.subCategories.Where(c => c.CategoryID == catId).ToList();

            viewModel.SubCategories.AddRange(subcat);
            viewModel.SubCatCount = subcat.Count();
            viewModel.CityCount = _context.Cities.Count();
            viewModel.Cities.AddRange(cityList);
            viewModel.Products.AddRange(ProductsList);

            return Ok(viewModel);

        }
    }
}
