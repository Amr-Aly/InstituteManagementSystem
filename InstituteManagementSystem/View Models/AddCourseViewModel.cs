using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace InstituteManagementSystem.View_Models
{
    public class AddCourseViewModel
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int NoOfCredit { get; set; }

        [Required]
        public string departmentName { get; set; }
    }
}