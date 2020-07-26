using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KNRProject.Controllers
{
    public class RegistrationController : Controller
    {
        [HttpGet]
        // GET: Registration
        public ActionResult Registration()
        {
            return View();
        }
    }
}