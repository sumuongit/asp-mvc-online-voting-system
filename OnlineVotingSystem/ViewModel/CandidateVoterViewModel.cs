using OnlineVotingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVotingSystem.ViewModel
{
    public class CandidateVoterViewModel
    {
       public int CandidateId { get; set; }
       public int PositionId { get; set; }
       public int VoteCount { get; set; }
       public string PositionName { get; set; }
       public string CandidateName { get; set; }
       public Candidate Candidate { get; set; }
       public Position Position { get; set; }
    }
}