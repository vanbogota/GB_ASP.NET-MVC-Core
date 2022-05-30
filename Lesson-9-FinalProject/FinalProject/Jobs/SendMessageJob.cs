using FinalProject.Models;
using FinalProject.Repositories;
using FinalProject.Services;
using Quartz;

namespace FinalProject.Jobs
{
    public class SendMessageJob : IJob
    {
        private readonly MailGatewayOptions _mailGatewayOptions;
        private readonly IUserRepository _userRepository;

        public SendMessageJob(MailGatewayOptions mailGatewayOptions, IUserRepository userRepository)
        {
            _mailGatewayOptions = mailGatewayOptions;
            _userRepository = userRepository;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var users = _userRepository.GetAll();

            SendMessageService sendMessage = new(_mailGatewayOptions);

            foreach (var user in users)
            {
                await sendMessage.SendReportAsync(user);
            }                        
        }
    }
}
