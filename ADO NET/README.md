## ADO .NET

Work in PostgreSQL data base through ADO .NET

Refer to https://kolosovpetro.github.io/cs/data_bases_2/01_NpgSQL.pdf

**Notes**

- Query which reterns data: `ExecuteReader()`
- DML DDL : `ExecuteNonQuery()`
- SQL injection protect: `Parameters.AddWithValue("param", var);`
- While using `Parameters` do not use place variable between `''`, eg dont do `'@var'`