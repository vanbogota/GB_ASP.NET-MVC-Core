using FinalProject.Models;
using FinalProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class MessageController : Controller
    {
        private readonly ILogger<MessageController> _logger;
        private readonly SendMessageService _messageService;

        public MessageController(ILogger<MessageController> logger, SendMessageService messageService)
        {
            _logger = logger;            
            _messageService = messageService;
        }
        
        public async Task<IActionResult> SendMessage(User user) 
        {
            await _messageService.SendReportAsync(user);

            _logger.LogInformation($"{DateTime.UtcNow} Report send");

            return RedirectToAction("Index");
        }
    }
}
