using System;

namespace ReportGenerator.Models
{
    public class StudyReportData
    {
        public int StudentId { get; set; }

        public string OrganizationName { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}
