namespace Games_Zone.Models
{
    public class userGameDevice
    {
        public int DeviceId { get; set; }
        public Device Device { get; set; } = default!;

        public int userGameId { get; set; }

        public userGame userGame { get; set; } = default!;
    }
}
