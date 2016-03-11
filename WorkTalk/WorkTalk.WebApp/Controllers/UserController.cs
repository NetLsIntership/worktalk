using System;
using System.Web.Http;
using ServiceStack.Redis;
using WorkTalk.Domain.Abstract;
using WorkTalk.Domain.Entities;
using WorkTalk.Domain.Implementation;

namespace WorkTalk.WebApp.Controllers
{
    public class UserController : ApiController
    {
        IUserRepository _userRepository = new UserRepository(new RedisClient("localhost"));

        [HttpGet]
        public User Get(Guid id)
        {
            return _userRepository.GetById(id);
        }
    }
}
