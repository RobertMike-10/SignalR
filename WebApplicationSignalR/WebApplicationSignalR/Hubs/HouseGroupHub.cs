using Microsoft.AspNetCore.SignalR;

namespace WebApplicationSignalR.Hubs
{
    public class HouseGroupHub:Hub
    {
        public static List<string> GroupsJoined { get; set; } = new();

        public async Task TriggerHouseNotification(string houseName)
        {
            await Clients.Group(houseName).SendAsync("triggerHouseNotification", houseName);
        }
        public async Task JoinHouse(string house)
        {
            var key = Context.ConnectionId + ":" + house;
            if (!GroupsJoined.Contains(key))
            {
                GroupsJoined.Add(key);
                await Task.WhenAll(Clients.Caller.SendAsync("subscriptionStatus", HouseList(GroupsJoined), house, true),
                             Clients.Others.SendAsync("memberAddedToHouse", house),
                             Groups.AddToGroupAsync(Context.ConnectionId, house));
                
            }

        }

        private string HouseList(List<string> groups)
        {
            string result="";
            foreach (var str in groups)
            {
                if(str.Contains(Context.ConnectionId))
                {
                    result += str.Split(':')[1] + " ";
                }
            }
            return result;
        }

        public async Task LeaveHouse(string house)
        {
            var key = Context.ConnectionId + ":" + house;
            if (GroupsJoined.Contains(key))
            {
                GroupsJoined.Remove(key);
                await Task.WhenAll(Clients.Caller.SendAsync("subscriptionStatus", HouseList(GroupsJoined), house, false),
                             Groups.RemoveFromGroupAsync(Context.ConnectionId, house),
                             Clients.Others.SendAsync("memberRemovedFromHouse", house));

            }

        }
    }
}
