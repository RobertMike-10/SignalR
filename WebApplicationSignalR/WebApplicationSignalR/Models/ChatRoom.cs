using System.ComponentModel.DataAnnotations;

namespace WebApplicationSignalR.Models
{
    public class ChatRoom
    {
        public int ChatRoomId { get; set; }
        [Required]
        public int Name { get; set; }

    }
}
