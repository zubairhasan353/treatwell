using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Models;
using treatwell.Dtos;

namespace treatwell.ViewModels
{
    public class InnerPageDtoViewModel
    {
        public List<CitiesDto> Cities { get; set; }
        public List<AppVenueServicesDtos> Venues { get; set; }
        public List<SubCategoriesDto> SubCategories { get; set; }
        public string SubCatDesc { get; set; }
        public int VenueCount { get; set; }
        public int SubCatCount { get; set; }
        public int CityCount { get; set; }

        public InnerPageDtoViewModel()
        {
            Cities = new List<CitiesDto>();
            Venues = new List<AppVenueServicesDtos>();
            SubCategories = new List<SubCategoriesDto>();
        }
    }
}