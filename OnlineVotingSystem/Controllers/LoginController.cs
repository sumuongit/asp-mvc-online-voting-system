using OnlineVotingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineVotingSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(UserMetadata userModel)
        {

            using (OnlineVotingSystemEntities db = new OnlineVotingSystemEntities())
            {
                if (userModel.Email != null && userModel.Password != null)
                {
                    var userDetails = db.Users.Where(x => x.Email == userModel.Email && x.Password == userModel.Password).FirstOrDefault();
                    if (userDetails == null)
                    {
                        userModel.LoginErrorMessage = "Wrong email or password!";
                        return View("Index", userModel);
                    }
                    else
                    {
                        Session["userEmail"] = userDetails.Email;
                        Session["userType"] = "Admin";
                        return RedirectToAction("Index", "Home");
                    }
                }

                else
                {
                    return View("Index", userModel);
                }

            }
        }

        public ActionResult LogOut()
        {

            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}