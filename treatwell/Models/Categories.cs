using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace treatwell.Models
{
    public class Categories
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string CatDesc { get; set; }

        public ApplicationUser ApplicationUserCreatedBy { get; set; }
        public string ApplicationUserCreatedById { get; set; }
        public DateTime ApplicationUserCreatedDate { get; set; }

        public ApplicationUser ApplicationUserLastUpdatedBy { get; set; }
        public string ApplicationUserLastUpdatedById { get; set; }
        public DateTime ApplicationUserLastUpdatedDate { get; set; }
    }
}