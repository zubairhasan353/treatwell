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

        public decimal Ambience { get; set; }
        public decimal Staff { get; set; }
        public decimal Cleanliness { get; set; }
        public decimal Value { get; set; }

        public string ExperienceHeading { get; set; }
        public string ExperienceRemarks { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}