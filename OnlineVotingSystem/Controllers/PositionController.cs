using OnlineVotingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineVotingSystem.Controllers
{
    public class PositionController : Controller
    {
        OnlineVotingSystemEntities db = new OnlineVotingSystemEntities();
        // GET: Position
        public ActionResult Index()
        {
            var positions = db.Positions.ToList();
            return View(positions);
        }
    }
}