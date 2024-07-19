

namespace Games_Zone.Models
{
    public class Game : BaseEntity
    {
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;

        //[MaxLength(500)]
        public string Cover { get; set; } =string.Empty;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!; //the "!" is to avoid nullability warnings

        public ICollection<GameDevice> Devices { get; set; } =new List<GameDevice>();

        public string GameWebsite { get; set; }

        
        public double Rate { get; set; }

        public int AgeRate { get; set; }

        public bool isAdult { get; set; } 
    }
}
