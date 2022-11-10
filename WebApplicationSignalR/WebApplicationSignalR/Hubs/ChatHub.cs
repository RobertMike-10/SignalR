using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplicationSignalR.Data;

namespace WebApplicationSignalR.Hubs
{
    public class ChatHub: Hub
    {
        private readonly ApplicationDbContext _db;

        public ChatHub(ApplicationDbContext db)
        {
            _db = db;
        }
        public override Task OnConnectedAsync()
        {
            var UserId = Context!.User!.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(UserId))
            {
                var userName =  _db.Users.FirstOrDefault(u => u.Id == UserId)!.UserName;
                Clients.Users(HubConnections.OnlineUsers()).SendAsync("ReceiveUserConnected", UserId, 
                              userName,HubConnections.HasUser(UserId));
                HubConnections.AddUserConnection(UserId, Context.ConnectionId);

            }

            return base.OnConnectedAsync();
        }
    }
}
