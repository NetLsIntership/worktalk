using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Web.WebSockets;
using ServiceStack.Redis;
using WorkTalk.Domain.Abstract;
using WorkTalk.Domain.Entities;
using WorkTalk.Domain.Implementation;

namespace WorkTalk.WebApp.Controllers
{
    public class ChatController : ApiController
    {
        
        public HttpResponseMessage Get(string username, string password)
        {
            HttpContext.Current.AcceptWebSocketRequest(new ChatWebSocketHandler(username, password));
            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
        }
     
        class ChatWebSocketHandler : WebSocketHandler
       {
            IUserRepository _userRepository = new UserRepository(new RedisClient("localhost"));
           private static WebSocketCollection _chatClients = new WebSocketCollection();
           private string _username;
            private string _password;
    
           public ChatWebSocketHandler(string username, string password)
           {
               _username = username;
               _password = password;
           }
    
           public override void OnOpen()
           {
               _chatClients.Add(this);
               _userRepository.Save(new User {Name = _username, Password = _password});
           }
    
           public override void OnMessage(string message)
           {
               _chatClients.Broadcast(_username + ": " + message);
           }
       }
    }
}
