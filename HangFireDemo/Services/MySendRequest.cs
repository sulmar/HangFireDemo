using System.Threading.Tasks;

namespace HangFireDemo.Services
{
    public class MySendRequest : ISendRequest
    {
        private readonly ISmsService smsService;
        private readonly IMessagesService messagesService;

        public MySendRequest(ISmsService smsService, IMessagesService messagesService)
        {
            this.smsService = smsService;
            this.messagesService = messagesService;
        }

        public void SendSms(string message)
        {
            smsService.Add(message);
            messagesService.Add(new Models.Message { Content = message });
        }

        public async Task SendSmsAsync(string message)
        {
            smsService.Add(message);
            messagesService.Add(new Models.Message { Content = message });
        }
    }
}
