using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Web.WebSockets;
using WorkTalk.WebApp.Controllers.Api.Handlers;

namespace WorkTalk.WebApp.Controllers.Api
{
    public class ChatController : ApiController
    {

        public HttpResponseMessage Get(string username = "test", string password = "test")
        {
            HttpContext.Current.AcceptWebSocketRequest(new ChatWebSocketHandler(username, password));
            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
        }

    }
}
