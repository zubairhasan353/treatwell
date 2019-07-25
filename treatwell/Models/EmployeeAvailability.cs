using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace treatwell.Models
{
    public class EmployeeAvailability : BaseClass
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
        public ApplicationDbContext db = new ApplicationDbContext();
    }
}