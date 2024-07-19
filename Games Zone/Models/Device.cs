namespace Games_Zone.Models
{
    public class Device : BaseEntity
    {
        [MaxLength(55)]
        public string Icon { get; set; } = string.Empty;
    }
}
