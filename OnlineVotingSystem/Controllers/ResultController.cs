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

            //var obj = (from c in db.Candidates
            //                              join vc in db.VoteCastingInformations
            //                              on c.CandidateId equals vc.CandidateId
            //                              group new { c, vc} by new { vc.CandidateId } into v
            //                              select new 
            //                              {
            //                                  CandidateId = v.Key.CandidateId,
            //                                  Vote = v.Count()                                              
            //                              }).ToList();

            //var obj = (from c in db.Candidates
            //            join vc in db.VoteCastingInformations
            //            on c.CandidateId equals vc.CandidateId
            //            group vc by c.CandidateId into v
            //            select new { CandidateId = v.Key, Vote = v.Count() }).ToList();

            //////vm.CandidateVoterViewModel = (from c in db.Candidates
            //////           join vc in db.VoteCastingInformations
            //////           on c.CandidateId equals vc.CandidateId into v
            //////           from vco in v.DefaultIfEmpty()
            //////           group vco by c.CandidateId into g
            //////           select new CandidateVoterViewModel
            //////           {
            //////               CandidateId = g.Key,
            //////               VoteCount = g.Count(t=>t.VoterId != null)
            //////           }).ToList();



            //vm.CandidateVoterViewModel = (from p in db.Positions
            //                              join c in db.Candidates
            //                              on p.PositionId equals c.CandidateId //into pc
            //                            //  from pco in pc.DefaultIfEmpty()
            //                              join vc in db.VoteCastingInformations
            //                              on c.CandidateId equals vc.CandidateId //into cv
            //                              //from vco in cv.DefaultIfEmpty()
            //                              //group vco by c.CandidateId into g
            //                              //// group new { c, vc} by new { vc.CandidateId } into v
            //                              group new { vc.PositionId, vc.CandidateId, vc.VoterId }
            //                              by new { p.PositionName, c.Name, p.PositionId } into g
            //                              //orderby g.Key..ShortName, g.Key.JobName
            //                              orderby g.Key.PositionId
            //                              select new CandidateVoterViewModel
            //                              {
            //                                  PositionName = g.Key.PositionName,
            //                                  CandidateName = g.Key.Name,
            //                                  //CandidateId = g.Key,
            //                                  VoteCount = g.Count(t => t.VoterId != null)
            //                              }).ToList();

            vm.CandidateVoterViewModel = (from vc in db.VoteCastingInformations
                                          join p in db.Positions
                                          on vc.PositionId equals p.PositionId //into pc
                                                                               //  from pco in pc.DefaultIfEmpty()
                                          join c in db.Candidates
                                          on vc.CandidateId equals c.CandidateId //into cv
                                          //from vco in cv.DefaultIfEmpty()
                                          //group vco by c.CandidateId into g
                                          //// group new { c, vc} by new { vc.CandidateId } into v
                                          group new { vc.PositionId, vc.CandidateId, vc.VoterId }
                                          by new { p.PositionName, c.Name, p.PositionId, vc.Candidate, vc.Position } into g
                                          //orderby g.Key

                                          orderby g.Key.PositionId
                                          select new CandidateVoterViewModel
                                          {
                                              Position = g.Key.Position,
                                              Candidate = g.Key.Candidate,
                                              PositionName = g.Key.PositionName,
                                              CandidateName = g.Key.Name,
                                              //CandidateId = g.Key,
                                              VoteCount = g.Count(t => t.VoterId != null)
                                          }).ToList(); //.OrderByDescending(x => x.VoteCount).ToList();//..ToList();

            vm.Voters = (from v in db.Voters
                        where v.IsCommittedVote == false
                        select v).ToList();

            return View(vm);
        }
    }
}