using OnlineVotingSystem.Models;
using OnlineVotingSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineVotingSystem.Controllers
{
    public class ResultController : Controller
    {
        OnlineVotingSystemEntities db = new OnlineVotingSystemEntities();

        // GET: Result
        public ActionResult Index()
        {
            VoteCastingInformationViewModel vm = new VoteCastingInformationViewModel();
            OnlineVotingSystemEntities db = new OnlineVotingSystemEntities();
            // GET: CandidatePosition
             vm.VoteCastingPanelViewModel = (from cp in db.CandidatePositions
                                            join c in db.Candidates
                                            on cp.CandidateId equals c.CandidateId
                                            join p in db.Positions
                                            on cp.PositionId equals p.PositionId
                                            select new VoteCastingPanelViewModel
                                            {
                                                Position = p,
                                                Candidate = c                                                
                                            }).ToList();            
           
            vm.CandidateVoterViewModel = (from vc in db.VoteCastingInformations
                                          join p in db.Positions
                                          on vc.PositionId equals p.PositionId                                                                                
                                          join c in db.Candidates
                                          on vc.CandidateId equals c.CandidateId 
                                          group new { vc.PositionId, vc.CandidateId, vc.VoterId }
                                          by new { p.PositionName, c.Name, p.PositionId, vc.Candidate, vc.Position } into g                                        
                                          orderby g.Key.PositionId
                                          select new CandidateVoterViewModel
                                          {
                                              Position = g.Key.Position,
                                              Candidate = g.Key.Candidate,
                                              PositionName = g.Key.PositionName,
                                              CandidateName = g.Key.Name,                                            
                                              VoteCount = g.Count(t => t.VoterId != null)
                                          }).ToList();

            vm.Voters = (from v in db.Voters
                        where v.IsCommittedVote == false
                        select v).ToList();

            return View(vm);
        }
    }
}