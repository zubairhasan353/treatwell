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
using treatwell.Dtos;
using treatwell.ViewModels;
using AutoMapper;

namespace treatwell.Controllers.API
{
    public class SaloonProfileController : ApiController
    {
        private ApplicationDbContext _context;
        public SaloonProfileController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetSaloonProfile([FromUri] int VenueId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var viewModel = new SaloonProfileViewModel();
            var Venues = _context.venues.Include("City").Where(v => v.Id == VenueId).Select(Mapper.Map<Venues, VenuesDto>).FirstOrDefault();
            var VenueImages = _context.VenueImages.Where(v => v.VenuesId == VenueId).Select(Mapper.Map<VenueImages, VenueImagesDto>).ToList();
            var VenueServicesList = _context.VenueServices.Include("SubCategories").Where(vs => vs.VenuesId == VenueId).Select(Mapper.Map<VenueServices, VenueServicesDto>).ToList();
            //var employees = _context.UserVenues.Include("User").Where(uv => uv.VenuesId == VenueId).Select(Mapper.Map<UserVenues, UserVenuesDto>).ToList();
            var bookingDaysTime = _context.BookingDaysTimes.Include("Day").Where(d => d.VenueService.VenuesId == VenueId).Select(Mapper.Map<BookingDaysTime, BookingDaysTimeDto>).ToList();
            
            var CustomerReviewsRaw = (from cr in _context.customerReviews
                                   join cb in _context.CustomerBookings on cr.CustomerBookingId equals cb.Id
                                   join cbd in _context.CustomerBookingDetails on cb.Id equals cbd.CustomerBookingId
                                   join vs in _context.VenueServices on cbd.VenueServiceId equals vs.Id
                                   where vs.VenuesId == VenueId
                                   select new
                                   {
                                       cr.Id,
                                       Total = (cr.Ambience + cr.Staff + cr.Cleanliness + cr.Value) / 4,
                                       cr.ExperienceHeading,
                                       cr.ExperienceRemarks, 
                                       cr.ReviewDate
                                   }).ToList();
            List<CustomerReviewsDto> customerReviews = new List<CustomerReviewsDto>();
            foreach (var obj in CustomerReviewsRaw)
            {
                double reviewSecond = DateTime.Today.Subtract(obj.ReviewDate).TotalSeconds;
                string TimeinDaysorMins;
                if (reviewSecond < 60)
                {
                    TimeinDaysorMins = "Seconds";
                }
                else if(reviewSecond < 3600)
                {
                    reviewSecond = Math.Round(reviewSecond / 60);
                    TimeinDaysorMins = "Minutes";
                }
                else
                {
                    reviewSecond = Math.Round(reviewSecond / 3600);
                    if(reviewSecond < 24)
                    {
                        TimeinDaysorMins = "Hours";
                    }
                    else
                    {
                        reviewSecond = Math.Round(reviewSecond / 24);
                        if(reviewSecond < 30)
                        {
                            TimeinDaysorMins = "Days";
                        }
                        else
                        {
                            reviewSecond = Math.Round(reviewSecond / 30);
                            if (reviewSecond < 12)
                            {
                                TimeinDaysorMins = "Months";
                            }
                            else
                            {
                                reviewSecond = Math.Round(reviewSecond / 12);
                                if (reviewSecond == 1)
                                {
                                    TimeinDaysorMins = "Year";
                                }
                                else
                                {
                                    TimeinDaysorMins = "Years";
                                }
                            }
                        }
                    }
                }

                CustomerReviewsDto CR = new CustomerReviewsDto
                {
                    ExperienceHeading = obj.ExperienceHeading,
                    ExperienceRemarks = obj.ExperienceRemarks,
                    Total = obj.Total,
                    ReviewDate = obj.ReviewDate,
                    ReviewedSeconds = reviewSecond,
                    TimeinDaysorMins = TimeinDaysorMins,
                    Id = obj.Id
                };
                customerReviews.Add(CR);
            }
            //var EmployeesRaw = (from uv in _context.UserVenues join emp in _context.Users on uv.UserId equals emp.Id
            //                 where uv.VenuesId == VenueId
            //                 select new
            //                 {
            //                     emp.Id, 
            //                     emp.FullName, 
            //                     emp.Email,
            //                     emp.UserName
            //                 }).ToList();

            //List<ApplicationUser> employees = new List<ApplicationUser>();
            //foreach (var obj in EmployeesRaw)
            //{
            //    ApplicationUser emp = new ApplicationUser
            //    {
            //        Id = obj.Id,
            //        FullName = obj.FullName,
            //        Email = obj.Email,
            //        UserName = obj.UserName
            //    };
            //    employees.Add(emp);
            //}
            //var city = (from v in _context.venues join c in _context.Cities on v.CityId equals c.Id
            //            where v.Id == VenueId
            //            select c.CityName).FirstOrDefault();

            viewModel.CustomerReviews.AddRange(customerReviews);
            //viewModel.Employees.AddRange(employees);
            viewModel.Venues = Venues;
            viewModel.VenueImages.AddRange(VenueImages);
            viewModel.BookingDaysTimes.AddRange(bookingDaysTime);
            viewModel.venueServices.AddRange(VenueServicesList);
            return Ok(viewModel);
        }
    }
}
