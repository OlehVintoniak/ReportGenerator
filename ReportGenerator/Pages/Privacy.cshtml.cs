using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReportGenerator.Utility;
using System.IO;

namespace ReportGenerator.Pages
{
    public class PrivacyModel : PageModel {

    private IConverter _converter;

    public PrivacyModel(IConverter converter) {
      _converter = converter;
    }

    public IActionResult OnGet() {

            

      var globalSettings = new GlobalSettings {
        ColorMode = ColorMode.Color,
        Orientation = Orientation.Portrait,
        PaperSize = PaperKind.A4,
        //Margins = new MarginSettings { Top = 10 },
        DocumentTitle = "PDF Report",
        //Out = @"D:\PDFCreator\Employee_Report.pdf"  USE THIS PROPERTY TO SAVE PDF TO A PROVIDED LOCATION
      };

      var objectSettings = new ObjectSettings
      {
        PagesCount = true,
        HtmlContent = Utility.Content.GetTemplate("wwwroot/Reports/StudyReport/pdf.html"),//TemplateGenerator.GetHTMLString(),
        //Page = "https://code-maze.com/", USE THIS PROPERTY TO GENERATE PDF CONTENT FROM AN HTML PAGE
        WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Reports/StudyReport", "styles.css") },
        //HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
        //FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
      };

      var pdf = new HtmlToPdfDocument() {
        GlobalSettings = globalSettings,
        Objects = { objectSettings }
      };

      var file = _converter.Convert(pdf);

      return File(file, "application/pdf");
    }
  }
}