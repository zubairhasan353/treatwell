using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace treatwell.Dtos
{
    public class CustomerBookingDto
    {
        public int Id { get; set; }

        public ApplicationUserDto Customer { get; set; }
        public string CustomerId { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime BookingDate { get; set; }

        public string BookingTime { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
        public string ContactNo { get; set; }
        public int TotalAmount { get; set; }
    }
}