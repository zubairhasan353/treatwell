using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Models;

namespace treatwell.ViewModels
{
    public class EmployeeAbsentViewModel
    {
        public IEnumerable<ApplicationUser> Employee { get; set; }
        public EmployeeAbsent EmployeeAbsent { get; set; }

        public ApplicationDbContext db = new ApplicationDbContext();
    }
}