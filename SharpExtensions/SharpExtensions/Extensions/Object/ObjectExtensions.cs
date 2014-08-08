// ***********************************************************************
// Assembly         : SharpExtensions
// Source File      : GenericExtensions.cs
//
// Author           : Impulser
// Created On       : 03/08/2014
//
// Last Modified By : Impulser
// Last Modified On : 03/08/2014
// ***********************************************************************
// ISC License - Use is subject to license terms.
// ***********************************************************************
using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace SharpExtensions.Extensions.Object
{
    /// <summary>
    /// Class ObjectExtensions.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Applies the specified object.
        /// </summary>
        /// <typeparam name="TType">The type of the t type.</typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="applyFunction">The apply function.</param>
        /// <returns>``0</returns>
        public static TType Apply<TType>(this TType obj, Func<TType, TType> applyFunction)
        {
            return applyFunction(obj);
        }

        /// <summary>
        /// Casts the specified object.
        /// </summary>
        /// <typeparam name="TNew">The type of the t new.</typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>``0</returns>
        public static TNew Cast<TNew>(this object obj)
        {
            return (TNew) obj;
        }

        /// <summary>
        /// Ases the specified object.
        /// </summary>
        /// <typeparam name="TNew">The type of the t new.</typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>``0</returns>
        public static TNew As<TNew>(this object obj)
            where TNew : class
        {
            return obj as TNew;
        }

        /// <summary>
        ///     Determines whether <paramref name="field" /> is null.
        /// </summary>
        /// <typeparam name="TType">The type of the field.</typeparam>
        /// <param name="field">The field to check.</param>
        /// <returns><c>true</c> if <paramref name="field" /> is equal to <c>null</c>, <c>false</c> otherwise</returns>
        public static bool IsNull<TType>(this TType field)
            where TType : class
        {
            return field == null;
        }

        /// <summary>
        ///     Determines whether <paramref name="field" /> is not null.
        /// </summary>
        /// <typeparam name="TType">The type of the field.</typeparam>
        /// <param name="field">The field to check.</param>
        /// <returns><c>true</c> if <paramref name="field" /> is not equal to <c>null</c>, <c>false</c> otherwise</returns>
        public static bool IsNotNull<TType>(this TType field)
            where TType : class
        {
            return field != null;
        }

        /// <summary>
        ///     Executes the <paramref name="action" /> delegate and returns its value if <paramref name="obj" /> is not null.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="action">The action to execute.</param>
        /// <returns>The result of <paramref name="action" /> or the default type for <typeparamref name="TResult" /></returns>
        public static TResult IfNotNull<TObject, TResult>(this TObject obj, Func<TObject, TResult> action)
        {
            return obj.Cast<object>().IsNotNull() ? action(obj) : default(TResult);
        }

        /// <summary>
        ///     Executes the <paramref name="action" /> delegate if <paramref name="obj" /> is not null.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="action">The action.</param>
        public static void IfNotNull<TObject>(this TObject obj, Action<TObject> action)
        {
            if (obj.Cast<object>().IsNull())
            {
                return;
            }
            action(obj);
        }

        /// <summary>
        ///     Gets the name of the object type.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>The type of the object.</returns>
        public static string GetTypeName(this object obj)
        {
            return obj.GetType().Name;
        }
    }
}
