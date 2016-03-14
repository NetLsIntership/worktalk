using System;
using System.Collections.Generic;
using WorkTalk.Domain.Entities;

namespace WorkTalk.Domain.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(Guid id);
        User GetByName(string name);
        User Save(User user);
        bool IsUserExists(User user);
        Guid SignIn(string username/*, string password*/);
    }
}
