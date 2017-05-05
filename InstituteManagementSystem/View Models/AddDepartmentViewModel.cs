using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InstituteManagementSystem.View_Models
{
    public class AddDepartmentViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Faculty")]
        public int FacID { get; set; }
    }
}