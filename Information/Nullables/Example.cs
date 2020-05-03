
            // Examination of an instance of a nullable value type

            int? a = 42;
            if (a is int valueOfA)
            {
                Console.WriteLine($"a is {valueOfA}");
            }
            else
            {
                Console.WriteLine("a does not have a value");
            }

            // Output:
            // a is 42

            int? b = 10;
            if (b.HasValue)
            {
                Console.WriteLine($"b is {b.Value}");
            }
            else
            {
                Console.WriteLine("b does not have a value");
            }
			
            // Output:
            // b is 10

            int? c = 7;
            if (c != null)
            {
                Console.WriteLine($"c is {c.Value}");
            }
            else
            {
                Console.WriteLine("c does not have a value");
            }
			
            // Output:
            // c is 7

            // Conversion from a nullable value type to an underlying type

            int? n = null;

            //int m1 = n;    // Doesn't compile
            int n2 = (int)n; // Compiles, but throws an exception if n is null