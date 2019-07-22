using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Models;

namespace treatwell.ViewModels
{
    public class UserRolesViewModel
    {
        public IEnumerable<ApplicationUser> User { get; set; }
        public IEnumerable<ApplicationRole> Role { get; set; }
        public UserRoles UR { get; set; }
    }
}