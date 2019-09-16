using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace OnlineVotingSystem.Models
{
    [MetadataType(typeof(CandidateMetadata))]
    public partial class Candidate
    {
        
    }

    public class CandidateMetadata
    {
        [Display(Name ="Candidate Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage ="Candidate Name is required")]
        public string Name { get; set; }

        [Display(Name = "Service Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Service Id is required")]       
        public string ServiceId { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mobile Number is required")]        
        public string MobileNo { get; set; }

        [Display(Name = "Email Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Id is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Photo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Photo is required")]
        [DataType(DataType.EmailAddress)]
        public string PhotoPath { get; set; }   
    }
}