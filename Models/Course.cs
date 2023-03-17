using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BigSchool.Models
{
    public class Course
    {
        public int Id { get; set; }
        public ApplicationUser Lecturer { get; set; }
        [Required]
        public string Lecturerid { get; set; }
        [Required]
        [StringLength (255)]
        public string Place { get; set; }
        public string DataTime { get; set; }

        public string CategoryId { get; set; }
    }

   
}