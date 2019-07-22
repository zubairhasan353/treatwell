using System;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using treatwell.Models;
using treatwell.ViewModels;
using System.Data.Entity;

namespace treatwell.Controllers
{
    [Authorize]
    public class UserRolesController : Controller
    {
        // GET: UserRoles
        private ApplicationDbContext _context;

        public UserRolesController()
        {
            _context = new ApplicationDbContext();
        }

        //public ActionResult UserWithRoles()
        //{
        //    var usersWithRoles = (from user in _context.Users
        //                          select new
        //                          {
        //                              UserId = user.Id,
        //                              Username = user.UserName,
        //                              Email = user.Email,
        //                              RoleNames = (from userRole in user.Roles
        //                                           join role in _context.Roles on userRole.RoleId
        //                                           equals role.Id
        //                                           select role.Name).ToList()
        //                          }).ToList().Select(p => new UsersinRoleViewModel()

        //                          {
        //                              UserId = p.UserId,
        //                              Username = p.Username,
        //                              Email = p.Email,
        //                              Role = string.Join(",", p.RoleNames)
        //                          });

        //    return View(usersWithRoles);
        //}

        // GET: VenueServices
        public ActionResult Index()
        {
            var urList = _context.UserRoles.Include(c => c.User).
                Include(d => d.Role).ToList();
            return View(urList);
        }        
    }
}