using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HangFireDemo.Services
{
    public interface ISendRequest
    {
        void SendSms(string message);
    }

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
    }

    public interface ISmsService
    {
        void Add(string message);
    }

    public class MySmsService : ISmsService
    {
        public void Add(string message)
        {
            Debug.WriteLine($"Adding message {message}");

            Thread.Sleep(TimeSpan.FromMinutes(1));

            Debug.WriteLine($"Added message {message}");
        }
    }
}
