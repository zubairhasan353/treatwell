using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using treatwell.Models;

namespace treatwell.Controllers
{
    public class CustomerProfileController : Controller
    {
        ApplicationDbContext _context;

        public CustomerProfileController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: CustomerProfile
        public ActionResult Index()
        {
            return View();
        }
    }
}