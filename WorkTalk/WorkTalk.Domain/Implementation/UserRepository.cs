using System;
using System.CodeDom;
using System.Collections.Generic;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using WorkTalk.Domain.Abstract;
using WorkTalk.Domain.Entities;

namespace WorkTalk.Domain.Implementation
{
    public class UserRepository : IUserRepository
    {
        public IRedisTypedClient<User> Client { get; }

        public UserRepository(IRedisClient client)
        {
            Client = client.As<User>();
        }

        public IList<User> GetAll()
        {
            return Client.GetAll();
        }

        public User GetById(Guid id)
        {
            return Client.GetById(id);
        }

        public User Save(User user)
        {
            if (user.Id == default(Guid))
                user.Id = Guid.NewGuid();
            return Client.Store(user);
        }
    }
}
