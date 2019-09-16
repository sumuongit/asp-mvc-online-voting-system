using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace OnlineVotingSystem.Models
{
    [MetadataType(typeof(VoterMetadata))]
    public partial class Voter
    {
        
    }

    public class VoterMetadata
    {
        [Display(Name ="Voter Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage ="Voter Name is required")]
        public string Name { get; set; }

        [Display(Name = "Service Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Service Id is required")]       
        public string ServiceId { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mobile Number is required")]        
        public string MobileNo { get; set; }

        [Display(Name = "Email Id")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Email Id is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Blood Group")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Blood Group is required")]
        public string BloodGroup { get; set; }

        [Display(Name = "Committed Vote?")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Committed Vote is required")]
        public bool IsCommittedVote { get; set; }
    }
}