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

        public string FatherName { get; set; }

        public string GroupName { get; set; }

        public DateTime EnterDate { get; set; }

        [Required]
        public int Course { get; set; }
    }
}
