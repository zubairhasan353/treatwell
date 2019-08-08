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
        public List<VenueImagesDto> VenueImages { get; set; }
        public List<VenueServicesDto> venueServices { get; set; }
        public List<CustomerReviewsDto> CustomerReviews { get; set; }
        public List<BookingDaysTimeDto> BookingDaysTimes { get; set; }
        //public List<UserVenuesDto> Employees { get; set; }

        public SaloonProfileViewModel()
        {
            VenueImages = new List<VenueImagesDto>();
            CustomerReviews = new List<CustomerReviewsDto>();
            venueServices = new List<VenueServicesDto>();
            BookingDaysTimes = new List<BookingDaysTimeDto>();
            //Employees = new List<UserVenuesDto>();
        }
    }
}