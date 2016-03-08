using System;
using System.Collections.Generic;
using ServiceStack.Messaging;

namespace WorkTalk.Domain.Abstract
{
    public interface IMessageRepository
    {
        IList<Message> GetAll();
        Message Get(Guid id);
        Message Save(Message message);
    }
}
