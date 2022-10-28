using Microsoft.AspNetCore.SignalR;

namespace WebApplicationSignalR.Hubs
{
    public class HouseGroupHub:Hub
    {
        public static List<string> GroupsJoined { get; set; } = new();

        public async Task JoinHouse(string house)
        {
            var key = Context.ConnectionId + ":" + house;
            if (!GroupsJoined.Contains(key))
            {
                GroupsJoined.Add(key);
                await Groups.AddToGroupAsync(Context.ConnectionId, house);
            }

        }
    }
}
