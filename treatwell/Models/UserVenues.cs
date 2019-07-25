using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace treatwell.Models
{
    public class UserVenues : BaseClass
    {
        public int Id { get; set; }

        public Venues Venues { get; set; }
        public int VenuesId { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}