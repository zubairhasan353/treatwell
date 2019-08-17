using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using treatwell.Dtos;
using treatwell.Models;

namespace treatwell.ViewModels
{
    public class SaloonProfileViewModel
    {
        public VenuesDto Venues { get; set; }
        public List<VenueServicesDto> venueServices { get; set; }
        public List<UserVenuesDto> Employees { get; set; }

        public SaloonProfileViewModel()
        {
            venueServices = new List<VenueServicesDto>();
            Employees = new List<UserVenuesDto>();
        }
    }
}