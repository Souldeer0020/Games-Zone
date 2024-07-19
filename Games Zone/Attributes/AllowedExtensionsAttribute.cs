namespace Games_Zone.Attributes
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string _allowedExtension;

        public AllowedExtensionsAttribute(string AllowedExtension)
        {
            _allowedExtension = AllowedExtension;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if(file != null)
            {
                var Extension = Path.GetExtension(file.FileName); // returns "Extension" of the file

                var isAllowed = _allowedExtension.Split(',').Contains(Extension,StringComparer.OrdinalIgnoreCase); // StringComparer.OrdinalIgnoreCase 3shan law gaylk el extension capital aw feh 7roof capital => yerag3 false

                if (!isAllowed)
                {
                    return new ValidationResult($"Only {_allowedExtension} are allowed");
                }

            }
            return ValidationResult.Success;

        }
    }
}
