// ***********************************************************************
// Assembly         : SharpExtensions
// Source File      : EnumerableUtilities.cs
//
// Author           : Impulser
// Created On       : 02/08/2014
//
// Last Modified By : Impulser
// Last Modified On : 02/08/2014
// ***********************************************************************
// ISC License - Use is subject to license terms.
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpExtensions.Utilities
{
    /// <summary>
    ///     Provides utility functions for enumerable sequences.
    /// </summary>
    public static class EnumerableUtilities
    {
        /// <summary>
        ///     Generates an <see cref="T:System.Collections.Generic.IEnumerable`1" /> sequence of <typeparamref name="TElement" />
        ///     by starting with the <paramref name="initial" /> value and applying the <paramref name="step" /> function to the
        ///     previous result.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements to generate.</typeparam>
        /// <param name="initial">The initial value.</param>
        /// <param name="step">The step function.</param>
        /// <returns>A generated enumerable sequence.</returns>
        public static IEnumerable<TElement> Generate<TElement>(TElement initial, Func<TElement, TElement> step)
        {
            while (true)
            {
                yield return initial;
                initial = step(initial);
            }
        }

        /// <summary>
        ///     Generates an <see cref="T:System.Collections.Generic.IEnumerable`1" /> sequence of <typeparamref name="TElement" />
        ///     by starting with the default value for the <typeparamref name="TElement" /> type and applying the
        ///     <paramref name="step" /> function to the previous result.
        /// </summary>
        /// <typeparam name="TElement">The type of the eleements to genenrate, must be a struct type so initial value is not null.</typeparam>
        /// <param name="step">The step function.</param>
        /// <returns>A generated enumerable sequence.</returns>
        public static IEnumerable<TElement> Generate<TElement>(Func<TElement, TElement> step)
            where TElement : struct
        {
            return Generate(default(TElement), step);
        }
    }
}
