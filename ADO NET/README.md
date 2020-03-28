## ADO .NET

PostrgreSQL, ADO .NET, Entity Framework

### Active Record Pattern

An approach to fight against Active record's SOLID violations. Solution is to create `Object` - data base relation's row, `Database context` which implements Select, Insert, Update actions to Db. To implement Selection factory pattern is used. All functionalities of DB context are segregated on generic interfaces. Generics are used in order to avoid use of Marker Interface anti-pattern which leads to excessive castings of out objects. 

### Database Control Panel

Winform application in order to import select's result inside `GridRow`.

### Postgres 

Solutions to https://kolosovpetro.github.io/cs/data_bases_2/Exercise_01_Npgsql.pdf

**Notes**

- Query which reterns data: `ExecuteReader()`
- DML DDL : `ExecuteNonQuery()`
- SQL injection protect: `Parameters.AddWithValue("param", var);`
- While using `Parameters` do not use place variable between `''`, eg dont do `'@var'`