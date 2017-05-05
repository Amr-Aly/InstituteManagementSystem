using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InstituteManagementSystem.Models
{
    public class Course
    {
        /* ID of The Course */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int NoOfCredit { get; set; }

        [Required]
        public int depId { get; set; }

        public Department department { get; set; }
    }
}