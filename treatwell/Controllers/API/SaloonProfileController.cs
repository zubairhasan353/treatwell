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
            var VenueServicesList = _context.VenueServices.Include("SubCategories").Where(vs => vs.VenuesId == VenueId).Select(Mapper.Map<VenueServices, VenueServicesDto>).ToList();
            var employees = _context.UserVenues.Include("User").Where(uv => uv.VenuesId == VenueId).Select(Mapper.Map<UserVenues, UserVenuesDto>).ToList();


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
            viewModel.Employees.AddRange(employees);
            viewModel.Venues = Venues;
            viewModel.venueServices.AddRange(VenueServicesList);
            return Ok(viewModel);
        }
    }
}
