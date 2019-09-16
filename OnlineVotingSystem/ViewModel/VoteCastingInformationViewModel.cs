using OnlineVotingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVotingSystem.ViewModel
{
    public class VoteCastingInformationViewModel
    {
       //public Candidate Candidate { get; set; }
       //public Position Position { get; set; }
       public List<Voter> Voters { get; set; }
       //public Voter Voter { get; set; }
       public List<VoteCastingPanelViewModel> VoteCastingPanelViewModel { get; set; }
       public List<CandidateVoterViewModel> CandidateVoterViewModel { get; set; }
       //public List<VoteCastingInformation> VoteCastingInformation { get; set; }
    }
}