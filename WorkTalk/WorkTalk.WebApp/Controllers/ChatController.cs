using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Web.WebSockets;
using ServiceStack.Redis;
using WorkTalk.Domain.Abstract;
using WorkTalk.Domain.Entities;
using WorkTalk.Domain.Implementation;
using WorkTalk.WebApp.Controllers.Handlers;

namespace WorkTalk.WebApp.Controllers
{
    public partial class ChatController : ApiController
    {

        public HttpResponseMessage Get(string username, string password)
        {
            HttpContext.Current.AcceptWebSocketRequest(new ChatWebSocketHandler(username,
                password));
            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
        }

    }
}
