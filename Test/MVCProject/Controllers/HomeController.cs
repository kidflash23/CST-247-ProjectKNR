using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using static DataLibrary.BusinessLogic.UserProcessor;
using System.Configuration;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel model)
        {
            ViewBag.Message = "Register.cshtml";
            if (ModelState.IsValid)
            {
                createUser(model.UserID, model.FirstName, model.LastName, model.EmailAddress, model.Sex, model.State);
                return RedirectToAction("Index.cshtml");
            }
            return View();
        }


        public ActionResult Register()
        {
            ViewBag.Message = "Register.cshtml";
            return View();
        }
    }
}