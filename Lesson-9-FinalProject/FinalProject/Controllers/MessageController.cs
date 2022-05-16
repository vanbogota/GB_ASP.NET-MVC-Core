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
        
        public async Task<IActionResult> SendMessage() 
        {
            SendMessageService sendMessageService = new(_mailGatewayOptions);
            await sendMessageService.SendReportAsync();

            _logger.LogInformation($"{DateTime.UtcNow} Report send");

            return RedirectToAction("Index");
        }
    }
}
