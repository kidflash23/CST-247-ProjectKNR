using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KNRProject.Controllers
{
    public class RegisterController : Controller
    {
        [HttpPost]
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }
    }
}