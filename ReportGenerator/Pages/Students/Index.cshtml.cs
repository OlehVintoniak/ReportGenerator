using Microsoft.AspNetCore.Mvc.RazorPages;
using ReportGenerator.Interfaces;
using ReportGenerator.Models;
using System.Collections.Generic;

namespace ReportGenerator.Pages.Students
{
    public class IndexModel : PageModel
    {
        public List<Student> _list = new List<Student>();
        private IStudentService _studentService;

        public IndexModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public void OnGet()
        {
            _list = _studentService.GetAll();
        }
    }
}