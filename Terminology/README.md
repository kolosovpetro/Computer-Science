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
	
		int i = 123;
		object o = i;  	   // `object` – is reference type, `int` - is value type, so here is boxing done
		int j = (int)o;    // here we unbox `o`, eg. convert `object` (reference) to `int` (value).
