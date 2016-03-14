using System;
using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json.Linq;
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

        //[HttpPost]
        //[Route("api/account/signin")]
        //public  SignIn (JObject obj)
        //{

        //    return _userRepository.SignIn(username/*, password*/);
        //}

        public Guid SignUp(string username, string password)
        {
            return Guid.Empty;
        }
    }
}
