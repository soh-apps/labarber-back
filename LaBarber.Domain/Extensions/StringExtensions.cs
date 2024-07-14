using System.Text.RegularExpressions;

namespace LaBarber.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string OnlyNumbers(this string value)
        {
            return Regex.Replace(value, @"[^\d]", "");
        }

        public static string FormatPhone(this string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;

            string cleanValue = value.OnlyNumbers();
            if (cleanValue.Length == 10)
                return Convert.ToInt64(cleanValue).ToString("(##)####-####");

            return value;
        }

        public static string FormatCellphone(this string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;

            string cleanValue = value.OnlyNumbers();
            if (cleanValue.Length == 11)
                return Convert.ToInt64(cleanValue).ToString("(##)#####-####");

            return value;
        }
    }
}
