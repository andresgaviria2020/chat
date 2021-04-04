using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;


namespace chat_application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]

    public class MessageController : ControllerBase
    {
        private ChatHub _hub;
        public MessageController(ChatHub hub)
        {
            _hub = hub;
        }
        [HttpPost]
        public string Post([FromBody] ChatMessage msg)
        {
            string retMessage = string.Empty;
            try
            {
               // _hub.BroadcastMessage(msg.message);
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }
            return retMessage;
        }
    }
}