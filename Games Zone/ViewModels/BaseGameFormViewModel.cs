namespace Games_Zone.ViewModels
{
    public class BaseGameFormViewModel
    {
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

        [DisplayName("Supprted Devices")]
        public List<int> SelectedDevices { get; set; } = default!;
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;

        [Range(0, 10)]
        public double Rate { get; set; }


        [Range(3,21)]
        public int AgeRate { get; set; }

        
    }
}
