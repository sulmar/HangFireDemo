using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace HangFireDemo.Services
{
    public class MySmsService : ISmsService
    {
        public void Add(string message)
        {
            Debug.WriteLine($"Adding message {message}");

            Thread.Sleep(TimeSpan.FromMinutes(1));

            Debug.WriteLine($"Added message {message}");
        }

        public async Task AddAsync(string message)
        {
            Debug.WriteLine($"Adding async message {message}");

            await Task.Delay(TimeSpan.FromSeconds(5));

            Debug.WriteLine($"Added async message {message}");
        }
    }
}
