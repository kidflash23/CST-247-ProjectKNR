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
        // GET: Game
        [HttpPost]
        public ActionResult Start()
        {
            ViewBag.Message = "Start";
            GameBoardModel board = new GameBoardModel();
            return RedirectToAction("Game");
        }
        public ActionResult Game(GameBoardModel board)
        {
            return View("Game", board);
        }
    }
}