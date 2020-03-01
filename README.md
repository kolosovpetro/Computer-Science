Learning C# (Basics, Algorithms, Design Patterns, Data Structures)
=====================================================================

Solutions to assignments at
* Introduction to computer programming
  * Lectures: https://kolosovpetro.github.io/computer_science/intro_to_comp_programm/
  * Practice: https://kolosovpetro.github.io/computer_science/intro_to_comp_programm/exercises/
* Data structures and algorithms
  * Lectures: https://kolosovpetro.github.io/computer_science/data_structures_and_algorithms
  * Practice: https://kolosovpetro.github.io/computer_science/data_structures_and_algorithms/exercises/
* Object oriented programming
  * Lectures: https://kolosovpetro.github.io/computer_science/object_oriented_programming
  * Practice: https://kolosovpetro.github.io/computer_science/object_oriented_programming/exercises/
* Computational methods
  * Lectures https://kolosovpetro.github.io/computer_science/comp_methods
  * Practice https://kolosovpetro.github.io/computer_science/comp_methods/exercises/

Introduction to computer programming
------------------------------------

* Assignments 1 (Read input from keyboard, casting variables, elementary loops)
* Assignments 2 (Proper input verification, conditional statements [if, switch], ternary operator, sorting network)
* Assignments 3 (Enums, string to enum parse, menu using enum, switch statement, stringbuilder, random)
* Assignments 4 (Arrays, bubble sort, sieve of eratosthenes, tic-tac-toe console game)
* Assignments 5 (Structs, reccursive functions, tic-tac-toc class segragation)
* Assignments 5 Library (Creating of class libraries, make reference to them in entry point project and execute)
* Assignments 6 (Writing to files, nested loops, reading from files, date-time, creating folders, string split, string contains)
* Assignments 7 (NUnit tests, documentation, custom exceptions, set float number accuracy)

Object oriented programming
---------------------------

* OOP1 (Encapsulation, getters, setters, access modifiers)
* OOP2 (Constructors, constructor flow, notes on final fields, notes on static fields and methods)
* OOP3 (Inheritance, overriding, super, polymorphism, upcast)
* OOP4 (Interfaces, implementations)

Design patterns
---------------
* Creational
  * Factory Method (Extends functionality of program)
  * Builder (Avoiding huge number of parameters withing object's consturctor. Combination of parameters.)
* Structural
* Behavioral

Data structures
---------------

This folder currently consists the `Data Structures` as follows:

* Dictionary
* Graph
* Heap
* LinkedList
* Queue
* Stack
* Tree

**Future Implementations**

In future, it is planned to implement the `Data Structures` as follows:

* Weighted Graph (in progress)
* Priority Queue
* Generic List

**What's used**

* NUnit Framework
* Generics
* Indexers
* IEnumerable interface implementation

To verify the correctness of implementation the `NUnit` test package is used.

Algorithms
----------
* Search Algorithms (and their benchmark measurement)
  * Linear Searches
  * Binary Search
* Sort Algorithms

Computational methods
---------------------


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


