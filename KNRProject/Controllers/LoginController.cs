using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KNRProject.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
    }
}