using FinalProject.Models;

namespace FinalProject.Interfaces;

public interface ISendMessageService
{
    Task SendMessageAsync(Message message);
}
