using System;
using System.Globalization;
using System.Windows.Controls;

namespace APIPostsViewer
{
    /// <summary>
    /// URL validation rule
    /// </summary>
    public class UrlValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string url = value.ToString();

            if (string.IsNullOrEmpty(url))
                return new ValidationResult(false, "API URL cannot be empty.");

            if (!Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                return new ValidationResult(false, "API URL is invalid, it should be valid http/https URL.");

            return new ValidationResult(true, null);
        }
    }

    /// <summary>
    /// Grid dimensions validation rule
    /// </summary>
    public class GridValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!int.TryParse(value.ToString(), out int val))
                return new ValidationResult(false, "Grid dimension must be an integer value.");

            if (val <= 0 || val > 50)
                return new ValidationResult(false, "Grid dimension must be between 1 and 50.");

            return new ValidationResult(true, null);
        }
    }
}