using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Models;

namespace treatwell.Dtos
{
    public class AppVenueServicesDtos
    {
        public VenuesDto Venues { get; set; }

        public SubCategoriesDto subCategories { get; set; }
        public int SubCategoriesId { get; set; }
    }
}