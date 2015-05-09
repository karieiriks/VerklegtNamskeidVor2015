using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApplication.Models.Entities;

namespace TravelBookApplication.Models.Repositories
{
    public interface IMessageRepository
    {
        IQueryable<Message> Messages { get; }
        Message Save(Message message);
        void Delete(Message message);
    }
}
