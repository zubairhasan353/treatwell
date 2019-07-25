using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace treatwell.Models
{
    public class BaseClass
    {
        public ApplicationUser ApplicationUserCreatedBy { get; set; }
        public string ApplicationUserCreatedById { get; set; }
        public DateTime ApplicationUserCreatedDate { get; set; }

        public ApplicationUser ApplicationUserLastUpdatedBy { get; set; }
        public string ApplicationUserLastUpdatedById { get; set; }
        public DateTime ApplicationUserLastUpdatedDate { get; set; }
    }
}