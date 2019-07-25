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
using treatwell.Dtos;
using AutoMapper;

namespace treatwell.Controllers.API
{
    public class AppController : ApiController
    {
        private ApplicationDbContext _context;
        public AppController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetDetailofServices([FromUri] int[] serviceId, [FromUri] int[] cityId)
        {
            int catId = 0;
            var viewModel = new InnerPageDtoViewModel();
            for (int i = 0; i < serviceId.Length; i++)
            {
                //var cpredicate = PredicateBuilder.False<Cities>();
                Expression<Func<Cities, bool>> cpredicate = item => false;

                var subCatId = serviceId[i];
                var subCatTable = _context.subCategories.Where(c => c.Id == subCatId).Single(c => c.Id == subCatId);
                catId = subCatTable.CategoryID;

                var subCatDesc = subCatTable.SubCatDesc;
                var VenueCount = _context.VenueServices.Where(c => c.SubCategoriesId == subCatId).Count();

                var venues = _context.VenueServices.Include("Venues").Include("Venues.City").Where(v => v.SubCategoriesId == subCatId).Select(Mapper.Map<VenueServices, AppVenueServicesDtos>).ToList();
                
                viewModel.Venues.AddRange(venues);
                viewModel.SubCatDesc = subCatDesc;
                viewModel.VenueCount = VenueCount;
            }
            var cityList = _context.Cities.Distinct().Select(Mapper.Map<Cities, CitiesDto>).ToList();
            var subcat = _context.subCategories.Where(c => c.CategoryID == catId).Select(Mapper.Map<SubCategories, SubCategoriesDto>).ToList();

            viewModel.SubCategories.AddRange(subcat);
            viewModel.SubCatCount = subcat.Count();
            viewModel.CityCount = _context.Cities.Count();
            viewModel.Cities.AddRange(cityList);

            return Ok(viewModel);

        }
    }
}
