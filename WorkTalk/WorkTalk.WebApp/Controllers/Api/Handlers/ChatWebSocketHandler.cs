using System;
using Microsoft.Web.WebSockets;
using ServiceStack.Redis;
using WorkTalk.Domain.Abstract;
using WorkTalk.Domain.Entities;
using WorkTalk.Domain.Implementation;

namespace WorkTalk.WebApp.Controllers.Api.Handlers
{
    public class ChatWebSocketHandler : WebSocketHandler
    {
        IUserRepository _userRepository = new UserRepository(new RedisClient("localhost"));
        IMessageRepository _messageRepository = new MessageRepository(new RedisClient("localhost"));
        private static WebSocketCollection _chatClients = new WebSocketCollection();
        private string _username;
        private string _password;
        private User _user = new User();

        public ChatWebSocketHandler(string username, string password)
        {
            _user.Name = username;
            _user.Password = password;
        }

        public override void OnOpen()
        {
            _chatClients.Add(this);
            _userRepository.Save(_user);
        }

        public override void OnMessage(string message)
        {
            _chatClients.Broadcast(_user.Name + ": " + message);
            _messageRepository.Save(new Message { Id = Guid.NewGuid(), Sender = _user.Id, Text = message, Time = DateTime.UtcNow });
        }
    }
}
