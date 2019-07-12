using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Models;

namespace treatwell.ViewModels
{
    public class UserServicesViewModel
    {
        public IEnumerable<ApplicationUser> User { get; set; }
        public IEnumerable<SubCategories> SubCategories { get; set; }
        public UserServices UserServices { get; set; }

        public string ErrorMessage { get; set; }
    }
}