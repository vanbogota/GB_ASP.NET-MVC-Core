using FinalProject.Models;
using FinalProject.Services;
using Quartz;

namespace FinalProject.Jobs
{
    //остановился тута, нужно добавить сучностей
    public class SendMessageJob : IJob
    {
        MailGatewayOptions _mailGatewayOptions;
        public SendMessageJob(MailGatewayOptions mailGatewayOptions)
        {
            _mailGatewayOptions = mailGatewayOptions;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            SendMessageService sendMessageService = new(_mailGatewayOptions);

            await sendMessageService.SendReportAsync();            
        }
    }
}
