## ADO .NET

Introduction to ADO .NET and Postgre Database. Implementations of some patterns.

### Active Record Pattern

Most simple way to operate with database through `C#` program. Approach which breaks several SOLID principles. 

### Data Mapper Pattern

More convenient way for `C#` application to interract with database. Divides in-memory objects from persistence. In proper implementation doesn't break SOLID principles. May be united with `Identity Map Pattern` in order to optimize interraction between application and database.

### Identity Map Pattern

Pattern to optimize interraction between application and database. In general, each extracted from data base object stored in structure like dictionary, so next time in case of request previously accessed entry in database, it will be got from cache, which is hunder time faster approach.

### Singleton pattern

Singleton is widely used in application-database relations. It prevents unsynchrone changes in-memory and db objects by several instances of mappers.

### Postgres 

Simple ADO .NET introductionary task.
