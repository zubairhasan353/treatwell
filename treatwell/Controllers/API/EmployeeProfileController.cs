using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using treatwell.Models;
using treatwell.ViewModels;

namespace treatwell.Controllers.API
{
    public class EmployeeProfileController : ApiController
    {
        private ApplicationDbContext _context;
        public EmployeeProfileController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult CProfile([FromUri] string UserId)
        {
            var viewModel = new EmployeeProfileViewModel();

            var UserTable = _context.Users.Where(u => u.Id == UserId).Single(u => u.Id == UserId);
            var VenueName = _context.UserVenues.Include("Venues").Where(v => v.UserId == UserId).FirstOrDefault(v => v.UserId == UserId).Venues.VenueName;
            var ServicesRaw = (from u in _context.UserServices
                               join s in _context.subCategories on u.subCategoriesId equals s.Id
                               where u.UserId == UserId
                               select new
                               {
                                   s.Id,
                                   s.SubCatDesc
                               }).ToList();
            List<SubCategories> subCategories = new List<SubCategories>();
            foreach (var obj in ServicesRaw)
            {
                SubCategories sub = new SubCategories
                {
                    Id = obj.Id,
                    SubCatDesc = obj.SubCatDesc
                };
                subCategories.Add(sub);
            }

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
            viewModel.Services.AddRange(subCategories);

            return Ok(viewModel);
        }
    }
}
