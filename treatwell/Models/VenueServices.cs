using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace treatwell.Models
{
    public class VenueServices
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

        public ApplicationUser ApplicationUserCreatedBy { get; set; }
        public string ApplicationUserCreatedById { get; set; }
        public DateTime ApplicationUserCreatedDate { get; set; }

        public ApplicationUser ApplicationUserLastUpdatedBy { get; set; }
        public string ApplicationUserLastUpdatedById { get; set; }
        public DateTime ApplicationUserLastUpdatedDate { get; set; }
    }
}