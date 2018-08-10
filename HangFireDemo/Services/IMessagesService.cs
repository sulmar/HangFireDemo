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
        Task AddAsync(Message message);
    }
}
