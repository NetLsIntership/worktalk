using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Message> GetAll()
        {
            return _client.GetAll();
        }

        public IEnumerable<Message> GetLastDay()
        {
            return _client.GetAll().Where(m => m.Time > DateTime.Today.AddDays(-2));
        }

        public IEnumerable<Message> GetLastWeek()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetLastMoonth()
        {
            throw new NotImplementedException();
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
