using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts IEnumerable of string to a string separated by spaces
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ToSpaceSeparatedString(this IEnumerable<string> list)
        {
            if (list == null)
            {
                return string.Empty;
            }

            var sb = new StringBuilder(100);

            foreach (var element in list)
            {
                sb.Append(element + " ");
            }

            return sb.ToString().Trim();
        }

        /// <summary>
        /// Convert string separated by spaces to IEnumerable of string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static IEnumerable<string> FromSpaceSeparatedString(this string input)
        {
            input = input.Trim();
            return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        /// <summary>
        /// Checks if string is missing os lenght is greather than the value provided
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static bool IsMissingOrTooLong(this string value, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return true;
            }
            if (value.Length > maxLength)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the string has value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsPresent(this string value)
        {
            return !string.IsNullOrWhiteSpace(value) && !string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Ensure url starts with '/'
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string EnsureLeadingSlash(this string url)
        {
            if (url != null && !url.StartsWith("/"))
            {
                return "/" + url;
            }

            return url;
        }

        /// <summary>
        /// Ensure url ends with '/'
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string EnsureTrailingSlash(this string url)
        {
            if (url != null && !url.EndsWith("/"))
            {
                return url + "/";
            }

            return url;
        }

        /// <summary>
        /// Remove slash from the start of the string
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string RemoveLeadingSlash(this string url)
        {
            if (url != null && url.StartsWith("/"))
            {
                url = url.Substring(1);
            }

            return url;
        }

        /// <summary>
        /// Remvoe slash from the end of the string
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string RemoveTrailingSlash(this string url)
        {
            if (url != null && url.EndsWith("/"))
            {
                url = url.Substring(0, url.Length - 1);
            }

            return url;
        }
    }
}
