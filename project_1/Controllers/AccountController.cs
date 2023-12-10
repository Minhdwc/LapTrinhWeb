using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project_1.Models;
using project_1.ViewModel;
using project_1.Identity;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace project_1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterVM rvm)
        {
            if (ModelState.IsValid)
            {
                var webDbContext = new WebDBContext();
                var userStore = new WebUserStore(webDbContext);
                var userManager = new WebUserManager(userStore);
                var passwordHash = Crypto.HashPassword(rvm.Password);
                var user = new WebUser()
                {
                    Email = rvm.Email,
                    UserName = rvm.UserName,
                    PasswordHash = passwordHash,
                    City = rvm.City,
                    birth = rvm.Birth,
                    address = rvm.Address,
                    PhoneNumber = rvm.PhoneNumber,
                };
                IdentityResult result = userManager.Create(user);
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");

                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                    
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("New Error", "Invalid Data");
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM lvm)
        {
            var webDbContext = new WebDBContext();
            var userStore = new WebUserStore(webDbContext);
            var userManager = new WebUserManager(userStore);
            var user = userManager.Find(lvm.UserName, lvm.Password);
            if (user != null)
            {
                var authenManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("myError", "Invalid UserName and Password.");
                return View();
            }
        }
        public ActionResult Logout()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult Profile()
        {
            var webDbContext = new WebDBContext();
            var userStore = new WebUserStore(webDbContext);
            var userManager = new WebUserManager(userStore);

            var currentUser = User.Identity;
            if (currentUser != null && currentUser.IsAuthenticated)
            {
                var user = userManager.FindByName(currentUser.Name);
                if (user != null)
                {
                    var profileVM = new ProfileVM
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        City = user.City,
                        Birth = (DateTime)user.birth,
                        Address = user.address,
                        Password = user.PasswordHash,
                        PhoneNumber = user.PhoneNumber
                    };

                    return View(profileVM);
                }
            }
            return View();
        }
    }
}