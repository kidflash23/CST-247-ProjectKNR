using KNRProject.Models;
using KNRProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KNRProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Login");
            }
            SecurityService sa = new SecurityService();
            if (sa.Authenticate(model))
            {
                //Login Passed
                return View("LoginPassed", model);
            }
            else
            {
                return View("LoginFailed");
            }
        }
    }
}