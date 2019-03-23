using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReportGenerator.Interfaces;
using ReportGenerator.Models;
using System.Collections.Generic;

namespace ReportGenerator.Pages.Students
{
    public class UpdateModel : PageModel
    {
        private IStudentService _studentService;

        public Student _student;
        public List<int> _courses = new List<int>();
        public UpdateModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public void OnGet(int id)
        {
            _student = _studentService.GetById(id);
            for (var i = 1; i <= 6; i++)
            {
                _courses.Add(i);
            }
        }

        public IActionResult OnPost(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.Update(student);
                return RedirectToPage("Index");

            }
            return RedirectToPage("Update");
        }

    }
}