using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using treatwell.Models;
namespace treatwell.Controllers
{
    public class BusinessProfileController : Controller
    {
        ApplicationDbContext _context;
        // GET: BusinessProfile
        public ActionResult Index()
        {
            return View();
        }
    }
}