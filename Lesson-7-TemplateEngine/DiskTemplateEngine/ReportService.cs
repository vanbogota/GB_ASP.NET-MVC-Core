using TemplateEngine.Docx;

namespace DiskTemplateEngine
{
    public sealed class ReportService
    {
        private readonly string _pathToTemplate;

        public ReportService(string pathToTemplate)
        {
            _pathToTemplate = pathToTemplate;
        }
        public void GenerateReport(DiskInfo diskInfo, string output = "")
        {
            if (diskInfo is null || diskInfo.DiskMetrics == null)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(output))
            {
                output = Path.Combine(Directory.GetCurrentDirectory(), "DiskReport.docx");
            }
            if (File.Exists(output))
            {
                File.Delete(output);
            }

            File.Copy(_pathToTemplate, output);

            List<TableRowContent> rows = new List<TableRowContent>();

            foreach (Disk order in diskInfo.DiskMetrics)
            {
                rows.Add(new TableRowContent(new List<FieldContent>()
                {
                    new FieldContent("Report Date", order.DateOfMetric.ToString()),
                    new FieldContent("Free Memory", order.Memory.ToString())
                }));
            }

            var valuesToFill = new Content(
                new FieldContent("Disk Name", diskInfo.DiskName),
                TableContent.Create("Report Memory Table", rows)
                );

            using (var outputDocument =
                new TemplateProcessor(output)
                .SetRemoveContentControls(true))
            {
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();
            }
        }
    }
}
