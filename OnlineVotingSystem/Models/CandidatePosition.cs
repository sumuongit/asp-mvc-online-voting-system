//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineVotingSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CandidatePosition
    {
        public int CandidatePositionId { get; set; }
        public Nullable<int> CandidateId { get; set; }
        public Nullable<int> PositionId { get; set; }
    
        public virtual Candidate Candidate { get; set; }
        public virtual Position Position { get; set; }
    }
}
