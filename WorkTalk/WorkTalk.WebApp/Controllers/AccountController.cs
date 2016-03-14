using System;
using System.Collections.Generic;
using System.Web.Http;
using ServiceStack.Redis;
using WorkTalk.Domain.Abstract;
using WorkTalk.Domain.Entities;
using WorkTalk.Domain.Excepitons;
using WorkTalk.Domain.Implementation;

namespace WorkTalk.WebApp.Controllers
{
    public class AccountController : ApiController
    {
        IUserRepository _userRepository = new UserRepository(new RedisClient("localhost"));

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        [HttpPost]
        public User Register(User user)
        {
            if (_userRepository.IsUserExists(user))
                throw new UserIsRegisteredException("There is registered user with this credentials");
            return _userRepository.Save(user);
        }
    }
}
