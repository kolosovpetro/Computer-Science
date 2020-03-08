## Learning C# (Basics, Algorithms, Design Patterns, Data Structures, SOLID)

> *"I am not afraid of a person who knows 10000 kicks. But I am afraid of a person who knows one kick but practices it for 10000 times." - Bruce Lee*

## Contents

- [Introduction to Computer Programming](#introduction-to-computer-programming)
- [Object Oriented Programming](#object-oriented-programming)
- [Algorithms](#algorithms)
- [Data Structures](#data-structures)
- [Design patterns](#design-patterns)
- [SOLID](#solid)
- [ADO .NET](#ado-net)
- [Git Simple Pull Request](#git-simple-pull-request)
- [Computational Methods](#computational-methods)
- [Misc](#misc)
- [To Do List](#to-do-list)
- [Notes](#notes)

---

## Introduction to Computer Programming

- Assignments 1 (Read input from keyboard, casting variables, elementary loops)
  - Lecture: https://kolosovpetro.github.io/cs/itcp/01Introduction.pdf
  - Tasks: https://kolosovpetro.github.io/cs/itcp/exercises/01Introduction_Exercises.pdf
- Assignments 2 (Proper input verification, conditional statements [if, switch, ternary operator], sorting network)
  - Lecture: https://kolosovpetro.github.io/cs/itcp/02Basics.pdf
  - Tasks: https://kolosovpetro.github.io/cs/itcp/exercises/02Basics_Exercises.pdf
- Assignments 3 (Enums, string to enum parse, menu using enum, switch statement, stringbuilder, random)
  - Lecture: https://kolosovpetro.github.io/cs/itcp/03Basics.pdf
  - Tasks: https://kolosovpetro.github.io/cs/itcp/exercises/03Basics_Exercises.pdf
- Assignments 4 (Arrays, bubble sort, sieve of eratosthenes, tic-tac-toe console game)
  - Lecture: https://kolosovpetro.github.io/cs/itcp/04Arrays.pdf
  - Tasks: https://kolosovpetro.github.io/cs/itcp/exercises/04Arrays_Exercises.pdf
- Assignments 5 (Structs, reccursive functions, tic-tac-toc class segragation)
  - Lecture: https://kolosovpetro.github.io/cs/itcp/05Functions.pdf
  - Tasks: https://kolosovpetro.github.io/cs/itcp/exercises/05Functions_Exercises.pdf
- Assignments 5 Library (Creating of class libraries, make reference to them in entry point project and execute)
  - Lecture: https://kolosovpetro.github.io/cs/itcp/05Functions.pdf
  - Tasks: https://kolosovpetro.github.io/cs/itcp/exercises/05Functions_Exercises.pdf
- Assignments 6 (Writing to files, reading from files, nested loops, date-time, creating folders, value tuples)
  - Lecture: https://kolosovpetro.github.io/cs/itcp/06Streams.pdf
  - Tasks: https://kolosovpetro.github.io/cs/itcp/exercises/06Streams_Exercises.pdf
- Assignments 7 (NUnit tests [exception test], documentation, custom exceptions)
  - Lecture: https://kolosovpetro.github.io/cs/itcp/07Documentation.pdf
  - Tasks: https://kolosovpetro.github.io/cs/itcp/exercises/07Documentation_Exercises.pdf

## Object Oriented Programming

Refer to https://kolosovpetro.github.io/cs/oop/

- OOP1 (Encapsulation, getters, setters, access modifiers)
  - Lecture: https://kolosovpetro.github.io/cs/oop/OOP_CS_01.pdf
  - Tasks: https://kolosovpetro.github.io/cs/oop/exercises/Task1.pdf
- OOP2 (Constructors, constructor flow, this reference)
  - Lecture: https://kolosovpetro.github.io/cs/oop/OOP_CS_02.pdf
  - Tasks: https://kolosovpetro.github.io/cs/oop/exercises/Task2.pdf
- OOP3 (Inheritance, overriding, base keyword, polymorphism, upcast)
  - Lecture: https://kolosovpetro.github.io/cs/oop/OOP_CS_03.pdf
  - Tasks: https://kolosovpetro.github.io/cs/oop/exercises/Task3.pdf
- OOP4 (Interfaces, implementations)
  - Lecture: https://kolosovpetro.github.io/cs/oop/OOP_CS_04.pdf
  - Tasks: https://kolosovpetro.github.io/cs/oop/exercises/Task4.pdf
- Project (Hospital management application, WinForms). Contains all OOP techniques + binary serialization in use

## Algorithms

Refer to https://kolosovpetro.github.io/cs/data_structures_and_algorithms/

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

- Implemented data structures are
  - Dictionary
  - Graph
  - Heap
  - LinkedList
  - Queue
  - Stack
  - Tree
  - Weighted Graph
  - Binary Search Tree (in progress. See good visualization: http://btv.melezinek.cz/binary-search-tree.html)
  - Generic List (in progress)

- To be implemented in future
  - Priority Queue

- What's used
  - NUnit UnitTest Framework
  - Generics
  - Indexers
  - IEnumerable interface implementation

## Design Patterns

Refer to website: https://refactoring.guru/design-patterns

* Creational
  * Factory Method (Extends functionality of program)
  * Abstract Factory
  * Builder (Avoiding huge number of parameters withing object's consturctor. Combination of parameters.)
  * Prototype (Deepcopy of class)
* Structural
  * Decorator (Combines required functionalities)
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

## ADO .NET

Work in PostgreSQL data base through .NET

Refer to https://kolosovpetro.github.io/cs/data_bases_2/01_NpgSQL.pdf

**Notes**

- Query which reterns data: `ExecuteReader()`
- DML DDL :`ExecuteReader()`
- SQL injection protect: `Parameters.AddWithValue("param", var);`
- While using `Parameters` do not use place variable between `''`, eg dont do `'@var'`

## Git Simple Pull Request

Example of simple pull request and other related activities.

Visit: https://github.com/kolosovpetro/Computer-Science/tree/develop/Simple%20Pull%20Request

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

## To do list

- Unite all Data Structures under single library
- Write documentation and comments for Design Patterns
- For all design patterns generate class diagrams
- Write various extensions for IEnumerable, structs, classes
- 

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
* In case of useage of `Inherritance` it is **essentially** important to follow `Liskov Substitution Principle` in abstract design.