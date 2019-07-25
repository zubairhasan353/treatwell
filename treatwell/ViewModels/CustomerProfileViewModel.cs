﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Dtos;
using treatwell.Models;

namespace treatwell.ViewModels
{
    public class CustomerProfileViewModel
    {
        public List<ApplicationUserDto> User { get; set; }
        public List<VenuesCustProfDto> venues { get; set; }
        public List<CustomerBookingDto> customerBookings { get; set; }

        public CustomerProfileViewModel()
        {
            User = new List<ApplicationUserDto>();
            venues = new List<VenuesCustProfDto>();
            customerBookings = new List<CustomerBookingDto>();
        }
    }
}