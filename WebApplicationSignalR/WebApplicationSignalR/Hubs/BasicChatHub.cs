using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebApplicationSignalR.Data;

namespace WebApplicationSignalR.Hubs
{
    public class BasicChatHub: Hub
    {
        private readonly ApplicationDbContext _db;
        public BasicChatHub(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task SendMessageToAll(string user, string message)
        {
            await Clients.All.SendAsync("MessageReceived", user, message);
        }

        [Authorize]
        public async Task SendPrivateMessage(string sender, string receiver, string message)
        {
            var userId =  _db.Users.FirstOrDefault(u => u.Email.ToLower() == sender.ToLower())!.Id;

            if (!string.IsNullOrEmpty(userId))
            {
                var destinataryId = _db.Users.FirstOrDefault(u => u.Email.ToLower() == receiver.ToLower())!.Id;
                if (!string.IsNullOrEmpty(destinataryId))
                {
                    await Clients.User(destinataryId.ToString()).SendAsync("MessageReceived", sender, message);
                }
            }
        }
    }
}
