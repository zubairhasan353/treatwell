using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Models;

namespace treatwell.ViewModels
{
    public class EmployeeProfileViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string ImagePath { get; set; }
        public string VenueName { get; set; }
        public List<SubCategories> Services { get; set; }

        public EmployeeProfileViewModel()
        {
            Services = new List<SubCategories>();
        }
    }
}