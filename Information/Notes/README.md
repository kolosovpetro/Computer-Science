## Notes

- Values vs Reference type: In oder to modify reference type (e.g `class`) via method it is enought to

```cs
static void Modify(int[] a)
{
	a[0] = 5;
}
```

However, in case of value types (e.g `structs`) method variable should be supplied with `ref` keyword in order to modify entire variable

```cs
static void Modify(ref int a)
{
	a = 5;
}
```
	
- In order to work with class library, all its classes must have acessor `public`. E.g `public class1 { }`.

- Constant fields `const` are `static` and cannot be acessed using `this` reference.

- `Single responsibility principle` can be threaten as partial case of `Interface segragation principle`, where current class implements only one interface.

- In case of useage of `Inherritance` it is **essentially** important to follow `Liskov Substitution Principle` in abstract design.

- One may ask why `C#` is provided by  implicit `var` while everything can be assigned to `object`.

  - `object` requires unboxing
  - `object` cannot show explicit type of entity
  - `var` is more performance costly
  - boxing of value types causing the storage in heap, which is memory unefficient

- Implicit and explicit `interface` implementation. Let be the following interface

```cs
interface InterfaceOne
{
    void InterfaceMethod();
}

interface InterfaceTwo
{
    void InterfaceMethod();
}
```

Following implementation is called `Implicit`

```cs
public class MyClass : InterfaceOne, InterfaceTwo
{
    public void InterfaceMethod()
    {
        Console.WriteLine("Угадай метод какого интерфейса вызван?");
    }
}
```

And another one is `Explicit`

```cs
public class MyClass : InterfaceOne, InterfaceTwo
{
    void InterfaceOne.InterfaceMethod()
    {
		Console.WriteLine("Interface 1 Implementation");
    }
	
    void InterfaceTwo.InterfaceMethod()
    {
		Console.WriteLine("Interface 2 Implementation");
    }
}
```

- `Convert` vs `Parse`.

Parse takes only input of type `string`, while Convert works on multiple input types.

