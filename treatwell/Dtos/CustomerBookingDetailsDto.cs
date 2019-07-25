using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace treatwell.Dtos
{
    public class CustomerBookingDetailsDto
    {
        public CustomerBookingDto CustomerBooking { get; set; }
        public int CustomerBookingId { get; set; }

        public VenueServicesDto VenueService { get; set; }
    }
}