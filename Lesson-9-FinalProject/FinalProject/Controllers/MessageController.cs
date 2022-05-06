using FinalProject.Models;
using FinalProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class MessageController : Controller
    {
        private readonly ILogger<MessageController> _logger;
        private readonly MailGatewayOptions _mailGatewayOptions;

        public MessageController(ILogger<MessageController> logger, MailGatewayOptions mailGatewayOptions)
        {
            _logger = logger;
            _mailGatewayOptions = mailGatewayOptions;
        }
        
        public async Task<IActionResult> SendMessage(Message message) 
        {
            SendMessageService sendMessageService = new(_mailGatewayOptions);
            await sendMessageService.SendMessageAsync(message);
            _logger.LogInformation($"{DateTime.UtcNow} Message send");
            return RedirectToAction("Index");
        }

        public IActionResult SendMessage() => View();
        
    }
}
