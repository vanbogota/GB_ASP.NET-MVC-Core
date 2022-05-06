using FinalProject.Interfaces;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Services
{
    public class SendMessageService : ISendMessageService
    {
        private MailGatewayOptions _mailGatewayOptions;

        public SendMessageService(MailGatewayOptions mailGatewayOptions)
        {
            _mailGatewayOptions = mailGatewayOptions;
        }

        public async Task SendMessageAsync(Message message)
        {
            MessageGateway messageGateway = new MessageGateway(_mailGatewayOptions);
            try
            {
                await messageGateway.SendMessageAsync(message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                messageGateway.Dispose();
            }            
        }       
    }
}
