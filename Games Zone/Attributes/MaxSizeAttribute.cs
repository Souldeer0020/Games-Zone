namespace Games_Zone.Attributes
{
    public class MaxSizeAttribute : ValidationAttribute
    {
        private readonly int _maxSize;

        public MaxSizeAttribute(int maxSize)
        {
            _maxSize = maxSize;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file != null)
            {
                
                if (file.Length > _maxSize)
                {
                    return new ValidationResult($"Maximum allowed size is {_maxSize / 1000000} Mb");
                }

            }
            return ValidationResult.Success;

        }
    }
}
