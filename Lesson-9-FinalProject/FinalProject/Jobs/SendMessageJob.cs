using FinalProject.Repositories;
using FinalProject.Services;
using Quartz;
using Identity.DAL.Context;
using Microsoft.AspNetCore.Identity;
using Identity.DAL.Entities;

namespace FinalProject.Jobs
{
    public class SendMessageJob : IJob
    {
        private readonly MailGatewayOptions _mailGatewayOptions;
        private readonly IdentityDB _dB;

        public SendMessageJob(MailGatewayOptions mailGatewayOptions, IdentityDB dB)
        {
            _mailGatewayOptions = mailGatewayOptions;
            _dB = dB;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var users = _dB.Users.ToList();

            SendMessageService sendMessage = new(_mailGatewayOptions);

            foreach (var user in users)
            {
                await sendMessage.SendReportAsync(user);
            }                        
        }
    }
}
