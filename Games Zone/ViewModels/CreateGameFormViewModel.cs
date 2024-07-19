

namespace Games_Zone.ViewModels
{
    public class CreateGameFormViewModel : BaseGameFormViewModel
    {

        //[MaxLength(500)]
        [AllowedExtensions(FileSettings.AllowedExtensions)]
        [MaxSizeAttribute(FileSettings.MaxFileSizeInBytes)]
        public IFormFile? Cover { get; set; } = default!;

        public string GameWebsite { get; set; }
    }
}
