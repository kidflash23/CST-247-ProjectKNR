using Activity2_Part1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity2_Part1.Controllers
{
    public class ButtonController : Controller
    {
        static List<ButtonModel> buttons = new List<ButtonModel>();
        // GET: Button
        public ActionResult Index()
        {
            ButtonModel b1 = new ButtonModel(true);
            ButtonModel b2 = new ButtonModel(false);
            buttons.Add(b1);
            buttons.Add(b2);
            return View("Button", buttons);
        }
        public ActionResult OnButtonClick(string mine)
        {
            //If image 1
            if (mine == "1")
            {
                //Flip the state
                buttons[0].State = !buttons[0].State;
            }
            //if image 2
            if (mine == "2")
            {
                //Flip the state
                buttons[1].State = !buttons[1].State;
            }

            return View("Button", buttons);
        }

    }
}