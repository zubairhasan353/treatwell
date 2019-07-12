using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Models;

namespace treatwell.ViewModels
{
    public class EmployeeAvailabilityViewModel
    {
        public IEnumerable<UserVenues> UserVenues { get; set; }
        public IEnumerable<Days> Days { get; set; }
        public EmployeeAvailability EmployeeAvailability { get; set; }
        
        public ApplicationDbContext db = new ApplicationDbContext();
        //public UserVenues userVenue { get; set; }
        //public IEnumerable<ApplicationUser> User { get; set; }
        //public IEnumerable<Venues> venues { get; set; }
    }
}