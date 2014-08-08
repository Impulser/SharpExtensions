using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpExtensions.Extensions.String
{
    public static partial class StringExtensions
    {
        /// <summary>
        ///     Converts the string representation of a number to its primitive equivalent. A return value indicates whether the
        ///     conversion succeeded or failed.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="number">The number.</param>
        /// <returns><c>true</c> if <paramref name="text" /> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseByte(this string text, out byte number)
        {
            return byte.TryParse(text, out number);
        }

        /// <summary>
        ///     Converts the string representation of a number in a specified style and culture-specific format to its
        ///     primitive equivalent.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>
        ///     A primitive equivalent to the numeric value or symbol specified in
        ///     <paramref name="text" />.
        /// </returns>
        public static byte ParseByte(this string text)
        {
            return byte.Parse(text);
        }

        /// <summary>
        ///     Converts the string representation of a number to its primitive equivalent. A return value indicates whether the
        ///     conversion succeeded or failed.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="number">The number.</param>
        /// <returns><c>true</c> if <paramref name="text" /> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseInt(this string text, out int number)
        {
            return int.TryParse(text, out number);
        }

        /// <summary>
        ///     Converts the string representation of a number in a specified style and culture-specific format to its
        ///     primitive equivalent.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>
        ///     A primitive equivalent to the numeric value or symbol specified in
        ///     <paramref name="text" />.
        /// </returns>
        public static int ParseInt(this string text)
        {
            return int.Parse(text);
        }

        /// <summary>
        ///     Converts the string representation of a number to its primitive equivalent. A return value indicates whether the
        ///     conversion succeeded or failed.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="number">The number.</param>
        /// <returns><c>true</c> if <paramref name="text" /> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseShort(this string text, out short number)
        {
            return short.TryParse(text, out number);
        }

        /// <summary>
        ///     Converts the string representation of a number in a specified style and culture-specific format to its
        ///     primitive equivalent.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>
        ///     A primitive equivalent to the numeric value or symbol specified in
        ///     <paramref name="text" />.
        /// </returns>
        public static short ParseShort(this string text)
        {
            return short.Parse(text);
        }

        /// <summary>
        ///     Converts the string representation of a number to its primitive equivalent. A return value indicates whether the
        ///     conversion succeeded or failed.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="number">The number.</param>
        /// <returns><c>true</c> if <paramref name="text" /> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseLong(this string text, out long number)
        {
            return long.TryParse(text, out number);
        }

        /// <summary>
        ///     Converts the string representation of a number in a specified style and culture-specific format to its
        ///     primitive equivalent.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>
        ///     A primitive equivalent to the numeric value or symbol specified in
        ///     <paramref name="text" />.
        /// </returns>
        public static long ParseLong(this string text)
        {
            return long.Parse(text);
        }

        /// <summary>
        ///     Converts the string representation of a number to its primitive equivalent. A return value indicates whether the
        ///     conversion succeeded or failed.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="number">The number.</param>
        /// <returns><c>true</c> if <paramref name="text" /> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseFloat(this string text, out float number)
        {
            return float.TryParse(text, out number);
        }

        /// <summary>
        ///     Converts the string representation of a number in a specified style and culture-specific format to its
        ///     primitive equivalent.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>
        ///     A primitive equivalent to the numeric value or symbol specified in
        ///     <paramref name="text" />.
        /// </returns>
        public static float ParseFloat(this string text)
        {
            return float.Parse(text);
        }

        /// <summary>
        ///     Converts the string representation of a number to its primitive equivalent. A return value indicates whether the
        ///     conversion succeeded or failed.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="number">The number.</param>
        /// <returns><c>true</c> if <paramref name="text" /> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseDouble(this string text, out double number)
        {
            return double.TryParse(text, out number);
        }

        /// <summary>
        ///     Converts the string representation of a number in a specified style and culture-specific format to its
        ///     primitive equivalent.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>
        ///     A primitive equivalent to the numeric value or symbol specified in
        ///     <paramref name="text" />.
        /// </returns>
        public static double ParseDouble(this string text)
        {
            return double.Parse(text);
        }

        /// <summary>
        ///     Converts the string representation of a number to its primitive equivalent. A return value indicates whether the
        ///     conversion succeeded or failed.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="number">The number.</param>
        /// <returns><c>true</c> if <paramref name="text" /> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseBool(this string text, out bool number)
        {
            return bool.TryParse(text, out number);
        }

        /// <summary>
        ///     Converts the string representation of a number in a specified style and culture-specific format to its
        ///     primitive equivalent.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>
        ///     A primitive equivalent to the numeric value or symbol specified in
        ///     <paramref name="text" />.
        /// </returns>
        public static bool ParseBool(this string text)
        {
            return bool.Parse(text);
        }

        /// <summary>
        ///     Converts the string representation of a number to its primitive equivalent. A return value indicates whether the
        ///     conversion succeeded or failed.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="number">The number.</param>
        /// <returns><c>true</c> if <paramref name="text" /> was converted successfully; otherwise, <c>false</c>.</returns>
        public static bool TryParseDecimal(this string text, out decimal number)
        {
            return decimal.TryParse(text, out number);
        }

        /// <summary>
        ///     Converts the string representation of a number in a specified style and culture-specific format to its
        ///     primitive equivalent.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>
        ///     A primitive equivalent to the numeric value or symbol specified in
        ///     <paramref name="text" />.
        /// </returns>
        public static decimal ParseDecimal(this string text)
        {
            return decimal.Parse(text);
        }

    }
}
