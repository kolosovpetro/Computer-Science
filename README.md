## Learning C# (Basics, Algorithms, Design Patterns, Data Structures, SOLID)

> *"I am not afraid of a person who knows 10000 kicks. But I am afraid of a person who knows one kick but practices it for 10000 times." - Bruce Lee*

## Contents

- [Introduction to Computer Programming](#introduction-to-computer-programming)
  - Lectures: https://kolosovpetro.github.io/computer_science/intro_to_comp_programm/
  - Practice: https://kolosovpetro.github.io/computer_science/intro_to_comp_programm/exercises/
- [Object Oriented Programming](#object-oriented-programming)
  - Lectures: https://kolosovpetro.github.io/computer_science/object_oriented_programming
  - Practice: https://kolosovpetro.github.io/computer_science/object_oriented_programming/exercises/
- [Data Structures](#data-structures) and [Algorithms](#algorithms)
  - Lectures: https://kolosovpetro.github.io/computer_science/data_structures_and_algorithms
  - Practice: https://kolosovpetro.github.io/computer_science/data_structures_and_algorithms/exercises/
- [Design patterns](#design-patterns)
- [SOLID](#solid)
- [Computational Methods](#computational-methods)
  - Lectures https://kolosovpetro.github.io/computer_science/comp_methods
  - Practice https://kolosovpetro.github.io/computer_science/comp_methods/exercises/
- [Misc](#misc)
- [Notes](#notes)

## Introduction to Computer Programming

* Assignments 1 (Read input from keyboard, casting variables, elementary loops)
* Assignments 2 (Proper input verification, conditional statements [if, switch, ternary operator], sorting network)
* Assignments 3 (Enums, string to enum parse, menu using enum, switch statement, stringbuilder, random)
* Assignments 4 (Arrays, bubble sort, sieve of eratosthenes, tic-tac-toe console game)
* Assignments 5 (Structs, reccursive functions, tic-tac-toc class segragation)
* Assignments 5 Library (Creating of class libraries, make reference to them in entry point project and execute)
* Assignments 6 (Writing to files, reading from files, nested loops, date-time, creating folders, value tuples)
* Assignments 7 (NUnit tests [exception test], documentation, custom exceptions)

## Object Oriented Programming

* OOP1 (Encapsulation, getters, setters, access modifiers)
* OOP2 (Constructors, constructor flow, this reference)
* OOP3 (Inheritance, overriding, base keyword, polymorphism, upcast)
* OOP4 (Interfaces, implementations)
* Project (Hospital management application, WinForms). Contains all OOP techniques + binary serialization in use

## Algorithms

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

## Data Structures

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

## Design Patterns

Refer to website: https://refactoring.guru/design-patterns

* Creational
  * Factory Method (Extends functionality of program)
  * Abstract Factory
  * Builder (Avoiding huge number of parameters withing object's consturctor. Combination of parameters.)
  * Prototype (Deepcopy of class)
* Structural
  * Decorator (Combine required functionalities)
  * Bridge
* Behavioral
  * Observer (Defines interaction between two or more classes)
  * Strategy (Extends functionality of program)
  
## SOLID

A set of principles recommended to follow in order to maintain business applications

* **Single Responsibility Principle** - `Do one thing, but do it best`
* **Open-Closed Principle** - `App. should be open for extension, but closed for modification`. Usually, solved by pattern `Strategy`
* **Liskov Substitution Principle** - `Proper abstractization, where all subclasses correctly implements methods from base class`
* **Interface Segregation Principle** - `Clients should not be forced to depend upon interfaces that they do not use.`
* **Dependency Inversion Principle**
  * `High-level modules should not depend on low-level modules. Both should depend on abstractions.`
  * `Abstractions should not depend on details. Details should depend on abstractions.`


## Computational Methods

* Numerical Sys. Converter (Pure example how to break all SOLID rules in 1 class, **DO NOT WRITE CODE THIS WAY**)
* System of Linear Equations Solver
* Polynomial Interpolation (Vandermonde method)
* Discrete Integration (Simpson's, Trapezoidal methods)
* Monte Carlo Method (Estimation on the plan finishing time)

## Misc

Other projects.

* **Database Control Panel**. Simple winforms app in order to perform SQL queries on PostgreSQL Database. Not protected from SQL injections. 
* **LINQ**. A set of custom methods in order to operate over IEnumerable collections.

## Notes

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
* `Single responsibility principle` can be threaten as partial case of `Interface segragation principle`, where current class implements only one interface.

