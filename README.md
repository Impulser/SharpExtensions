SharpExtensions
=========

SharpExtensions is a Utility library that provides a big mess of useful extension functions and other goodies.


Version
--

1.0

Notes about Dependencies
--

SharpExtensions is designed to be distributed with little to no dependencies on other libraries.
However, [Jet Brains' Code Annotations] are used, but have been included in the SharpExtensions source.

A Small Example
--
An extension method for the _string_ type which allows invocation on a string literal.
```cs
// Implemenetation
[Pure, NotNull, StringFormatMethod("format")]
public static string Build([NotNull] this string format, params object[] arguments)
{
    if (format == null || arguments == null)
    {
        throw new ArgumentNullException(format == null ? "format" : "arguments");
    }
    return arguments.Length > 0 ? string.Format(format, arguments) : format;
}

// Usage
public static int MultiplyAndPrint(int a, int b)
{
    var result = a * b;
    var message = "{0} x {1} = {2}".Build(a, b, result);
    Console.WriteLine(message);
    return result;
}

var ten = MultiplyAndPrint(2, 5); 
// Output: "2 x 5 = 10"
```

[Jet Brains' Code Annotations]:http://www.jetbrains.com/resharper/webhelp/Reference__Options__Code_Inspection__Code_Annotations.html
