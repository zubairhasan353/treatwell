using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace treatwell.Models
{
    public class SubCategories
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string SubCatDesc { get; set; }

        public Categories Category { get; set; }
        public int CategoryID { get; set; }

        [Display(Name = "Time in Minutes")]
        public int TimeInMinutes { get; set; }

        public ApplicationUser ApplicationUserCreatedBy { get; set; }
        public string ApplicationUserCreatedById { get; set; }
        public DateTime ApplicationUserCreatedDate { get; set; }

        public ApplicationUser ApplicationUserLastUpdatedBy { get; set; }
        public string ApplicationUserLastUpdatedById { get; set; }
        public DateTime ApplicationUserLastUpdatedDate { get; set; }
    }
}