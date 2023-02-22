using System.Linq;

namespace TimeTracking.Shared
{
    public static class StringExtensions
    {
        public enum ZeroesPosition { Left, Right }
        public static string AppendZeroes(this string value, int count, ZeroesPosition at = ZeroesPosition.Left) 
        {
            var rank = count - value.Length;
            var zeroes = Enumerable.Repeat('0', rank).ToArray();
            if (at == ZeroesPosition.Left && value.Length < count)
            {
                return $"{new string(zeroes)}{value}";
            }
            else if (at == ZeroesPosition.Right)
            {
                return $"{value}{new string(zeroes)}";
            }
            return value;
        }

        public static string ToStartsWithPattern(this string searchText)
        {
            return string.Concat(searchText.Replace("%", "[%]"), "%");
        }

        public static string ToContainsPattern(this string searchText)
        {
            return string.Concat("%", searchText.Replace("%", "[%]"), "%");
        }

        public static string ToEndsWithPattern(this string searchText)
        {
            return string.Concat("%", searchText.Replace("%", "[%]"));
        }
    }
}
