using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using treatwell.Models;
using treatwell.ViewModels;
using AutoMapper;
using treatwell.Dtos;


namespace treatwell.Controllers.API
{
    public class CustomerProfileController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomerProfileController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetCustomerProfile([FromUri] string UserId)
        {
            var viewModel = new CustomerProfileViewModel();

            var User = _context.Users.Where(u => u.Id == UserId).Select(Mapper.Map<ApplicationUser, ApplicationUserDto>).FirstOrDefault();
            var CustomerBooking = _context.CustomerBookings.Where(u => u.CustomerId == UserId).Select(Mapper.Map<CustomerBooking, CustomerBookingDto>).ToList();
            //var venues = _context.venues.Include("CustomerBookingDetails").ToList();

            var venuesRaw = (from cb in _context.CustomerBookings
                             join cbd in _context.CustomerBookingDetails on cb.Id equals cbd.CustomerBookingId
                             join vs in _context.VenueServices on cbd.VenueServiceId equals vs.Id
                             join v in _context.venues on vs.VenuesId equals v.Id
                             where cb.CustomerId == UserId
                             select new
                             {
                                 v.Id,
                                 v.VenueName, 
                                 v.Address
                             }).ToList();
            List<VenuesCustProfDto> venues = new List<VenuesCustProfDto>();
            foreach (var obj in venuesRaw)
            {
                VenuesCustProfDto venue = new VenuesCustProfDto
                {
                    Id = obj.Id,
                    VenueName = obj.VenueName, 
                    Address = obj.Address
                };
                venues.Add(venue);
            }

            viewModel.User = User;
            viewModel.customerBookings.AddRange(CustomerBooking);
            viewModel.venues.AddRange(venues);

            return Ok(viewModel);
        }

       
    }
}
