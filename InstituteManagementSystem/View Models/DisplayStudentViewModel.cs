using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace InstituteManagementSystem.View_Models
{
    public class DisplayStudentViewModel
    {
        [Required]
        public int Id { get; set; }

        /* Student Name */
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        /* Student Gender */
        [Required]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Department")]
        public string dep{ get; set; }

        [Required]
        [Display(Name="Faculty")]
        public string fac { get; set; }
    }
}