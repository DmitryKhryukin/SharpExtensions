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

            if (content.Length <= bound)
            {
                return content;
            }

            var stringBuilder = new StringBuilder();
           
            string firstPart = content.Substring(0, bound);
            string[] firstPartWords = firstPart.Split(' ');

            if (firstPartWords.Length == 1)
            {
                stringBuilder.Append(content);
            }
            else if (firstPartWords.Length == 2)
            {
                stringBuilder.Append(firstPartWords[0]);
            }
            else if (firstPartWords.Length > 2)
            {
                stringBuilder.Append(firstPartWords[0] + " ");

                for (var i = 1; i < firstPartWords.Length - 2; i++)
                    stringBuilder.Append(firstPartWords[i] + " ");

                stringBuilder.Append(firstPartWords[firstPartWords.Length - 2]);
            }

            var result = stringBuilder.ToString();

            var badEndSimbols = new char[] {' ', '.', ',', ':'};

            return string.Format("{0}{1}", result.TrimEnd(badEndSimbols), appendix); 
        }

        public static string Reverse(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}