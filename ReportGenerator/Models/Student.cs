using System;
using System.ComponentModel.DataAnnotations;

namespace ReportGenerator.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FatherName { get; set; }

        [Required]
        public string GroupName { get; set; }

        [Required]
        public DateTime EnterDate { get; set; }
    }
}
