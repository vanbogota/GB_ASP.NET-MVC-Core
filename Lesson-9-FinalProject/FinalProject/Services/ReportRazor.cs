using FinalProject.Interfaces;
using RazorEngine;
using RazorEngine.Templating;

namespace FinalProject.Services;

public class ReportRazor : IReport
{
    private const string _TemplateText = @"Report for Manager
Report Number: @Model.ReportNumber
Creation Time: @Model.ReportCreationTime.ToString(""dd.MM.yyyy HH:mm:ss"")
Subject: @Model.ReportDescription";
    public Guid ReportNumber { get; }
    public DateTime CreationDate { get; set; }
    public string? Description { get; set; }
    public ReportRazor()
    {
        ReportNumber = Guid.NewGuid();
    }

    public string Create(string ReportFilePath)
    {
        //var report_file = new FileInfo(templateRazor);
        //report_file.Delete();

        var template_text = _TemplateText;

        var result = Engine.Razor.RunCompile(template_text, "ReportTemplate", null, new
        {
            ReportNumber,
            ReportCreationTime = CreationDate,
            ReportDescription = Description
        });

        //using (var writer = report_file.CreateText())
        //    writer.Write(result);

        //report_file.Refresh();
        //return report_file;

        return result;
    }
}
