using OnlineVotingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVotingSystem.ViewModel
{
    public class VoteCastingPanelViewModel
    {
       public Candidate Candidate { get; set; }
       public Position Position { get; set; }      
    }
}