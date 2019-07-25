using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Models;

namespace treatwell.ViewModels
{
    public class InnerPageViewModel
    {
        public List<Cities> Cities { get; set; }
        public List<Venues> Venues { get; set; }
        public List<SubCategories> SubCategories { get; set; }
        public List<Categories> categories { get; set; }
        public List<VenueServices> VenueServices { get; set; }
        public string SubCatDesc { get; set; }
        public int VenueCount { get; set; }
        public int SubCatCount { get; set; }
        public int CityCount { get; set; }

        public InnerPageViewModel()
        {
            Cities = new List<Cities>();
            Venues = new List<Venues>();
            SubCategories = new List<SubCategories>();
            categories = new List<Categories>();
            VenueServices = new List<VenueServices>();
        }
    }
}