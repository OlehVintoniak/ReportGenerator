using System.IO;

namespace ReportGenerator.Utility
{
    public static class StudyReportGenerator
    {
        public static string GetHtmlString()
        {
            var html = File.ReadAllText("wwwroot/Reports/StudyReport/pdf.html");
            return html;
        }
    }
}
