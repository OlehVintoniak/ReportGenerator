using DinkToPdf;
using DinkToPdf.Contracts;
using ReportGenerator.Interfaces;
using System.IO;

namespace ReportGenerator.Services
{
    public class ReportGeneratorService : IReportGeneratorService
    {
        private IConverter _converter;
        public ReportGeneratorService(IConverter converter)
        {
            _converter = converter;
        }
        public byte[] GenerateStudyReport(string reportPath, string stylesPath, string content)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                DocumentTitle = "PDF Report",
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = content,
                WebSettings = {
                    DefaultEncoding = "utf-8",
                    UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), stylesPath, "styles.css")
                },
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);
            return file;
        }
    }
}
