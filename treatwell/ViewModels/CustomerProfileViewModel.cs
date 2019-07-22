using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Models;

namespace treatwell.ViewModels
{
    public class CustomerProfileViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string ImagePath { get; set; }
        public List<Venues> venues { get; set; }
        public List<CustomerBooking> customerBookings { get; set; }

        public CustomerProfileViewModel()
        {
            venues = new List<Venues>();
            customerBookings = new List<CustomerBooking>();
        }
    }
}