using System;
using System.Collections.Generic;
using WorkTalk.Domain.Entities;

namespace WorkTalk.Domain.Abstract
{
    public interface IUserRepository
    {
        IList<User> GetAll();
        User Get(Guid id);
        User Save(User user);
    }
}
