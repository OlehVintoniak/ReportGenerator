namespace ReportGenerator.Interfaces
{
    public interface IReportGeneratorService
    {
        byte[] GenerateStudyReport(string reportPath, string stylesPath, string content);
    }
}
