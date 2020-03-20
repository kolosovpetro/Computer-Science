## Mutables and Immutables

- `Mutable` - is an object that can be changed. In other words `able to mute`.
- `Immutable` - is an object that cannot be changed. In other words - `readonly`.

In `C#` strings are reference type, however they are immutable as well. For example, the code

		string s = "Strings are immutuble";		// string is reference type
        string j = s;
        j += "some additional info"; 	// modify j and also modify s ?

        // Guess what will be printed to console ?

        Console.WriteLine(s);	// Strings are immutable
		
		// Approach like
		
		s[2] = 'c'; 	// will cause compiler error
		
		// however the action like
		
		s = s.Replace('t', 'c'); 	// will work, since new instance of string is created on behalf of s, and s is replaced by new string
		
In order to create `Immutable class` - assign all its members to be readonly, and proved a public getter property.