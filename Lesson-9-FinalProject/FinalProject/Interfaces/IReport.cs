namespace FinalProject.Interfaces;
public interface IReport
{
    Guid ReportNumber { get; }
    DateTime CreationDate { get; set; }
    string? Description { get; set; }
    string Create(string ReportFilePath);
}
