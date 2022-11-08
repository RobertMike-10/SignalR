using Microsoft.AspNetCore.SignalR;

namespace WebApplicationSignalR.Hubs
{
    public class BasicChatHub: Hub
    {

        public async Task SendMessageToAll(string user, string message)
        {
            await Clients.All.SendAsync("MessageReceived", user, message)
        }
    }
}
