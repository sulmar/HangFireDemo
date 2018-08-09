using HangFireDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo.Services
{
    public interface IMessagesService
    {
        void Add(Message message);
    }

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
    }
}
