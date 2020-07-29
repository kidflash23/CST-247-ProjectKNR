using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using static DataLibrary.BusinessLogic.UserProcessor;
using System.Configuration;
using DataLibrary.BusinessLogic;

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

        public ActionResult ViewUsers()
        {
            ViewBag.Message = "ViewUsers";
            var data = LoadUsers();
            List<UserModel> users = new List<UserModel>();
            foreach (var row in data)
            {
                users.Add(new UserModel
                {
                    UserID = row.UserID,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    Sex = row.Sex,
                    Age = row.Age,
                    State = row.State,
                    Username = row.Username,
                    Password = row.Password,
                    EmailAddress = row.Email
                }) ;
            }
            return View(users);
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel model)
        {
            ViewBag.Message = "Register";
            if (ModelState.IsValid)
            {
                createUser(model.UserID, model.FirstName, model.LastName, model.Sex, model.Age, model.State, model.Username, model.Password, model.EmailAddress);
                return RedirectToAction("Index");
            }
            return View();
        }



    }
}