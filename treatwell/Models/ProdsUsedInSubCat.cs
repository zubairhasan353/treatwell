using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace treatwell.Models
{
    public class ProdsUsedInSubCat
    {
        public int Id { get; set; }

        public Products Product { get; set; }
        public int ProductId { get; set; }

        public SubCategories SubCat { get; set; }
        public int SubCatId { get; set; }

        [Display(Name = "Quantity Used")]
        public int QtyUsed { get; set; }

        public ApplicationUser ApplicationUserCreatedBy { get; set; }
        public string ApplicationUserCreatedById { get; set; }
        public DateTime ApplicationUserCreatedDate { get; set; }

        public ApplicationUser ApplicationUserLastUpdatedBy { get; set; }
        public string ApplicationUserLastUpdatedById { get; set; }
        public DateTime ApplicationUserLastUpdatedDate { get; set; }
    }
}