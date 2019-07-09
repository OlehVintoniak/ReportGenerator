using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReportGenerator.Pages {
  public class DovidkaModel : PageModel {

    public void OnGet(DovidkaData data) {
      ViewData["ViewData"] = data;
    }
  }

  public class DovidkaData {
    public string Name { get; set; }
    public string OrganizationName { get; set; }
    public string Cours { get; set; }
    public string Days { get; set; }
    public string Day { get; set; }
    public string Month { get; set; }
    public string Year { get; set; }
    public string Day2 { get; set; }
    public string Month2 { get; set; }
    public string Year2 { get; set; }
  }
}