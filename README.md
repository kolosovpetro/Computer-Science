## Learning C# (Basics, Algorithms, Design Patterns, Data Structures, SOLID)

> *"I am not afraid of a person who knows 10000 kicks. But I am afraid of a person who knows one kick but practices it for 10000 times." - Bruce Lee*

## Contents

- [Introduction to Computer Programming](#introduction-to-computer-programming)
- [Object Oriented Programming](#object-oriented-programming)
- [Design patterns](#design-patterns)
- [Data Structures](#data-structures)
- [SOLID](#solid)
- [ASP .NET MVC Core](#asp-net-mvc-core)
- [PostgreSQL and Entity Framework Core](#postgresql-and-entity-framework-core)
- [ADO .NET](#ado-net)
- [Information](#information)
- [Computational Methods](#computational-methods)
- [Algorithms](#algorithms)

---

## Introduction to Computer Programming

- **Assignments 1**. Read input from keyboard, Casting variables, Elementary loops
  - Lecture: https://kolosovpetro.github.io/cs/itcp/01Introduction.pdf
  - Tasks: https://kolosovpetro.github.io/cs/itcp/exercises/01Introduction_Exercises.pdf
- **Assignments 2**. Proper input verification, Conditional statements [if, switch, ternary operator], Sorting network
  - Lecture: https://kolosovpetro.github.io/cs/itcp/02Basics.pdf
  - Tasks: https://kolosovpetro.github.io/cs/itcp/exercises/02Basics_Exercises.pdf
- **Assignments 3**. Enums, String to enum parse, Menu using enum, Switch statement, Stringbuilder, Random
  - Lecture: https://kolosovpetro.github.io/cs/itcp/03Basics.pdf
  - Tasks: https://kolosovpetro.github.io/cs/itcp/exercises/03Basics_Exercises.pdf
- **Assignments 4**. Arrays, Bubble sort, Sieve of Eratosthenes, Tic-tac-toe console game
  - Lecture: https://kolosovpetro.github.io/cs/itcp/04Arrays.pdf
  - Tasks: https://kolosovpetro.github.io/cs/itcp/exercises/04Arrays_Exercises.pdf
- **Assignments 5**. Structs, Reccursive functions, Tic-tac-toc class segragation
  - Lecture: https://kolosovpetro.github.io/cs/itcp/05Functions.pdf
  - Tasks: https://kolosovpetro.github.io/cs/itcp/exercises/05Functions_Exercises.pdf
- **Assignments 5**. Libraries. Creating of class libraries, making reference to them in entry point project and execute
  - Lecture: https://kolosovpetro.github.io/cs/itcp/05Functions.pdf
  - Tasks: https://kolosovpetro.github.io/cs/itcp/exercises/05Functions_Exercises.pdf
- **Assignments 6**. Writing to files, Reading from files, Nested loops, Date-time, Creating folders, Value tuples
  - Lecture: https://kolosovpetro.github.io/cs/itcp/06Streams.pdf
  - Tasks: https://kolosovpetro.github.io/cs/itcp/exercises/06Streams_Exercises.pdf
- **Assignments 7**. NUnit testing framework [exception test], Documentation, Custom exceptions
  - Lecture: https://kolosovpetro.github.io/cs/itcp/07Documentation.pdf
  - Tasks: https://kolosovpetro.github.io/cs/itcp/exercises/07Documentation_Exercises.pdf

## Object Oriented Programming

Refer to https://kolosovpetro.github.io/cs/oop/

- **Object-oriented programming 1**. Encapsulation, Getters, Setters, Access modifiers
  - Lecture: https://kolosovpetro.github.io/cs/oop/OOP_CS_01.pdf
  - Tasks: https://kolosovpetro.github.io/cs/oop/exercises/Task1.pdf
- **Object-oriented programming 2**. Constructors, Constructor flow, This reference
  - Lecture: https://kolosovpetro.github.io/cs/oop/OOP_CS_02.pdf
  - Tasks: https://kolosovpetro.github.io/cs/oop/exercises/Task2.pdf
- **Object-oriented programming 3**. Inheritance, Overriding, base keyword, Polymorphism, Upcast
  - Lecture: https://kolosovpetro.github.io/cs/oop/OOP_CS_03.pdf
  - Tasks: https://kolosovpetro.github.io/cs/oop/exercises/Task3.pdf
  - Polymorphism types: Ad-Hoc (overload of methods), Parametrical (Generics), Subtype polymorphism (Upcast, downcast)
- **Object-oriented programming 4**. Interfaces, implementations
  - Lecture: https://kolosovpetro.github.io/cs/oop/OOP_CS_04.pdf
  - Tasks: https://kolosovpetro.github.io/cs/oop/exercises/Task4.pdf
- **Project**: Hospital management application, WinForms. Contains all OOP techniques + binary serialization in use
- **Object-oriented programming 5**. Operator overriding
  - Lecture: https://kolosovpetro.github.io/cs/oop/OOP_CS_06.pdf
- **Object-oriented programming 6**. Converters
  - Lecture: https://kolosovpetro.github.io/cs/oop/OOP_CS_07-1.pdf
- **Object-oriented programming 7**. Aggregation vs Composition. Definitions and comparisons.

## Design Patterns

Refer to website: https://refactoring.guru/design-patterns

- **Creational**
  - Factory Method (Extends functionality of program)
  - Abstract Factory
  - Builder (Avoiding huge number of parameters withing object's consturctor. Combination of parameters.)
  - Prototype (Deepcopy of class)
- **Structural**
  - Decorator (Combines required functionalities)
  - Bridge
- **Behavioral**
  - Observer (Defines interaction between two or more classes)
  - Strategy (Extends functionality of program)

## Data Structures

- **Implemented data structures**
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

- **To be implemented**
  - Priority Queue

- **What's used**
  - NUnit UnitTest Framework
  - Generics
  - Indexers
  - IEnumerable interface implementation
  
## SOLID

A set of principles recommended to follow in order to maintain business applications. Contains examples of both convinient and unconviniet examples

- **Single Responsibility Principle** - `Do one thing, but do it best`
- **Open-Closed Principle** - `App. should be open for extension, but closed for modification`. Usually, solved by pattern `Strategy`
- **Liskov Substitution Principle** - `Proper abstractization, where all subclasses correctly implements methods from base class`
- **Interface Segregation Principle** - `Clients should not be forced to depend upon interfaces that they do not use.`
- **Dependency Inversion Principle**
  - `High-level modules should not depend on low-level modules. Both should depend on abstractions.`
  - `Abstractions should not depend on details. Details should depend on abstractions.`

## ASP NET MVC Core

- https://github.com/kolosovpetro/Computer-Science/tree/develop/ASP%20NET%20MVC

## PostgreSQL and Entity Framework Core

- Code First Approach (Migrations)
- Database First Approach (Reverse engineering)

## ADO .NET

- Introduction
- Active record pattern
- Data mapper pattern
- Identity map pattern
- Treadsafe singleton

## Information

- **C# Keywords**
  - https://github.com/kolosovpetro/Computer-Science/tree/develop/Information/Keywords
- **Mutable and Immutable types**
  - https://github.com/kolosovpetro/Computer-Science/tree/develop/Information/MutablesAndImmutables
- **Notes**
  - https://github.com/kolosovpetro/Computer-Science/tree/develop/Information/Notes
- **Nullable structs**
  - https://github.com/kolosovpetro/Computer-Science/tree/develop/Information/Nullables
- **Git pull request guide**
  - https://github.com/kolosovpetro/Computer-Science/tree/develop/Information/GitPullRequest
- **Terminology**
  - https://github.com/kolosovpetro/Computer-Science/tree/develop/Information/Terminology

## Computational Methods

- Numerical Sys. Converter (Guide now not to write code)
- System of Linear Equations Solver
- Polynomial Interpolation (Vandermonde method)
- Discrete Integration (Simpson's, Trapezoidal methods)
- Monte Carlo Method (Estimation on the plan finishing time)

## Algorithms

Refer to https://kolosovpetro.github.io/cs/data_structures_and_algorithms/

- **Search Algorithms and their benchmark measurements**
  - Linear Search
  - Binary Search
  
- **Sort Algorithms and their benchmark measurements**
  - Bubble sort. Complexity O(n^2)
  - Cocktail sort. Complexity (Buble 2 pass sort) O(n^2)
  - Counting sort. Complexity O(n+k), k = non negative terms count
  - Insertion sort. Complexity O(n)
  - Merge sort. Complexity O(n*log(n))
  - Quick sort. Complexity O(log(n))
  - Selection. Complexity sort O(n^2)

## Useful Links

- Praparation to MS Exam 70-483: https://habr.com/ru/post/245067/
- Complete `C#` guide: https://metanit.com/sharp/
