using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace treatwell.Models
{
    public class EmployeeAvailability
    {
        public int Id { get; set; }

        [Display(Name = "User Venues")]
        public UserVenues UserVenues { get; set; }
        public int UserVenuesId { get; set; }

        public Days Day { get; set; }
        public int DayID { get; set; }

        [Required]
        [Display(Name = "Start time")]
        public string StartTime { get; set; }

        [Required]
        [Display(Name = "End time")]
        public string EndTime { get; set; }

        public ApplicationUser ApplicationUserCreatedBy { get; set; }
        public string ApplicationUserCreatedById { get; set; }
        public DateTime ApplicationUserCreatedDate { get; set; }

        public ApplicationUser ApplicationUserLastUpdatedBy { get; set; }
        public string ApplicationUserLastUpdatedById { get; set; }
        public DateTime ApplicationUserLastUpdatedDate { get; set; }

        public ApplicationDbContext db = new ApplicationDbContext();
    }
}