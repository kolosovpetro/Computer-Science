## Nullables

Value types accepting `null`. Not to be confused with general value types like `int, double, bool` and other `structs`. In `C#` nullable struct is deonted as `T? variableName`. For example, `int? t = null` or `int? t = 20`. The purpose of nullable type is `memory optimization`. Operator `??` is null-coalescing operator.

See also https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types