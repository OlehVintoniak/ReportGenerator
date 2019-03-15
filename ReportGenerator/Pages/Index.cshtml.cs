using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReportGenerator.Interfaces;
using ReportGenerator.Models;
using System;
using System.Collections.Generic;

namespace ReportGenerator.Pages.Reports.Study
{
    public class IndexModel : PageModel
    {
        private const string _reportPath = "wwwroot/Reports/StudyReport/pdf.html";
        private const string _stylesPath = "wwwroot/Reports/StudyReport";

        public List<Student> Students;

        private IStudentService _studentService;
        private IConverter _converter;
        private IReportGeneratorService _rGenerator;
        public IndexModel(IStudentService studentService,
            IConverter converter,
            IReportGeneratorService rGenerator)
        {
            _studentService = studentService;
            _rGenerator = rGenerator;
            _converter = converter;
        }

        public void OnGet()
        {
            Students = _studentService.GetAll();
        }

        public IActionResult OnPost(StudyReportData reportData)
        {
            var student = _studentService.GetById(reportData.StudentId);
            //var coursNumber = DateTime.Now.Year - student.EnterDate.Year;
            var coursNumber = student.Course;
            var daysAmount = (reportData.DateTo - reportData.DateFrom).Days;
            var html = Utility.Content.GetTemplate(_reportPath);

            html = html.Replace("{{name}}", $"{student.LastName} {student.FirstName} {student.FatherName}");
            html = html.Replace("{{organization name}}", reportData.OrganizationName);
            html = html.Replace("{{cours}}", coursNumber.ToString());
            html = html.Replace("{{days}}", daysAmount.ToString());

            html = html.Replace("{{day}}", reportData.DateFrom.Day.ToString());
            html = html.Replace("{{month}}", reportData.DateFrom.Month.ToString());
            html = html.Replace("{{year}}", reportData.DateFrom.Year.ToString());

            html = html.Replace("{{day2}}", reportData.DateTo.Day.ToString());
            html = html.Replace("{{month2}}", reportData.DateTo.Month.ToString());
            html = html.Replace("{{year2}}", reportData.DateTo.Year.ToString());

            var file = _rGenerator.GenerateStudyReport(_reportPath, _stylesPath, html);
            return File(file, "application/pdf");
        }
    }
}