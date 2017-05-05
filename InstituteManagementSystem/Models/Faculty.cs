using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InstituteManagementSystem.Models
{
    public class Faculty
    {
        public Faculty()
        {
            departments = new List<Department>();
        }
        /* ID of The Faculty */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        /* Name of The Faculty */
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        /* Description of The Faculty */
        [MaxLength(200)]
        [Required(ErrorMessage="The Description is Required!!!")]
        public string Description { get; set; }

        /* Departmets in The Faculty */
        public IList<Department> departments { get; set; }
    }
}