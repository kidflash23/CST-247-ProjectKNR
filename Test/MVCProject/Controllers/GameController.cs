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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Start()
        {
            ViewBag.Message = "Start";
            GameBoardModel board = new GameBoardModel();
            return View("Start");
        }
        public ActionResult Game(GameBoardModel board)
        {
            return View("Game", board);
        }
    }
}