using System;
using System.ComponentModel.DataAnnotations;

namespace ReportGenerator.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string FatherName { get; set; }

        [Required]
        [Range(1, 6)]
        public int Course { get; set; }
    }
}
