using OnlineVotingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVotingSystem.ViewModel
{
    public class VoteCastingInformationViewModel
    {       
       public List<Voter> Voters { get; set; }      
       public List<VoteCastingPanelViewModel> VoteCastingPanelViewModel { get; set; }
       public List<CandidateVoterViewModel> CandidateVoterViewModel { get; set; }      
    }
}