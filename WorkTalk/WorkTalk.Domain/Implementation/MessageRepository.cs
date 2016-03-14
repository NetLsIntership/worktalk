using System;
using System.Collections.Generic;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using WorkTalk.Domain.Abstract;
using WorkTalk.Domain.Entities;

namespace WorkTalk.Domain.Implementation
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IRedisTypedClient<Message> _client;

        public MessageRepository(IRedisClient client)
        {
            _client = client.As<Message>();
        } 
        public IList<Message> GetAll()
        {
            return _client.GetAll();
        }

        public Message Get(Guid id)
        {
            return _client.GetById(id);
        }

        public Message Save(Message message)
        {
            if(message.Id == default(Guid))
                message.Id = Guid.NewGuid();
            return _client.Store(message);
        }
    }
}
