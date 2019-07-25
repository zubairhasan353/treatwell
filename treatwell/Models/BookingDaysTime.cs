using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace treatwell.Models
{
    public class BookingDaysTime : BaseClass
    {
        public int Id { get; set; }

        public Days Day { get; set; }
        public int DayID { get; set; }

        [Required]
        public string StartTime { get; set; }

        [Required]
        public string EndTime { get; set; }

        public VenueServices VenueService { get; set; }
        public int VenueServiceId { get; set; }

        public int IntervalinMinutes { get; set; }
    }
}