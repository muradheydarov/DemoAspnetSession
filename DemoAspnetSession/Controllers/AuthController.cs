using DemoAspnetSession.Context;
using DemoAspnetSession.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace DemoAspnetSession.Controllers
{
    public class AuthController : Controller
    {
        HostCloudContext db = new HostCloudContext();
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(string email, string password)
        {
            var user = db.Users.FirstOrDefault(x => x.Email == email);

            if (user != null)
            {
                var isPassordMatch = Crypto.VerifyHashedPassword(user.Password, password);

                if (isPassordMatch)
                {
                    Session["login"] = true;
                    Session["userid"] = user.Id;
                    Session["username"] = user.Username;

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("Email", "Email or password not correct");

            return View("Index");
        }
        
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            if (db.Users.FirstOrDefault(x => x.Email == user.Email) != null)
            {
                ModelState.AddModelError("Email", "Email already exist");
            }

            if (db.Users.FirstOrDefault(x => x.Username == user.Username) != null)
            {
                ModelState.AddModelError("Username", "Username already exist");
            }

            if (ModelState.IsValid)
            {
                var hashPassword = Crypto.HashPassword(user.Password);

                user.Password = hashPassword;
                user.ConfirmPassword = hashPassword;

                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}