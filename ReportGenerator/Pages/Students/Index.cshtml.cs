using Microsoft.AspNetCore.Mvc;
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

        public IActionResult OnPostDeleteAll()
        {
            _studentService.DeleteAll();
            return RedirectToAction("OnGet");
        }

        public IActionResult OnGetDeleteById(int id)
        {
            _studentService.Delete(id);
            return RedirectToAction("OnGet");
        }

        public IActionResult OnGetUpdate(int id)
        {
            return RedirectToPage("Update", new { id = id });
        }
    }
}