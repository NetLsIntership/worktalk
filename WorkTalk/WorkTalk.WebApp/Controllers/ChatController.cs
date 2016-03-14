using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Web.WebSockets;
using WorkTalk.WebApp.Controllers.Handlers;

namespace WorkTalk.WebApp.Controllers
{
    public class ChatController : ApiController
    {

        public HttpResponseMessage Get(string username, string password)
        {
            HttpContext.Current.AcceptWebSocketRequest(new ChatWebSocketHandler(username,password));
            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
        }

    }
}
