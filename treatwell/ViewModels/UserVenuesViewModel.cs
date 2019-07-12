using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Models;

namespace treatwell.ViewModels
{
    public class UserVenuesViewModel
    {
        public IEnumerable<ApplicationUser> User { get; set; }
        public IEnumerable<Venues> Venues { get; set; }
        public UserVenues UserVenues { get; set; }

        public string ErrorMessage { get; set; }
    }
}