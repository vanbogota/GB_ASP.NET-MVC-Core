using FinalProject.Interfaces;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Services
{
    public class SendMessageService : ISendMessageService
    {
        private MailGatewayOptions _mailGatewayOptions;
        
        private ReportRazor _report;
        public SendMessageService(MailGatewayOptions mailGatewayOptions)
        {
            _mailGatewayOptions = mailGatewayOptions;            
            _report = new ReportRazor();
        }

        public async Task SendReportAsync()
        {
            _report.CreationDate = DateTime.Now;
            _report.Description = $"Test Report {DateTime.Now}";
            var temp = _report.Create();

            Message message = new Message()
            {
                To = "user@user.com",
                Name = "UserName",
                Subject = $"Report {_report.ReportNumber}",
                Body = temp,
                IsHtml = false
            };

            using (MessageGateway messageGateway = new MessageGateway(_mailGatewayOptions))
            {
                await messageGateway.SendMessageAsync(message);
            }           
        }        
    }
}
