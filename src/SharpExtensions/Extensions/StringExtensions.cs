using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SharpExtensions.Extensions
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

            var result = new StringBuilder();

            if (content.Length <= bound)
            {
                result.Append(content);
            }
            else
            {
                string firstPart = content.Substring(0, bound);
                string[] firstPartWords = firstPart.Split(' ');

                if (firstPartWords.Length == 1)
                {
                    result.Append(content);
                }
                else if (firstPartWords.Length == 2)
                {
                    result.Append(firstPartWords[0]);
                }
                else if (firstPartWords.Length > 2)
                {
                    result.Append(firstPartWords[0] + " ");

                    for (var i = 1; i < firstPartWords.Length - 2; i++)
                        result.Append(firstPartWords[i] + " ");

                    result.Append(firstPartWords[firstPartWords.Length - 2]);
                }

                result.Append(appendix);
            }

            return result.ToString();
        }


    }
}