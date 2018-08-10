using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangFireDemo.Services
{

    public interface ISmsService
    {
        void Add(string message);
        Task AddAsync(string message);

    }
}
