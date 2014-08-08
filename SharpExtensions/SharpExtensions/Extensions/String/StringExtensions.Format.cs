// ***********************************************************************
// Assembly         : SharpExtensions
// Source File      : StringExtensions.cs
//
// Author           : Impulser
// Created On       : 02/08/2014
//
// Last Modified By : Impulser
// Last Modified On : 02/08/2014
// ***********************************************************************
// ISC License - Use is subject to license terms.
// ***********************************************************************

using System.Linq;

using SharpExtensions.Annotations;

namespace SharpExtensions.Extensions.String
{
    /// <summary>
    ///     Provides Extensions to the string type.
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        ///     Replaces the format item in a specified string with the string representation of a corresponding object in a
        ///     specified array.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arguments">An object array that contains zero or more objects to format.</param>
        /// <returns>
        ///     A copy of <paramref name="format" /> in which the format items have been replaced by the string representation
        ///     of the corresponding objects in <paramref name="arguments" />.
        /// </returns>
        [StringFormatMethod("format")]
        public static string Build([NotNull] this string format, params object[] arguments)
        {
            return string.Format(format, arguments);
        }
    }
}
