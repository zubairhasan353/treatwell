using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Models;

namespace treatwell.Dtos
{
    public class CustomerReviewsDto
    {
        public int Id { get; set; }

        //public CustomerBooking CustomerBooking { get; set; }
        //public int CustomerBookingId { get; set; }

        public decimal Total { get; set; }
        public double ReviewedSeconds { get; set; }
        public string TimeinDaysorMins { get; set; }

        public string ExperienceHeading { get; set; }
        public string ExperienceRemarks { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}