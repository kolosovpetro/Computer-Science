Learning C# (Basics, Algorithms, Design Patterns, Data Structures)
==================================================================

> *"I am not afraid of a person who knows 10000 kicks. But I am afraid of a person who knows one kick but practices it for 10000 times." - Bruce Lee*

* Introduction to Computer Programming
  * Lectures: https://kolosovpetro.github.io/computer_science/intro_to_comp_programm/
  * Practice: https://kolosovpetro.github.io/computer_science/intro_to_comp_programm/exercises/
* Data Structures and Algorithms
  * Lectures: https://kolosovpetro.github.io/computer_science/data_structures_and_algorithms
  * Practice: https://kolosovpetro.github.io/computer_science/data_structures_and_algorithms/exercises/
* Object Oriented Programming
  * Lectures: https://kolosovpetro.github.io/computer_science/object_oriented_programming
  * Practice: https://kolosovpetro.github.io/computer_science/object_oriented_programming/exercises/
* Computational Methods
  * Lectures https://kolosovpetro.github.io/computer_science/comp_methods
  * Practice https://kolosovpetro.github.io/computer_science/comp_methods/exercises/

Introduction to Computer Programming
------------------------------------
* Assignments 1 (Read input from keyboard, casting variables, elementary loops)
* Assignments 2 (Proper input verification, conditional statements [if, switch, ternary operator], sorting network)
* Assignments 3 (Enums, string to enum parse, menu using enum, switch statement, stringbuilder, random)
* Assignments 4 (Arrays, bubble sort, sieve of eratosthenes, tic-tac-toe console game)
* Assignments 5 (Structs, reccursive functions, tic-tac-toc class segragation)
* Assignments 5 Library (Creating of class libraries, make reference to them in entry point project and execute)
* Assignments 6 (Writing to files, reading from files, nested loops, date-time, creating folders, value tuples)
* Assignments 7 (NUnit tests [exception test], documentation, custom exceptions)

Object Oriented Programming
---------------------------
* OOP1 (Encapsulation, getters, setters, access modifiers)
* OOP2 (Constructors, constructor flow, notes on final fields, notes on static fields and methods)
* OOP3 (Inheritance, overriding, super, polymorphism, upcast)
* OOP4 (Interfaces, implementations)
* Project (Hospital manegement application, WinForms). Contains all OOP techniques + binary serialization in use

Algorithms
----------
* Search Algorithms (and their benchmark measurement)
  * Linear Searches
  * Binary Search
* Sort Algorithms
  * Bubble sort O(n^2)
  * Cocktail sort (Buble 2 pass sort) O(n^2)
  * Counting sort O(n+k), k = non negative terms count
  * Insertion sort O(n)
  * Merge sort O(n*log(n))
  * Quick sort O(log(n))
  * Selection sort O(n^2)
* Coin Change Problem (Intro to Dynamic programming)
* RPN Calculator (postfix calculator based on stack data structure)

Data Structures
---------------
Implemented data structures as:

* Dictionary
* Graph
* Heap
* LinkedList
* Queue
* Stack
* Tree
* Weighted Graph

In future, it is planned to implement the `Data Structures` as follows:

* Priority Queue
* Generic List

What's used

* NUnit UnitTest Framework
* Generics
* Indexers
* IEnumerable interface implementation

Design Patterns
---------------
* Creational
  * Factory Method (Extends functionality of program)
  * Builder (Avoiding huge number of parameters withing object's consturctor. Combination of parameters.)
* Structural
* Behavioral

Computational Methods
---------------------
* Numerical Sys. converter (Pure example how to break all SOLID rules in 1 class, **DO NOT WRITE CODE THIS WAY**)
* System of linear equations solver
* Polynomial Interpolation (Vandermonde method)
* Discrete Integration (Simpson's, Trapezoidal methods)
* Monte Carlo Method (Estimation on the plan finishing time)

Misc
----
Other projects.

* Database Control Panel. Simple winforms app in order to perform SQL queries on PostgreSQL Database. Not protected from SQL injections. 
* LINQ. A set of custom methods in order to operate over IEnumerable collections.

Notes
-----
* Values vs Reference type: In oder to modify reference type (e.g `class`) via method it is enought to

		static void Modify(int[] a)
		{
			a[0] = 5;
		}
	
	However, in case of value types (e.g `structs`) method variable should be supplies with `ref` keyword in order to modify entire variable

		static void Modify(ref int a)
		{
			a = 5;
		}
	
* In order to work with class library, all its classes must have acessor `public`. E.g `public class1 { }`.
* Constant fields `const` are `static` and cannot be acessed using `this` reference.


