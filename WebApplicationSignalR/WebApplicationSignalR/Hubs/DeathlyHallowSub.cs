using Microsoft.AspNetCore.SignalR;

namespace WebApplicationSignalR.Hubs
{
    public class DeathlyHallowSub:Hub
    {
        public Dictionary<string,int> GetRaceStatus()
        {
            return StaticData.DeathlyHallowRace;
        }

 
    }
}
