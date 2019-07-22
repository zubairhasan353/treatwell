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
        public IHttpActionResult CProfile([FromUri] string UserId)
        {
            var viewModel = new CustomerProfileViewModel();

            var UserTable = _context.Users.Where(u => u.Id == UserId).Single(u => u.Id == UserId);
            var VenueName = _context.UserVenues.Include("Venues").Where(v => v.UserId == UserId).FirstOrDefault(v => v.UserId == UserId).Venues.VenueName;
            
            var FullName = UserTable.FullName;
            var UserName = UserTable.UserName;
            var Email = UserTable.Email;
            var PhoneNo = UserTable.PhoneNumber;
            var ImagePath = UserTable.ImagePath;

            viewModel.FullName = FullName;
            viewModel.Email = Email;
            viewModel.ImagePath = ImagePath;
            viewModel.PhoneNumber = PhoneNo;
            viewModel.UserName = UserName;
            viewModel.VenueName = VenueName;

            return Ok(viewModel);
        }
    }
}
