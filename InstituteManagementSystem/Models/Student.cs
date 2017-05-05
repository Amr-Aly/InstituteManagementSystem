using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InstituteManagementSystem.Models
{
    public class Student
    {
        /* ID of The Student */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public int depId { get; set; }

        [Required]
        public int facId { get; set; }

        /* Student Department */
        public Department department { get; set; }
    }
}