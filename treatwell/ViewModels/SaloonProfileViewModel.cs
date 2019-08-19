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
        public List<VenuesDto> Venues { get; set; }
        public List<VenueServicesDto> venueServices { get; set; }
        public List<CustomerReviewsDto> CustomerReviews { get; set; }
        public List<BookingDaysTimeDto> BookingDaysTimes { get; set; }
        
        public SaloonProfileViewModel()
        {
            Venues = new List<VenuesDto>();
            venueServices = new List<VenueServicesDto>();
            BookingDaysTimes = new List<BookingDaysTimeDto>();
        }
    }
}