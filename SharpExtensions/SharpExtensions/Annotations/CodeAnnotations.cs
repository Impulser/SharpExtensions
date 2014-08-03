﻿// ***********************************************************************
// Assembly         : SharpExtensions
// Source File      : CodeAnnotations.cs
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

#pragma warning disable 1591
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedParameter.Local
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable IntroduceOptionalParameters.Global
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable InconsistentNaming

namespace SharpExtensions.Annotations
{

    #region JetBrains Default Annotations
    /// <summary>
    ///     Indicates that the value of the marked element could be <c>null</c> sometimes, so the check for <c>null</c> is
    ///     necessary before its usage
    /// </summary>
    /// <example>
    ///     <code>
    /// [CanBeNull] public object Test() { return null; }
    /// public void UseTest() {
    /// var p = Test();
    /// var s = p.ToString(); // Warning: Possible 'System.NullReferenceException'
    /// }
    ///   </code>
    /// </example>
    [AttributeUsage(
        AttributeTargets.Method | AttributeTargets.Parameter |
        AttributeTargets.Property | AttributeTargets.Delegate |
        AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class CanBeNullAttribute : Attribute
    { }

    /// <summary>
    ///     Indicates that the value of the marked element could never be <c>null</c>
    /// </summary>
    /// <example>
    ///     <code>
    /// [NotNull] public object Foo() {
    /// return null; // Warning: Possible 'null' assignment
    /// }
    ///   </code>
    /// </example>
    [AttributeUsage(
        AttributeTargets.Method | AttributeTargets.Parameter |
        AttributeTargets.Property | AttributeTargets.Delegate |
        AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public sealed class NotNullAttribute : Attribute
    { }

    /// <summary>
    ///     Indicates that the marked method builds string by format pattern and (optional) arguments. Parameter, which
    ///     contains format string, should be given in constructor. The format string should be in
    ///     <see cref="string.Format(IFormatProvider,string,object[])" />-like form
    /// </summary>
    /// <example>
    ///     <code>
    /// [StringFormatMethod("message")]
    /// public void ShowError(string message, params object[] args) { /* do something */ }
    /// public void Foo() {
    /// ShowError("Failed: {0}"); // Warning: Non-existing argument in format string
    /// }
    ///   </code>
    /// </example>
    [AttributeUsage(
        AttributeTargets.Constructor | AttributeTargets.Method,
        AllowMultiple = false, Inherited = true)]
    public sealed class StringFormatMethodAttribute : Attribute
    {
        /// <summary>Initializes a new instance of the <see cref="StringFormatMethodAttribute" /> class.</summary>
        /// <param name="formatParameterName">Specifies which parameter of an annotated method should be treated as format-string</param>
        public StringFormatMethodAttribute(string formatParameterName)
        {
            FormatParameterName = formatParameterName;
        }

        /// <summary>Gets the name of the format parameter.</summary>
        /// <value>The name of the format parameter.</value>
        public string FormatParameterName { get; private set; }
    }

    /// <summary>
    ///     Indicates that the function argument should be string literal and match one of the parameters of the caller
    ///     function. For example, ReSharper annotates the parameter of <see cref="System.ArgumentNullException" />
    /// </summary>
    /// <example>
    ///     <code>
    /// public void Foo(string param) {
    /// if (param == null)
    /// throw new ArgumentNullException("par"); // Warning: Cannot resolve symbol
    /// }
    ///   </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public sealed class InvokerParameterNameAttribute : Attribute
    { }

    /// <summary>
    ///     Indicates that the method is contained in a type that implements
    ///     <see cref="System.ComponentModel.INotifyPropertyChanged" /> interface and this method is used to notify that some
    ///     property value changed
    /// </summary>
    /// <example>
    ///     <code>
    /// public class Foo : INotifyPropertyChanged {
    /// public event PropertyChangedEventHandler PropertyChanged;
    /// [NotifyPropertyChangedInvocator]
    /// protected virtual void NotifyChanged(string propertyName) { ... }
    /// private string _name;
    /// public string Name {
    /// get { return _name; }
    /// set { _name = value; NotifyChanged("LastName"); /* Warning */ }
    /// }
    /// }
    ///   </code>
    ///     Examples of generated notifications:
    ///     <list>
    ///         <item>
    ///             <c>NotifyChanged("Property")</c>
    ///         </item>
    ///         <item>
    ///             <c>NotifyChanged(() =&gt; Property)</c>
    ///         </item>
    ///         <item>
    ///             <c>NotifyChanged((VM x) =&gt; x.Property)</c>
    ///         </item>
    ///         <item>
    ///             <c>SetProperty(ref myField, value, "Property")</c>
    ///         </item>
    ///     </list>
    /// </example>
    /// <remarks>
    ///     The method should be non-static and conform to one of the supported signatures:
    ///     <list>
    ///         <item>
    ///             <c>NotifyChanged(string)</c>
    ///         </item>
    ///         <item>
    ///             <c>NotifyChanged(params string[])</c>
    ///         </item>
    ///         <item>
    ///             <c>NotifyChanged{T}(Expression{Func{T}})</c>
    ///         </item>
    ///         <item>
    ///             <c>NotifyChanged{T,U}(Expression{Func{T,U}})</c>
    ///         </item>
    ///         <item>
    ///             <c>SetProperty{T}(ref T, T, string)</c>
    ///         </item>
    ///     </list>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class NotifyPropertyChangedInvocatorAttribute : Attribute
    {
        /// <summary>Initializes a new instance of the <see cref="NotifyPropertyChangedInvocatorAttribute" /> class.</summary>
        public NotifyPropertyChangedInvocatorAttribute()
        { }

        /// <summary>Initializes a new instance of the <see cref="NotifyPropertyChangedInvocatorAttribute" /> class.</summary>
        /// <param name="parameterName">Name of the parameter.</param>
        public NotifyPropertyChangedInvocatorAttribute(string parameterName)
        {
            ParameterName = parameterName;
        }

        /// <summary>Gets the name of the parameter.</summary>
        /// <value>The name of the parameter.</value>
        public string ParameterName { get; private set; }
    }

    /// <summary>Describes dependency between method input and output</summary>
    /// <syntax>
    ///     <p>Function Definition Table syntax:</p>
    ///     <list>
    ///         <item>FDT      ::= FDTRow [;FDTRow]*</item>
    ///         <item>FDTRow   ::= Input =&gt; Output | Output &lt;= Input</item>
    ///         <item>Input    ::= ParameterName: Value [, Input]*</item>
    ///         <item>Output   ::= [ParameterName: Value]* {halt|stop|void|nothing|Value}</item>
    ///         <item>Value    ::= true | false | null | notnull | canbenull</item>
    ///     </list>
    ///     If method has single input parameter, it's name could be omitted.<br />
    ///     Using <c>halt</c> (or <c>void</c>/<c>nothing</c>, which is the same) for method output means that the methos
    ///     doesn't return normally.<br />
    ///     <c>canbenull</c> annotation is only applicable for output parameters.<br />
    ///     You can use multiple <c>[ContractAnnotation]</c> for each FDT row, or use single attribute with rows separated by
    ///     semicolon.<br />
    /// </syntax>
    /// <examples>
    ///     <list>
    ///         <item>
    ///             <code>
    /// [ContractAnnotation("=&gt; halt")]
    /// public void TerminationMethod()
    ///   </code>
    ///         </item>
    ///         <item>
    ///             <code>
    /// [ContractAnnotation("halt &lt;= condition: false")]
    /// public void Assert(bool condition, string text) // regular assertion method
    ///   </code>
    ///         </item>
    ///         <item>
    ///             <code>
    /// [ContractAnnotation("s:null =&gt; true")]
    /// public bool IsNullOrEmpty(string s) // string.IsNullOrEmpty()
    ///   </code>
    ///         </item>
    ///         <item>
    ///             <code>
    /// [ContractAnnotation("null =&gt; null; notnull =&gt; notnull")]
    /// public object Transform(object data)
    ///   </code>
    ///         </item>
    ///         <item>
    ///             <code>
    /// [ContractAnnotation("s:null=&gt;false; =&gt;true,result:notnull; =&gt;false, result:null")]
    /// public bool TryParse(string s, out Person result)
    ///   </code>
    ///         </item>
    ///     </list>
    /// </examples>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public sealed class ContractAnnotationAttribute : Attribute
    {
        /// <summary>Initializes a new instance of the <see cref="ContractAnnotationAttribute" /> class.</summary>
        /// <param name="contract">The contract.</param>
        public ContractAnnotationAttribute([NotNull] string contract)
            : this(contract, false)
        { }

        /// <summary>Initializes a new instance of the <see cref="ContractAnnotationAttribute" /> class.</summary>
        /// <param name="contract">The contract.</param>
        /// <param name="forceFullStates">if set to <c>true</c> [force full states].</param>
        public ContractAnnotationAttribute([NotNull] string contract, bool forceFullStates)
        {
            Contract = contract;
            ForceFullStates = forceFullStates;
        }

        /// <summary>Gets the contract.</summary>
        /// <value>The contract.</value>
        public string Contract { get; private set; }

        /// <summary>Gets a value indicating whether [force full states].</summary>
        /// <value><c>true</c> if [force full states]; otherwise, <c>false</c>.</value>
        public bool ForceFullStates { get; private set; }
    }

    /// <summary>Indicates that marked element should be localized or not</summary>
    /// <example>
    ///     <code>
    /// [LocalizationRequiredAttribute(true)]
    /// public class Foo {
    /// private string str = "my string"; // Warning: Localizable string
    /// }
    ///   </code>
    /// </example>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public sealed class LocalizationRequiredAttribute : Attribute
    {
        /// <summary>Initializes a new instance of the <see cref="LocalizationRequiredAttribute" /> class.</summary>
        public LocalizationRequiredAttribute()
            : this(true)
        { }

        /// <summary>Initializes a new instance of the <see cref="LocalizationRequiredAttribute" /> class.</summary>
        /// <param name="required">if set to <c>true</c> [required].</param>
        public LocalizationRequiredAttribute(bool required)
        {
            Required = required;
        }

        /// <summary>Gets a value indicating whether this <see cref="LocalizationRequiredAttribute" /> is required.</summary>
        /// <value><c>true</c> if required; otherwise, <c>false</c>.</value>
        public bool Required { get; private set; }
    }

    /// <summary>
    ///     Indicates that the value of the marked type (or its derivatives) cannot be compared using '==' or '!='
    ///     operators and <c>Equals()</c>
    ///     should be used instead. However, using '==' or '!=' for comparison with <c>null</c> is always permitted.
    /// </summary>
    /// <example>
    ///     <code>
    /// [CannotApplyEqualityOperator]
    /// class NoEquality { }
    /// class UsesNoEquality {
    /// public void Test() {
    /// var ca1 = new NoEquality();
    /// var ca2 = new NoEquality();
    /// if (ca1 != null) { // OK
    /// bool condition = ca1 == ca2; // Warning
    /// }
    /// }
    /// }
    ///   </code>
    /// </example>
    [AttributeUsage(
        AttributeTargets.Interface | AttributeTargets.Class |
        AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
    public sealed class CannotApplyEqualityOperatorAttribute : Attribute
    { }

    /// <summary>
    ///     When applied to a target attribute, specifies a requirement for any type marked with the target attribute to
    ///     implement or inherit specific type or types.
    /// </summary>
    /// <example>
    ///     <code>
    /// [BaseTypeRequired(typeof(IComponent)] // Specify requirement
    /// public class ComponentAttribute : Attribute { }
    /// [Component] // ComponentAttribute requires implementing IComponent interface
    /// public class MyComponent : IComponent { }
    ///   </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true), BaseTypeRequired(typeof(Attribute))]
    public sealed class BaseTypeRequiredAttribute : Attribute
    {
        /// <summary>Initializes a new instance of the <see cref="BaseTypeRequiredAttribute" /> class.</summary>
        /// <param name="baseType">Type of the base.</param>
        public BaseTypeRequiredAttribute([NotNull] Type baseType)
        {
            BaseType = baseType;
        }

        /// <summary>Gets the type of the base.</summary>
        /// <value>The type of the base.</value>
        [NotNull]
        public Type BaseType { get; private set; }
    }

    /// <summary>
    ///     Indicates that the marked symbol is used implicitly (e.g. via reflection, in external library), so this symbol
    ///     will not be marked as unused (as well as by other usage inspections)
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public sealed class UsedImplicitlyAttribute : Attribute
    {
        /// <summary>Initializes a new instance of the <see cref="UsedImplicitlyAttribute" /> class.</summary>
        public UsedImplicitlyAttribute()
            : this(ImplicitUseKindFlags.Default, ImplicitUseTargetFlags.Default)
        { }

        /// <summary>Initializes a new instance of the <see cref="UsedImplicitlyAttribute" /> class.</summary>
        /// <param name="useKindFlags">The use kind flags.</param>
        public UsedImplicitlyAttribute(ImplicitUseKindFlags useKindFlags)
            : this(useKindFlags, ImplicitUseTargetFlags.Default)
        { }

        /// <summary>Initializes a new instance of the <see cref="UsedImplicitlyAttribute" /> class.</summary>
        /// <param name="targetFlags">The target flags.</param>
        public UsedImplicitlyAttribute(ImplicitUseTargetFlags targetFlags)
            : this(ImplicitUseKindFlags.Default, targetFlags)
        { }

        /// <summary>Initializes a new instance of the <see cref="UsedImplicitlyAttribute" /> class.</summary>
        /// <param name="useKindFlags">The use kind flags.</param>
        /// <param name="targetFlags">The target flags.</param>
        public UsedImplicitlyAttribute(
            ImplicitUseKindFlags useKindFlags,
            ImplicitUseTargetFlags targetFlags)
        {
            UseKindFlags = useKindFlags;
            TargetFlags = targetFlags;
        }

        /// <summary>Gets the use kind flags.</summary>
        /// <value>The use kind flags.</value>
        public ImplicitUseKindFlags UseKindFlags { get; private set; }

        /// <summary>Gets the target flags.</summary>
        /// <value>The target flags.</value>
        public ImplicitUseTargetFlags TargetFlags { get; private set; }
    }

    /// <summary>
    ///     Should be used on attributes and causes ReSharper to not mark symbols marked with such attributes as unused
    ///     (as well as by other usage inspections)
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class MeansImplicitUseAttribute : Attribute
    {
        /// <summary>Initializes a new instance of the <see cref="MeansImplicitUseAttribute" /> class.</summary>
        public MeansImplicitUseAttribute()
            : this(ImplicitUseKindFlags.Default, ImplicitUseTargetFlags.Default)
        { }

        /// <summary>Initializes a new instance of the <see cref="MeansImplicitUseAttribute" /> class.</summary>
        /// <param name="useKindFlags">The use kind flags.</param>
        public MeansImplicitUseAttribute(ImplicitUseKindFlags useKindFlags)
            : this(useKindFlags, ImplicitUseTargetFlags.Default)
        { }

        /// <summary>Initializes a new instance of the <see cref="MeansImplicitUseAttribute" /> class.</summary>
        /// <param name="targetFlags">The target flags.</param>
        public MeansImplicitUseAttribute(ImplicitUseTargetFlags targetFlags)
            : this(ImplicitUseKindFlags.Default, targetFlags)
        { }

        /// <summary>Initializes a new instance of the <see cref="MeansImplicitUseAttribute" /> class.</summary>
        /// <param name="useKindFlags">The use kind flags.</param>
        /// <param name="targetFlags">The target flags.</param>
        public MeansImplicitUseAttribute(
            ImplicitUseKindFlags useKindFlags,
            ImplicitUseTargetFlags targetFlags)
        {
            UseKindFlags = useKindFlags;
            TargetFlags = targetFlags;
        }

        /// <summary>Gets the use kind flags.</summary>
        /// <value>The use kind flags.</value>
        [UsedImplicitly]
        public ImplicitUseKindFlags UseKindFlags { get; private set; }

        /// <summary>Gets the target flags.</summary>
        /// <value>The target flags.</value>
        [UsedImplicitly]
        public ImplicitUseTargetFlags TargetFlags { get; private set; }
    }

    /// <summary>Enum ImplicitUseKindFlags</summary>
    [Flags]
    public enum ImplicitUseKindFlags
    {
        /// <summary>The default</summary>
        Default = Access | Assign | InstantiatedWithFixedConstructorSignature,

        /// <summary>Only entity marked with attribute considered used</summary>
        Access = 1,

        /// <summary>Indicates implicit assignment to a member</summary>
        Assign = 2,

        /// <summary>
        ///     Indicates implicit instantiation of a type with fixed constructor signature. That means any unused constructor
        ///     parameters won't be reported as such.
        /// </summary>
        InstantiatedWithFixedConstructorSignature = 4,

        /// <summary>Indicates implicit instantiation of a type</summary>
        InstantiatedNoFixedConstructorSignature = 8,
    }

    /// <summary>
    ///     Specify what is considered used implicitly when marked with <see cref="MeansImplicitUseAttribute" />
    ///     or <see cref="UsedImplicitlyAttribute" />
    /// </summary>
    [Flags]
    public enum ImplicitUseTargetFlags
    {
        /// <summary>The default</summary>
        Default = Itself,

        /// <summary>The itself</summary>
        Itself = 1,

        /// <summary>Members of entity marked with attribute are considered used</summary>
        Members = 2,

        /// <summary>Entity marked with attribute and all its members considered used</summary>
        WithMembers = Itself | Members
    }

    /// <summary>
    ///     This attribute is intended to mark publicly available API which should not be removed and so is treated as
    ///     used
    /// </summary>
    [MeansImplicitUse]
    public sealed class PublicAPIAttribute : Attribute
    {
        /// <summary>Initializes a new instance of the <see cref="PublicAPIAttribute" /> class.</summary>
        public PublicAPIAttribute()
        { }

        /// <summary>Initializes a new instance of the <see cref="PublicAPIAttribute" /> class.</summary>
        /// <param name="comment">The comment.</param>
        public PublicAPIAttribute([NotNull] string comment)
        {
            Comment = comment;
        }

        /// <summary>Gets the comment.</summary>
        /// <value>The comment.</value>
        [NotNull]
        public string Comment { get; private set; }
    }

    /// <summary>
    ///     Tells code analysis engine if the parameter is completely handled when the invoked method is on stack. If the
    ///     parameter is a delegate, indicates that delegate is executed while the method is executed. If the parameter is an
    ///     enumerable, indicates that it is enumerated while the method is executed
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, Inherited = true)]
    public sealed class InstantHandleAttribute : Attribute
    { }

    /// <summary>
    ///     Indicates that a method does not make any observable state changes. The same as
    ///     <c>System.Diagnostics.Contracts.PureAttribute</c>
    /// </summary>
    /// <example>
    ///     <code>
    /// [Pure] private int Multiply(int x, int y) { return x * y; }
    /// public void Foo() {
    /// const int a = 2, b = 2;
    /// Multiply(a, b); // Waring: Return value of pure method is not used
    /// }
    ///   </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public sealed class PureAttribute : Attribute
    { }
    #endregion

    /// <summary>Indicates that the author believes that accessing the method or property to be thread-safe.</summary>
    /// <example>
    ///     <code>
    /// public class ThreadSafeExample
    /// {
    ///     private int counter;
    /// 
    ///     private object lockMutex = new object();
    /// 
    ///     [ThreadSafe]
    ///     public void Increment(int value)
    ///     {
    ///         lock (lockMutex)
    ///         {
    ///             counter += value;
    ///         }
    ///     }
    /// 
    ///     public static void TestThreadSafe()
    ///     {
    ///         var instance = new ThreadSafeExample();
    ///         Parallel.For(0, 100, index => instance.Increment(index));
    ///     }
    /// }
    ///   </code>
    /// </example>
    [AttributeUsage(
        AttributeTargets.Method | AttributeTargets.Property,
        AllowMultiple = false, Inherited = true)]
    public sealed class ThreadSafeAttribute : Attribute
    { }
}
