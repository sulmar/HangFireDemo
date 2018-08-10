using System.Threading.Tasks;

namespace HangFireDemo.Services
{
    public interface ISendRequest
    {
        void SendSms(string message);
        Task SendSmsAsync(string message);
    }
}
