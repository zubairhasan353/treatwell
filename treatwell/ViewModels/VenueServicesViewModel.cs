using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Models;

namespace treatwell.ViewModels
{
    public class VenueServicesViewModel
    {
        public List<VenueServices> VenueServices { get; set; }
        public List<Venues> Venues { get; set; }
    }
}