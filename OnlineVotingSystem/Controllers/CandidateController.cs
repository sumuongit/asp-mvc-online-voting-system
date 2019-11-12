using OnlineVotingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineVotingSystem.Controllers
{
    public class CandidateController : Controller
    {
        OnlineVotingSystemEntities db = new OnlineVotingSystemEntities();

        // GET: Candidate
        public ActionResult Index()
        {
            var candidates = db.Candidates.ToList();
            return View(candidates);
        }        
    }
}