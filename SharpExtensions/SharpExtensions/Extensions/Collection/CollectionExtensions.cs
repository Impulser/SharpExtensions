// ***********************************************************************
// Assembly         : SharpExtensions
// Source File      : CollectionExtensions.cs
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

namespace SharpExtensions.Extensions.Collection
{
    /// <summary>
    ///     Provides Extensions to collection types.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        ///     Performs the specified <paramref name="action" /> on each element of the
        ///     <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <typeparam name="TElement">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="action">The action to perform.</param>
        public static void ForEach<TElement>(this ICollection<TElement> collection, Action<TElement> action)
        {
            foreach (var element in collection)
            {
                action(element);
            }
        }

        /// <summary>
        ///     Performs the specified <paramref name="action" /> on each element of the
        ///     <see cref="T:System.Collections.Generic.IList`1" />. Additionally passing the element's index in the
        ///     collection.
        /// </summary>
        /// <typeparam name="TElement">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="action">The action.</param>
        public static void ForEach<TElement>(this ICollection<TElement> collection, Action<int, TElement> action)
        {
            var index = -1;
            foreach (var element in collection)
            {
                checked { index++; }
                action(index, element);
            }
        }
    }
}
