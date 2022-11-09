namespace WebApplicationSignalR.Models.ViewModels
{
    public class ChatVM
    {
        public IList<ChatRoom> Rooms { get;set; }
        public int MaxRoomAllowed { get; set; }
        public string? UserId { get; set; }

        public ChatVM()
        {
            Rooms = new List<ChatRoom>();
        }

        public bool AllowAddRom => Rooms == null || Rooms.Count < MaxRoomAllowed;
    }
}
