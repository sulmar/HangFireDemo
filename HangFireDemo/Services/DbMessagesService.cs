using HangFireDemo.Models;
using System.Threading.Tasks;

namespace HangFireDemo.Services
{
    public class DbMessagesService : IMessagesService
    {
        private readonly MyContext context;

        public DbMessagesService(MyContext context)
        {
            this.context = context;
        }

        public void Add(Message message)
        {
            context.Database.EnsureCreated();

            context.Add(message);
            context.SaveChanges();
        }

        public async Task AddAsync(Message message)
        {
            await context.AddAsync(message);
            await context.SaveChangesAsync();
        }
    }
}
