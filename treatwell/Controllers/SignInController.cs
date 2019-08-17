using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using treatwell.Models;
using System.IO;

namespace Angular_MVC.Controllers
{
    public class SignInController : Controller
    {
        private ApplicationDbContext _context;

        public SignInController() : base()
        {
            _context = new ApplicationDbContext();
        }

        // GET: SignIn
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignUp(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FullName = model.FullName, PhoneNumber = model.PhoneNumber };
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "SignIn");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }


        public ActionResult ForgetUrPassword()
        {
            return View();
        }
    }
}