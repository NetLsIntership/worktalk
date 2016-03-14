using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        public IEnumerable<User> GetAll()
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

        public User GetByName(string name)
        {
            var users = GetAll();
            return users.FirstOrDefault(u => u.Name.Equals(name));
        }

        public bool IsUserExists(User user)
        {
            var users = GetAll();
            return users.Any(u => user.Name.Equals(u.Name) && user.Password.Equals(u.Password));
        }

        public Guid SignIn(string username)
        {
            var user = GetAll().First(u => u.Name.Equals(username)/* && u.Password.Equals(password)*/);
            if (user != null)
                return user.Id;
            return Guid.Empty;
        }

        public User SignUp()
        {
            return new User();
        }
    }
}
