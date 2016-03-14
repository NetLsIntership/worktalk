using System;
using System.Collections.Generic;
using WorkTalk.Domain.Entities;

namespace WorkTalk.Domain.Abstract
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetAll();
        IEnumerable<Message> GetLastDay();
        IEnumerable<Message> GetLastWeek();
        IEnumerable<Message> GetLastMoonth();
            Message Get(Guid id);
        Message Save(Message message);
    }
}
