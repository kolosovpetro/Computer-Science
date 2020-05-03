## Keywords in C#

### Access modifiers

- `public` - no restrictions on accessing public members.

- `internal` - members are accessible only within files in the same assembly (namespace).

- `protected` - member is accessible within its class and by derived class instances.

- `protected internal` - member is accessible from the current assembly (namespace) or from types that are derived from the containing class.

- `private protected` - member is accessible by types derived from the containing class, but only within its containing assembly (namespace).

- `private` - members are accessible only within the body of the class or the struct in which they are declared.

- `partial` - class modifier that allows to split definition of the class over namespace (one class can be split to multiple files). 

For example, following works:

```cs
partial class Partial { public void DoSmth(){} }

class Program 
{
	public static void Main(string[] args)
	{
		Partial p = new Partial();
		p.DoSmth();
		p.DoDifferent();
	}
}

partial class Partial { public void DoDifferent(){} }
```

### Overriding

- `virtual` - keyword is used to modify a method, property, indexer, or event declaration and allow for it to be overridden in a derived class.

- `override` - keyword is used to override base method in child class. Provided that base method contains `virtual` keyword in its definition.

- `operator` - keyword is used in order to override arithmetic or cast operators.

- `explicit` - explicit converter (or cast operator) of one struct or class to another. For example,

```cs
// Example of explicit casting.
float fNumber = 100.00f;
int iNumber = (int) fNumber;
```

- `implicit` - implicit converter (or cast operator) of one struct or class to another.

```cs
// Example of implicit casting.
byte bNumber = 10;
int iNumber = bNumber;
```

### Other keywords

- `lock` - guarantees that only one thread may access current block of code, other threads stored in a queue. Useage of `lock` is very performance costly.

```cs
object obj = new Instance();

lock
{
	obj.InstanceMethod();	// only one thread can access instance method
}
```
