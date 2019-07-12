using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Models;
using System.Data.Entity;

namespace treatwell.ViewModels
{
    public class VenueCitiesViewModel : DbContext
    {
        public IEnumerable<Cities> Cities { get; set; }
        public Venues Venues { get; set; }
    }
}