using System.Linq;

namespace Automated_Office_Translation_Tool.Utils
{
    public static class Filters
    {
        public static bool IsBlankOrNonAlphabetic(string input)
        {
            // Check if the string is blank (null or empty)
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }

            // Check if the string contains any alphabetic character
            return !input.Any(char.IsLetter);
        }
    }
}