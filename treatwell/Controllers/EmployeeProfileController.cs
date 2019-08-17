using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using treatwell.Controllers;
using treatwell.Models;

namespace treatwell.Controllers
{
    public class EmployeeProfileController : Controller
    {
        ApplicationDbContext _context;
        // GET: EmployeeProfile
        public ActionResult Index()
        {
            return View();
        }
    }
}