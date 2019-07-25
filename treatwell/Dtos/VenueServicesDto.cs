using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using treatwell.Models;

namespace treatwell.Dtos
{
    public class VenueServicesDto
    {
        public int Id { get; set; }

        public SubCategoriesDto SubCategories { get; set; }
        
        [Display(Name = "Actual Cost Price")]
        public int ActualCostPrice { get; set; }

        [Display(Name = "Discount")]
        public int DiscountedPercentage { get; set; }
    }
}