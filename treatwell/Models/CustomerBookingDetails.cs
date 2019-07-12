using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace treatwell.Models
{
    public class CustomerBookingDetails
    {
        public int id { get; set; }

        public CustomerBooking CustomerBooking { get; set; }
        public int CustomerBookingId { get; set; }

        public VenueServices VenueService { get; set; }
        public int VenueServiceId { get; set; }

        public ApplicationUser VenueEmployee { get; set; }
        public string VenueEmployeeId { get; set; }

        public int CostPrice { get; set; }
    }
}