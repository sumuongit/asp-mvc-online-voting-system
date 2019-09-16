using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineVotingSystem.Models
{
    [MetadataType(typeof(UserMetadata))]
    public class Login
    {
    }
    public class UserMetadata
    {
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Invalid email address!")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}