using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Models;
using System.Data.Entity;

namespace treatwell.ViewModels
{
    public class VenueServiceViewModel
    {
        public IEnumerable<Venues> Venues { get; set; }
        public IEnumerable<SubCategories> SubCategories { get; set; }
        public VenueServices VS { get; set; }
    }
}