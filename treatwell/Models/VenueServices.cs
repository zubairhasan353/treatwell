using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace treatwell.Models
{
    public class VenueServices : BaseClass
    {
        public int Id { get; set; }

        public Venues Venues { get; set; }
        public int VenuesId { get; set; }

        public SubCategories SubCategories { get; set; }
        public int SubCategoriesId { get; set; }

        [Required]
        [Display(Name = "Actual Cost Price")]
        public int ActualCostPrice { get; set; }

        [Required]
        [Display(Name = "Discount")]
        public int DiscountedPercentage { get; set; }
    }
}