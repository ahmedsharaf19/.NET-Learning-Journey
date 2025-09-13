## Agenda
This session covers key database concepts and features:

- **View**  
- **Stored Procedures**  
- **View vs Function vs Stored Procedures**
---
## View

A **View** is a virtual table that is based on the result of a SQL query.  
It does not store the data itself; instead, it displays data stored in one or more tables.

### Key Points
- Acts like a table but only contains the query definition, not physical data.
- Simplifies complex queries by saving them under a single name.
- Can be used to control access to specific columns or rows (security).
- Automatically reflects changes in the underlying tables.

### Uses
1. **Focus, Simplify, and Customize**  
   Provides each user with a tailored perception of the database by exposing only specific data.
2. **Security Mechanism**  
   Grants users access to data through the view layer instead of directly to the base tables.

### Advantages
1. **Simplicity** – Saves complex queries under a single name for easy reuse.  
2. **Consistency** – Centralizes business logic in one query definition.  
3. **Security** – Hides real table and column names, reducing exposure in case of SQL injection (an attacker could drop the view, not the base table).

### Types of Views
- **Basic User-Defined Views**  
- **Indexed Views**  
- **Partitioned Views**

### Limitations
1. The body can contain only a `SELECT` statement (no `INSERT`, `UPDATE`, or `DELETE`).  
2. Cannot accept parameters.  
3. Cannot perform `INSERT`, `DELETE`, or `UPDATE` operations.  
4. Must be created in the current database; cannot directly reference another database for creation.  
5. Maximum of **1024** columns in the `SELECT` statement.

### Types of Views

#### 1. User-Defined View
A standard view created by a simple `SELECT` statement.

**Key Rules**
- Must contain **only one `SELECT` statement**.
- `ORDER BY` is **not allowed**, unless it is combined with a `TOP` clause.
- Cannot include the `INTO` keyword.
- Cannot include the `OPTION` keyword.
- Cannot use **table variables** or **temporary tables**.

### Syntax
```sql
CREATE VIEW ViewName
AS
    SELECT column_list
    FROM TableName
    WHERE conditions;
```
EX:
```sql
CREATE VIEW VCairoStudent
AS
    SELECT St_id, St_Fname, St_Address
    FROM Student
    WHERE St_Address = 'Cairo';
```
You can query a view just like a table:
```sql
SELECT * FROM VCairoStudent;
```
Every time the view is executed, SQL Server runs the underlying SELECT first.

### Maintenance

Create or Alter:
```sql
CREATE OR ALTER VIEW VCairoStudent AS ...
```

### Move to Another Schema:
```sql
ALTER SCHEMA NewSchemaName
TRANSFER VCairoStudent;
```

### View Source Code:
```sql
sp_helptext 'VCairoStudent';
```

### Encryption

Hide the view’s definition:
```sql
CREATE OR ALTER VIEW VCairoStudent
WITH ENCRYPTION
AS
    SELECT * FROM Student;
```

### Column Aliases

Assign custom column names when defining the view:
```sql
CREATE VIEW VCairoStudent (Name, Age)
AS
    SELECT St_Name, St_Age
    FROM Student;
```
When selecting from this view, the columns will appear as Name and Age.

---
#### 2. Partitioned View
A **Partitioned View** is similar to a standard view, but it combines the results of **multiple `SELECT` statements** into a single result set.  
To merge the queries, you must use a **set operation** such as `UNION`, `UNION ALL`, `EXCEPT`, or `INTERSECT`.

**Key Idea**
- Useful when data is spread across multiple tables (for example, separate tables for each region or year) but needs to be queried as one logical table.

### Syntax
```sql
CREATE VIEW ViewName
AS
    SELECT column_list
    FROM Table1
    WHERE condition
UNION ALL
    SELECT column_list
    FROM Table2
    WHERE condition
-- Additional SELECT statements as needed
```

Ex:
```sql
CREATE VIEW VAllStudents
AS
    SELECT St_id, St_Fname, St_Address
    FROM Student_East
UNION ALL
    SELECT St_id, St_Fname, St_Address
    FROM Student_West;
```
Note: UNION ALL is typically used for better performance because it does not remove duplicates.
---

### View with DML
You can perform **DML operations** (`INSERT`, `UPDATE`, `DELETE`) through a view to modify the underlying base tables, but only under specific conditions.

#### Conditions
1. **Single Base Table**  
   The modification must affect **only one table** in the view definition.

2. **No Derived Columns**  
   You cannot modify columns that are:
   - Calculated using aggregate functions (e.g., `SUM`, `AVG`).
   - Computed from other columns.

3. **No Set Operators**  
   The target column cannot come from a query that uses `UNION`, `UNION ALL`, `INTERSECT`, or `EXCEPT`.

4. **No Grouping or Distinct**  
   The column being modified cannot be part of a `GROUP BY` or use the `DISTINCT` keyword.


### 1. INSERT
- **Single-Table View**  
  You can insert directly:
```sql
  INSERT INTO ViewName
  VALUES (value_list);
```
This inserts data into the underlying base table, not into the view itself.

- **Multi-Table View**
You must specify the target columns that belong to a single base table:
```sql
INSERT INTO ViewName (column_list_from_one_table)
VALUES (value_list);
```

Attempting to insert into columns that belong to more than one base table will cause an error.

### 2. UPDATE

Must affect only one base table:
```sql
UPDATE ViewName
SET column = value
WHERE condition;
```
### 3. DELETE

Allowed only if the view selects from one base table:
```sql
DELETE FROM ViewName
WHERE condition;
```
Each command is executed against the underlying table(s) as if you ran it directly on them— the view acts only as a layer of abstraction.

### View with `WITH CHECK OPTION`

When you allow **INSERT** or **UPDATE** operations through a view, users could add or modify rows so that they **no longer meet the view’s `WHERE` condition**.  
The `WITH CHECK OPTION` clause prevents this by rejecting any change that would make a row fall outside the view’s filter.

#### Key Idea
- **Without `WITH CHECK OPTION`**:  
  Users can insert or update data that does not match the view’s `WHERE` clause.  
  The row remains in the base table but becomes invisible through the view.
- **With `WITH CHECK OPTION`**:  
  Any `INSERT` or `UPDATE` that violates the view’s condition is rejected.

#### Syntax
```sql
CREATE VIEW view_name
AS
    SELECT column_list
    FROM table_name
    WHERE condition WITH CHECK OPTION;
```

Example
```sql
CREATE VIEW VCairoStudent
AS
    SELECT St_id, St_Name, St_Address
    FROM Student
    WHERE St_Address = 'Cairo' WITH CHECK OPTION;
```
- Valid Update
```sql
UPDATE VCairoStudent
SET St_Name = 'Aly'
WHERE St_id = 1;
```
The row still satisfies St_Address = 'Cairo', so the update succeeds.

- Invalid Update
```sql
UPDATE VCairoStudent
SET St_Address = 'Alex'
WHERE St_id = 1;
```
❌ Fails because the row would no longer match the view’s filter.

- Invalid Insert
```sql
INSERT INTO VCairoStudent (St_id, St_Name, St_Address)
VALUES (3, 'Sara', 'Giza');
```
❌ Fails for the same reason.

- Summary:
WITH CHECK OPTION guarantees that all rows inserted or updated through the view continue to satisfy the view’s WHERE condition, preserving the view’s intended logic and security.
---
## 2. Stored Procedures

A **Stored Procedure (SP)** is a precompiled collection of SQL statements that can accept input parameters, return output parameters, and modify or retrieve data in a database.

---

### Why Stored Procedures Improve Performance
Every SQL query normally goes through four internal stages:

1. **Parse Syntax** – Validate that the SQL syntax is correct.  
2. **Optimize Metadata** – Verify that table and column names exist and are valid.  
3. **Query Tree** – Determine the logical execution order.  
4. **Execution Plan** – Create the physical plan to run the query.

If the same query is executed repeatedly, it would normally pass through all these stages each time.  
A stored procedure **caches the execution plan**, so future calls skip the first three stages and execute faster.

---

### Key Capabilities
- Accept **input parameters** and return **output parameters**.
- Execute any DML statements (`INSERT`, `UPDATE`, `DELETE`).
- Return a **status value** to indicate success or failure.

---

### Benefits
1. **Reduced Network Traffic**  
   Only the call to the stored procedure is sent to the server, not the full SQL text.
2. **Stronger Security**  
   - You can grant permissions to execute a procedure without giving direct access to the underlying tables.  
   - Helps mitigate SQL injection attacks because users never run ad-hoc SQL.
3. **Code Reuse**  
   Write the logic once and call it multiple times.
4. **Easier Maintenance**  
   Update the procedure in one place without changing application code.
5. **Improved Performance**  
   Reuses the cached execution plan for faster execution.

---

### Types of Stored Procedures
1. **User-Defined** – Created by database developers for custom logic.
2. **Temporary** – User-defined but stored temporarily:  
   - **Local**: Accessible only in the current session.  
   - **Global**: Accessible to all sessions until the creating session ends.
3. **System** – Built-in procedures provided by the database engine (e.g., `sp_help`).
4. **Extended User-Defined** – Custom procedures that can integrate external code (e.g., CLR in .NET).

---
### Creating and Executing a Stored Procedure

#### Create Procedure
Use `CREATE PROC` (or `CREATE PROCEDURE`) to define the procedure.  
`WITH ENCRYPTION` hides the source code from tools like `sp_helptext`.

```sql
CREATE PROC NameOfProc @id INT  -- We Can Define Multiple Var Separted By Comma
WITH ENCRYPTION      -- Hides the procedure’s source code
AS
BEGIN
    SELECT *
    FROM Student
    WHERE St_id = @id;
END
```

- Executing the Procedure
You can call the procedure in several ways:
```sql
-- Simplest form (no parentheses)
NameOfProc 101
```
```sql
-- Using EXECUTE (or the shorthand EXEC)
EXECUTE NameOfProc 101
EXEC NameOfProc 101
```

- Note:
1. The no-parentheses style distinguishes a stored procedure call from a function call.
2. Use the keyword EXECUTE (or EXEC) when running multiple commands in the same batch to avoid ambiguity.

This approach ensures that:
- The procedure can accept parameters (@id in this example).
- The source code remains hidden if WITH ENCRYPTION is specified.

### Insert Based on `EXECUTE`

You can insert rows into a table using the **result set returned by a stored procedure**.

#### Syntax
```sql
INSERT INTO TargetTable (column_list)
EXEC NameOfProcedure @param1, @param2;
```
The procedure’s result set must match the column list of the target table in number and data types.
Example:
```sql
-- Suppose GetActiveStudents returns columns (St_id, St_Name, St_Address)
INSERT INTO StudentBackup (St_id, St_Name, St_Address)
EXEC GetActiveStudents;
```
- Important Limitations
You cannot:
1. Add a WHERE clause.
2. Use GROUP BY, ORDER BY, or any other query operations on the result set.

- The data is inserted exactly as returned by the stored procedure.
This technique is useful for archiving or copying data but offers no flexibility for further filtering or transformation during the insert.

### Maintenance and Options

#### Create or Alter
You can create a new stored procedure or update an existing one in a single statement:
```sql
CREATE OR ALTER PROCEDURE ProcedureName @Param INT
AS
BEGIN
    -- procedure body
END
```
- SET NOCOUNT ON | OFF

Placed at the start of a procedure to control the “(x rows affected)” message:
```sql
CREATE OR ALTER PROCEDURE ProcedureName
AS
BEGIN
    SET NOCOUNT ON;  -- Suppresses the message
    -- SQL statements
END
```

- ON (recommended): Prevents sending row-count messages back to the client, which reduces network traffic and slightly improves performance.

- OFF (default): Sends the row-count message after each statement.

#### Move a Stored Procedure to Another Schema
You can transfer a stored procedure from one schema to another:
```sql
ALTER SCHEMA NewSchemaName
TRANSFER OldSchemaName.ProcedureName;
```
The procedure keeps the same name but now resides in the new schema.

- These options simplify maintenance by allowing in-place updates, reducing unnecessary messages, and supporting clean organization of procedures across schemas.



### Error Handling in Stored Procedures

You can handle errors and customize error messages using **TRY…CATCH** blocks inside a stored procedure.  
This allows you to control the flow of execution and return meaningful messages or handle business rules.

#### Syntax
```sql
CREATE PROC SPDeleteTopicById
    @TopId INT
WITH ENCRYPTION
AS
BEGIN
    BEGIN TRY
        DELETE FROM Topic
        WHERE Top_id = @TopId;
    END TRY
    BEGIN CATCH
        PRINT 'NOT Success';   -- Custom error message
    END CATCH
END
```
If an error occurs in the BEGIN TRY section, control automatically moves to BEGIN CATCH.

- These constructs (BEGIN, END, IF, RETURN) are standard control-flow statements in T-SQL.

### Input Parameters
Stored procedures can accept input parameters with or without default values.

Basic Example
```sql
CREATE PROC SPSubtractData
    @X INT,
    @Y INT
WITH ENCRYPTION
AS
BEGIN
    SELECT @X - @Y AS Result;
END
```
- Calling the Procedure
1. Pass by Order
```sql
SPSubtractData 4, 2;
```
2. Pass by Name
```sql
SPSubtractData @Y = 2, @X = 4;
```

3. Default Parameter Values
You can assign default values so parameters become optional:

```sql
ALTER PROC SPSubtractData
    @X INT = 4,
    @Y INT = 1
WITH ENCRYPTION
AS
BEGIN
    SELECT @X - @Y AS Result;
END
```
- Call Variations
```sql
SPSubtractData;               -- Uses defaults: X=4, Y=1
SPSubtractData 3;             -- X=3, Y=1 (default for Y)
SPSubtractData @Y = 6;        -- X=4 (default), Y=6
SPSubtractData 4, 5;          -- X=4, Y=5
```
- Tip: Mixing named and positional parameters is allowed, but positional arguments must come first.

These techniques let you:
1. Enforce business rules inside stored procedures.
2. Provide flexible parameter handling.
3. Return clearer, customized messages when errors occur.

### Output Parameters in Stored Procedures

Stored procedures do not have a traditional return value,  
but you can return data using **output parameters**.

---

#### Basic Output Parameters
You declare parameters with the `OUTPUT` keyword, assign values inside the procedure, and then capture them in variables when calling it.

```sql
CREATE PROC SPGetStudentNameById
    @Id   INT,
    @Name VARCHAR(30) OUTPUT,
    @Age  INT OUTPUT
WITH ENCRYPTION
AS
BEGIN
    SELECT
        @Name = St_Fname,
        @Age  = St_Age
    FROM Student
    WHERE St_id = @Id;
END
```
- Call Example
```sql
DECLARE @StudentName VARCHAR(30),
        @StudentAge  INT;

EXEC SPGetStudentNameById
     @Id = 1,
     @Name = @StudentName OUTPUT,
     @Age  = @StudentAge  OUTPUT;

SELECT @StudentName AS Name, @StudentAge AS Age;
```

### Input/Output Parameters
A single parameter can act as both input and output.
This lets you pass a value in and receive an updated value back.

```sql
CREATE PROC SPGetNameAge
    @Name VARCHAR(30) OUTPUT,
    @Data INT OUTPUT
WITH ENCRYPTION
AS
BEGIN
    SELECT
        @Name = St_Fname,
        @Data = St_Age      -- OUTPUT assignment
    FROM Student
    WHERE St_id = @Data;    -- uses @Data as input
END
```
- Call Example
```sql
DECLARE @Data INT = 1, @Name VARCHAR(30);
EXEC SPGetNameAge @Name OUTPUT, @Data OUTPUT;
SELECT @Name AS Name, @Data AS Age;
```
Notes:

- When calling a procedure with output parameters, you must use the OUTPUT keyword each time.
- The same variable can be read after the procedure completes to access the returned values.
- These patterns allow stored procedures to pass multiple values back to the caller without relying on a single return code.

---
## 3. Function vs. View vs. Stored Procedure

| Feature / Use Case          | View                          | Function                              | Stored Procedure                       |
|-----------------------------|--------------------------------|----------------------------------------|-----------------------------------------|
| **Primary Purpose**         | Simplify and encapsulate `SELECT` queries. | Return a single value or a table, often with input parameters. | Execute complex logic, including `INSERT`, `UPDATE`, `DELETE`, and `SELECT`. |
| **Parameters**              | None                          | Input parameters only                  | Input **and** output parameters         |
| **DML (Insert/Update/Delete)** | ❌ Not allowed directly        | ❌ Not allowed (except in rare cases with table-valued functions for selects only) | ✅ Fully supported                       |
| **Return Type**             | Virtual table (query result)   | Scalar value or table                  | Optional return status (integer) and/or output parameters |
| **Performance**             | Lowest among the three         | Comparable to stored procedures        | Comparable to functions                 |
| **Execution**               | Queried like a table/view      | Invoked like a function (`SELECT dbo.FunctionName(...)`) | Called with `EXEC` or by procedure name |
| **Typical Use**             | Parameter-less read-only queries | Parameterized read-only calculations or table-returning queries | Full business logic and data modifications |

---

### Quick Decision Guide

- **Need to perform `INSERT`, `UPDATE`, or `DELETE`?**  ➜ **Stored Procedure**.

- **Need a simple `SELECT` with no parameters?**  ➜ **View**.

- **Need a `SELECT` with input parameters only?**  ➜ **Function**.

- * Need both input and output parameters or complex control flow?**  ➜ **Stored Procedure**.

> **Performance Tip:**  
> Views generally have the lowest performance.  
> Functions and stored procedures perform similarly; the difference depends mainly on the complexity of their internal logic.
