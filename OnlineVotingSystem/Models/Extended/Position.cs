using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace OnlineVotingSystem.Models
{
    [MetadataType(typeof(PositionMetadata))]
    public partial class Position
    {
        
    }

    public class PositionMetadata
    {
        [Display(Name ="Position")]
        [Required(AllowEmptyStrings = false, ErrorMessage ="Position is required")]
        public string PositionName { get; set; }        

        [Display(Name = "Number of Post in Each Position")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Number of Candidate is required")]        
        public string NumberOfPost { get; set; }          
    }
}