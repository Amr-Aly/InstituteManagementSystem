using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InstituteManagementSystem.Models
{
    public class Department
    {
        public Department()
        {
            Students = new List<Student>();
            Courses = new List<Course>();
        }
        /* ID of The Department */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        /* Name of The Department */
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int facId { get; set; }

        public Faculty faculty { get; set; }


        public IList<Student> Students { get; set; }

        public IList<Course> Courses { get; set; }
    }
}