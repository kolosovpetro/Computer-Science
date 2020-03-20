## Computer Science Terminology

- **Implicit declaration** - initialization of the variable of the implicit typization, eg. 
  - `var t = 10;` 
  - `var u = "string"`
  - `var v = new Instance()`
  
  Note that class members cannot be assigned using implicit declaration.
  
- **Explicit declataion** - initialization of the entity in explicit way, so its type is clearly seen, eg.
  - `int t = 10`
  - `string u = "string"`
  - `Instance v = new Instance()`
  
  Class members can be assigned only using explisit typization.

- **Boxing** - is convertation of `value` type to `reference` type.

- **Unboxing** - is convertation of `reference` type to `value` type. Inverse to Boxing.

- **Boxing-Unboxing Examples**

```cs	
int i = 123;
object o = i;	// object – is reference type, int - is value type, so here is boxing done
int j = (int)o;		// here we unbox object o, eg. convert object (reference) to int (value).
```

- **Operator ?** - is `ternary operator`. Short definition of switch case. Works as follows

```cs
var t = (condition) ? condition is true : condition is false

int x = 10;
int y = (x > 5) ? x : 10;	// assignes y = x, since x = 10 > 5.
```

- **Operator ??** - is `null-coalescing operator`. Not to be confused with ternaty operator. Works as follows

```cs
int? t = null;
		
int y = x ?? -1;		// if x is null - assignes -1 to y, else assignes y = x
```
		
- **Checked-Unchecked clause** - Opens a posibility to skip compiler's errors or force check. For example

```cs
unchecked
{
	int int1 = 2147483647 + 10;		// compiler - OK
}

	int int2 = 2147483647 + 10;		// compiler - Error
```
		
- **throw(ex) vs throw**

  - `throw(ex);` - clears all exception history, showing only the line where exception thrown.
  
  - `throw;` - keeps all exception history. More convenient to use `throw;`.
  
