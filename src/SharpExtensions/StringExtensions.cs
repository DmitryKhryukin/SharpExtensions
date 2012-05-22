using System;
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

        public static string CutContent(this string content, int bound, string appendix = "")
        {
            if(bound < 0)
                throw new ArgumentException("Bound should be positive");

            if (string.IsNullOrEmpty(content))
                return string.Empty;

            return content;
        }


    }
}