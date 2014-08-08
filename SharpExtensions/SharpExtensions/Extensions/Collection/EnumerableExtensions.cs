// ***********************************************************************
// Assembly         : SharpExtensions
// Source File      : EnumerableExtensions.cs
//
// Author           : Impulser
// Created On       : 08/08/2014
//
// Last Modified By : Impulser
// Last Modified On : 08/08/2014
// ***********************************************************************
// ISC License - Use is subject to license terms.
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpExtensions.Extensions.Object;

namespace SharpExtensions.Extensions.Collection
{
    /// <summary>
    /// Class EnumerableExtensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        public static ICollection<TElement> AsCollection<TElement>(this IEnumerable<TElement> enumerable)
        {
            return enumerable.As<ICollection<TElement>>() ?? enumerable.ToArray();
        } 
    }
}
