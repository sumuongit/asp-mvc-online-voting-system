using OnlineVotingSystem.Models;
using OnlineVotingSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineVotingSystem.Controllers
{
    public class CandidatePositionController : Controller
    {
        OnlineVotingSystemEntities db = new OnlineVotingSystemEntities();

        // GET: CandidatePosition
        public ActionResult Index()
        {
            var positionWiseCandidateList = (from cp in db.CandidatePositions
                                             join c in db.Candidates
                                             on cp.CandidateId equals c.CandidateId
                                             join p in db.Positions
                                             on cp.PositionId equals p.PositionId
                                             select new CandidatePositionViewModel
                                             {
                                                 Position = p,
                                                 Candidate = c
                                             });
            //ViewBag["CandidatePositionModel"] = positionWiseCandidateList.ToList();
            return View(positionWiseCandidateList);
        }
    }
}