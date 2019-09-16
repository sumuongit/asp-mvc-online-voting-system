using OnlineVotingSystem.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineVotingSystem.Models
{
    public class ImportExcelFile
    {
        [Required(ErrorMessage = "Please select file")]
        [FileExtension(Allow = ".xls,.xlsx", ErrorMessage = "Only excel files are allowed")]
        public HttpPostedFileBase file { get; set; }
    }
}