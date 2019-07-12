using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace treatwell.Models
{
    public class CustomerReviews
    {
        public int Id { get; set; }

        public CustomerBooking CustomerBooking { get; set; }
        public int CustomerBookingId { get; set; }

        public string Experience { get; set; }

        public int Ambience { get; set; }
        public int Staff { get; set; }
        public int Cleanliness { get; set; }
        public int Value { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}