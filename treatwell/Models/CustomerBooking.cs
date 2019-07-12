using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace treatwell.Models
{
    public class CustomerBooking
    {
        public int Id { get; set; }

        public ApplicationUser Customer { get; set; }
        public string CustomerId { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime BookingDate { get; set; }

        public string BookingTime { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string IsThisForYou { get; set; }
        public string VisitThisSalon { get; set; }
        public int TotalAmount { get; set; }

        public PaymentMethods PaymentMethod { get; set; }
        public int PaymentMethodId { get; set; }
    }
}