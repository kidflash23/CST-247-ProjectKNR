using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class GameController : Controller
    {

        GameBoardModel board = new GameBoardModel();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Start()
        { 
            ViewBag.Message = "Start";
            
            return View("Start");
        }
        public ActionResult Game(GameBoardModel board)
        {
            
            return View("Game", board);
        }

        public ActionResult HandleButtonClick(string mine)
        {
            return View("Game", board);
        }


    }
}