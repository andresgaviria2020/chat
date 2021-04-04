using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace chat_application.Controllers
{
   // [Route("api/[controller]")]
    public class ChatHub : Hub
    {
        static HashSet<string> CurrentConnections = new HashSet<string>();

        public override Task OnConnectedAsync()
        {
            var id = Context.ConnectionId;
            CurrentConnections.Add(id);

            return base.OnConnectedAsync();
        }

        public async Task SendToAll(string name, string text)
        {
            var message = new ChatMessage
            {
                SenderName = name,
                Text = text,
                SendAt = DateTimeOffset.UtcNow.ToString(),
            };
            // invoke this ReceiveMessage method in the client
            // Broadcast to all clients
            await Clients.All.SendAsync(
                    "sendToAll",
                    message.SenderName,
                    message.Text,
                    message.SendAt
                );
        }


    }
}
