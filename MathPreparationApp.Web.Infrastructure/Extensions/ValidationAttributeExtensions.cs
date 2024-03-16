namespace MathPreparationApp.Web.Infrastructure.Extensions
{
    using System.ComponentModel.DataAnnotations;
    using static Common.GeneralApplicationConstants;

    public static class ValidationAttributeExtensions
    {
        public class ImageMaxSizeAttribute : ValidationAttribute
        {
            public ImageMaxSizeAttribute()
            {
                ErrorMessage = $"The field {{0}} must be a byte array with a maximum length of {ImageBytesMaxValue} bytes.";
            }

            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                if (value is byte[] bytes && bytes.Length > ImageBytesMaxValue)
                {
                    return new ValidationResult(string.Format(ErrorMessage = null!, validationContext.DisplayName));
                }

                return ValidationResult.Success;
            }
        }
    }
}
