using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReportGenerator.Interfaces;
using ReportGenerator.Models;

namespace ReportGenerator.Pages.Students
{
    public class CreateModel : PageModel
    {
        private IStudentService _studentsService;

        public CreateModel(IStudentService studentService)
        {
            _studentsService = studentService;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(Student student)
        {
            _studentsService.Create(student);
            return RedirectToPage("Index");
        }
    }
}