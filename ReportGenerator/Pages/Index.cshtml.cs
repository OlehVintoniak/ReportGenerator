using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReportGenerator.Interfaces;
using ReportGenerator.Models;
using System.Collections.Generic;

namespace ReportGenerator.Pages.Reports.Study {
  public class IndexModel : PageModel {

    public List<Student> Students;

    private IStudentService _studentService;
    public IndexModel(IStudentService studentService) {
      _studentService = studentService;
    }

    public void OnGet(int? courseNumber) {
      if (courseNumber == null) {
        Students = new List<Student>();
      }
      else {
        Students = _studentService.GetByCourse(courseNumber.Value);
      }
    }

    public IActionResult OnPost(StudyReportData reportData) {
      var student = _studentService.GetById(reportData.StudentId);
      var data = new DovidkaData {
        Name = $"{student.LastName} {student.FirstName} {student.FatherName}",
        OrganizationName = reportData.OrganizationName,
        Cours = student.Course.ToString(),
        Days = (reportData.DateTo - reportData.DateFrom).Days.ToString(),
        Day = reportData.DateFrom.Day.ToString(),
        Month = reportData.DateFrom.Month.ToMonthName(),
        Year = reportData.DateFrom.Year.ToString(),
        Day2 = reportData.DateTo.Day.ToString(),
        Month2 = reportData.DateTo.Month.ToMonthName(),
        Year2 = reportData.DateTo.Year.ToString()
      };
      return RedirectToPage("Dovidka", data);
    }
  }
}