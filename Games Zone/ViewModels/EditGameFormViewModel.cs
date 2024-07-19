namespace Games_Zone.ViewModels
{
    public class EditGameFormViewModel :BaseGameFormViewModel
    {
        public int Id { get; set; }

        public string? CurrentCover { get; set; }

        //[MaxLength(500)]
        [AllowedExtensions(FileSettings.AllowedExtensions)]
        [MaxSizeAttribute(FileSettings.MaxFileSizeInBytes)]
        public IFormFile? Cover { get; set; } = default!;

        public string GameWebsite { get; set; } = default!;
    }
}
