using System.IO;

namespace ReportGenerator.Utility
{
    public static class Content
    {
        public static string GetTemplate(string path)
        {
            var html = File.ReadAllText(path);
            return html;
        }
    }
}
