using System.Text.RegularExpressions;

namespace SharpExtensions
{
    public static class StringExtensions
    {
        public static string RemoveTags(this string content)
        {
            if (!string.IsNullOrWhiteSpace(content))
                return Regex.Replace(content, "<[^>]*>", string.Empty);

            return string.Empty;
        } 
    }
}