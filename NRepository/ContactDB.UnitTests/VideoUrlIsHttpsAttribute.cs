using System.ComponentModel.DataAnnotations;

namespace ContactDB.UnitTests
{
    public class VideoUrlIsHttpsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            var videoUrl = value.ToString();

            return videoUrl.ToLower().StartsWith("https");
        }

        public override string FormatErrorMessage(string name)
        {
            return $"'{name}' is not a secure url.";
        }
    }
}
