using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InstituteManagementSystem.View_Models
{
    public class AddStudentViewModel
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
        public int Department { get; set; }

    }
}