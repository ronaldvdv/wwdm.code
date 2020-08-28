using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace System
{
    public static class StringExtensions
    {
        public static Dictionary<char, char> _map = new Dictionary<char, char>
        {
            { ' ', '-' },
            { '_', '-' },
            { ':', '-' },
            { ';', '-' },
            { ',', '-' },

            { 'ë', 'e' },
            { 'è', 'e' },
            { 'é', 'e' },

            { 'ä', 'a' },
            { 'á', 'a' },
            { 'à', 'a' },

            { 'ö', 'o' },
            { 'ó', 'o' },
            { 'ò', 'o' },

            { 'ï', 'i' },
            { 'í', 'i' },
            { 'ì', 'i' },

            { 'ü', 'u' },
            { 'ú', 'u' },
            { 'ù', 'u' },

            { 'ç', 'c' },
        };

        public static TimeSpan ParseTime(this string value, char separator = ':')
        {
            var parts = value.Split(separator);
            var numbers = parts.Select(int.Parse).ToArray();
            int n = numbers.Length;
            int h = n >= 3 ? numbers[n - 3] : 0;
            int m = n >= 2 ? numbers[n - 2] : 0;
            int s = numbers[n - 1];
            while (m >= 60)
            {
                h++;
                m -= 60;
            }
            return new TimeSpan(h, m, s);
        }

        public static string Slugify(this string str)
        {
            var len = str.Length;
            var result = new char[len];
            str.ToLowerInvariant().CopyTo(0, result, 0, len);
            for (int i = 0; i < len; i++)
            {
                if (_map.TryGetValue(str[i], out var c))
                    result[i] = c;
            }
            return new string(result).Replace("--", "-");
        }

        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }

            var startUnderscores = Regex.Match(input, @"^_+");
            return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }
    }
}