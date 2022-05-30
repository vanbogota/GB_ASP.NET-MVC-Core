using FinalProject.Models;

namespace FinalProject.Services;

public interface ISendMessageService
{
    Task SendReportAsync(User user);
}
