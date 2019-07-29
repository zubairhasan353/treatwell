using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using treatwell.Models;

namespace treatwell.Controllers
{
    public class TestController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetCustomer()
        {
            
            var customer = _context.Users.Where(l => l.Id == "23909c0a-6dbf-4cf6-950e-787bb932acce").FirstOrDefault();

            return Json(customer, JsonRequestBehavior.AllowGet);

        }
    }
}