## Agenda
- Execution Order
- Union Family
- SELECT INTO
- INSERT Based on SELECT
- DELETE vs DROP vs TRUNCATE
- Relationship Rules
- User-Defined Functions
---
## 1. Execution Order

The **execution order** in SQL refers to the sequence in which the query clauses are processed.  
This order is different from how we **write or read** the query.

### Actual Execution Order
1. **FROM / JOIN** → Identify the tables to query from.  
2. **WHERE** → Filter rows from those tables.  
3. **GROUP BY** → Group the filtered rows.  
4. **HAVING** → Filter the groups.  
5. **SELECT** → Choose the columns or expressions to display.  
6. **DISTINCT** → Remove duplicates (if specified).  
7. **ORDER BY** → Sort the result set.  
8. **TOP** → Limit the number of rows returned.

---

### Example: Invalid Query
```sql
SELECT CONCAT_WS(' ', St_Fname, St_Lname) AS FullName
FROM Student
WHERE FullName = 'Ahmed';
```
❌ This is invalid because WHERE is executed before SELECT.
At that point, the alias FullName doesn’t exist yet.

- Corrected with Subquery
Wrap the SELECT in a subquery so the alias is available:
```sql
SELECT FullName
FROM (
    SELECT CONCAT_WS(' ', St_Fname, St_Lname) AS FullName
    FROM Student
) AS St
WHERE FullName = 'Ahmed';
```
✅ Now it works, because FROM (the subquery) is executed before WHERE.
---
## 2. Set Operators (Union Family)

Set operators are used to **combine the result sets of two or more SELECT queries**.

### Main Operators
- `UNION`  
  Combines rows from both queries and **removes duplicates** (acts like `DISTINCT`).
- `UNION ALL`  
  Combines rows from both queries and **keeps duplicates**.
- `EXCEPT`  
  Returns rows that appear in the **first** query but **not** in the second.  
  *(In some databases `MINUS` is used instead of `EXCEPT`.)*
- `INTERSECT`  
  Returns rows that appear in **both** queries.

---

### Rules & Requirements
1. **Same number of columns** in each SELECT and in the same order (position matters).  
2. **Compatible data types** for each column position (the DB must be able to implicitly convert one type to the other).  
3. Columns are compared **positionally** (1st column with 1st column, 2nd with 2nd, ...).  
4. The **result column names** come from the first SELECT.  
5. `ORDER BY` (if used) applies to the **final combined result** — many RDBMS require `ORDER BY` only at the end of the combined query.  
6. `UNION` implies deduplication (may sort/hash), so `UNION ALL` is usually faster when duplicates are acceptable.  
7. NULL handling and exact behavior may vary slightly between DBMS; check your system for edge cases.

---

### Examples

**Basic UNION (distinct)**
```sql
SELECT St_Fname
FROM StudentCairo
UNION
SELECT St_Fname
FROM StudentAlex;
```
Keep duplicates with UNION ALL.
```sql
SELECT St_Fname
FROM StudentCairo
UNION ALL
SELECT St_Fname
FROM StudentAlex;
```
INTERSECT — common rows.
```sql
SELECT St_Fname
FROM StudentCairo
INTERSECT
SELECT St_Fname
FROM StudentAlex;
```
EXCEPT — rows in Cairo not in Alex.
```sql
SELECT St_Fname
FROM StudentCairo
EXCEPT
SELECT St_Fname
FROM StudentAlex;
```
### Common Errors (and why)
- 1) Different column counts

-- ERROR: column count mismatch
```sql
SELECT St_Id, St_Fname FROM StudentCairo
UNION
SELECT St_Fname FROM StudentAlex;
```

- 2) Same column count but incompatible types (positional mismatch)
```sql
-- POTENTIAL ERROR: if St_Id is INT and St_Fname is VARCHAR, these positions are not compatible
SELECT St_Id, St_Fname FROM StudentCairo
UNION
SELECT St_Fname, St_Id FROM StudentAlex;
```

Explanation: the first column of the first query must be compatible with the first column of the second query, etc. Swapping columns between queries will produce errors if the positional types differ.

### Practical Tips

- Use UNION ALL when you don't need duplicates (faster).
- If you need control over the final column names, define aliases in the first SELECT.
- If you must order the combined result, put ORDER BY after the last SELECT (final result).
- When combining many queries or doing complex logic, you can use parentheses to group operations for clarity.
---
## 3. Schema
A **schema** in SQL Server (and many other RDBMSs) is **not** an ERD diagram or conceptual model.  
It is a **container** inside a database that holds objects such as **tables, views, functions, stored procedures, etc.**

Think of it as a *namespace* that organizes database objects.

---
### Hierarchy
Server → Database → Schema → Objects

- **Server**: The SQL Server instance.
- **Database**: A single database within that instance.
- **Schema**: Logical grouping of objects inside the database.
- **Objects**: Tables, views, functions, etc.

---

### Default Schema
- The default schema is **`dbo`** (Database Owner).
- If you create an object without specifying a schema, it is placed in `dbo`.

---

### Fully Qualified Object Name
The complete path to a database object is:
[ServerName].[DatabaseName].[SchemaName].[ObjectName]
Example:
```sql
CREATE TABLE [ServerName].[DbName].[Sales].[Orders] (
    OrderID INT PRIMARY KEY,
    OrderDate DATETIME
)
```
- Shortcuts
If the object is in the dbo schema, you can omit [SchemaName].
If you are connected to the correct database, you can omit [DatabaseName].
If you are already connected to the correct server, you can omit [ServerName].
So this is valid if using default schema and current DB:
```sql
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    OrderDate DATETIME
)
```
### Why Use Schemas?
Schemas solve three key problems:
1. Name Collision
You can create objects with the same name in different schemas.
Example: Sales.Orders and HR.Orders can coexist.

2. Logical Grouping
Organize related objects together for clarity and maintenance.
Example: group all HR-related tables under an HR schema.

3. Security & Permissions
Grant or deny permissions at the schema level.
Example: Allow the HR team access only to objects inside the HR schema.
---
#### Summary
A schema is a logical container inside a database.
Default schema is dbo.
Always reference objects with their fully qualified name when needed:
[Server].[Database].[Schema].[Object]
Use schemas to avoid naming conflicts, logically group objects, and manage permissions efficiently.
---
### 1️⃣  Create a New Schema
To create a schema, use `CREATE SCHEMA` followed by the schema name.

```sql
CREATE SCHEMA Sales;
```
- Important Execution Tip
In SQL Server Management Studio (SSMS) or scripts that contain multiple statements,
it’s safer to place the CREATE SCHEMA command in a separate batch.

Use the GO keyword to mark batch boundaries:
```sql
GO
CREATE SCHEMA Sales;
GO
```
GO is not a SQL statement; it’s an SSMS/SQLCMD batch separator.

### 2️⃣ Move an Object to Another Schema
To move (transfer) an object such as a table or view to a different schema:
```sql
ALTER SCHEMA TargetSchema
TRANSFER SourceSchema.ObjectName;
```
Example:
```sql
ALTER SCHEMA HR
TRANSFER dbo.Employees;
```
This moves the Employees table from the dbo schema to the HR schema.

### 3️⃣ Drop (Delete) a Schema
A schema must be empty before it can be dropped.
First, drop or move all objects inside it.
```sql
DROP SCHEMA Sales;
```
If the schema contains objects (tables, views, etc.), the command will fail until those objects are removed or transferred.

### Summary
| Action          | Command Example                           |
| --------------- | ----------------------------------------- |
| **Create**      | `CREATE SCHEMA HR;`                       |
| **Move Object** | `ALTER SCHEMA HR TRANSFER dbo.Employees;` |
| **Drop Schema** | `DROP SCHEMA HR;`                         |


- Key Points
    - Schemas are logical containers; dropping them does not drop the database itself.
    - Always verify that no dependent objects remain before dropping a schema.
    - Using GO ensures that each CREATE SCHEMA runs in its own batch to avoid compilation errors.
---
## 4. SELECT INTO

`SELECT INTO` belongs to the **DDL (Data Definition Language)** family  
because it creates a **new table** while simultaneously inserting data into it.

---
### Purpose
- Create a **new table** based on the structure of an existing query’s result set.
- Automatically insert the selected data into that new table.

---
### Syntax
```sql
SELECT column_list INTO   NewTableName
FROM   SourceTable
[WHERE condition];
```
### Key Behaviors
1. Creates the new table first.
2. Then runs the SELECT to retrieve rows.
3. Finally inserts those rows into the new table.

#### Execution order (for this command only):

- INTO – new table definition is created.
- SELECT – data is retrieved.
- INSERT – retrieved data is inserted into the new table.

#### Examples
- 1️⃣ Copy Entire Table
Creates NewProject with the same columns as Project and copies all rows:
```sql
SELECT *
INTO NewProject
FROM MyCompany.dbo.Project
```
- 2️⃣ Copy Selected Columns Only
Creates a table with just two columns and their data:
```sql
SELECT Pname, Pnumber
INTO NewProject
FROM MyCompany.dbo.Project
```
- 3️⃣ Copy Structure Only (No Data)
Use a condition that is always false to create only the structure:
```sql
SELECT *
INTO NewProject
FROM MyCompany.dbo.Project
WHERE 1 = 2
```
This creates an empty table with the same column definitions.

### Notes & Limitations
Keys & Constraints:

- Column definitions and data types are copied.
- Primary keys, foreign keys, indexes, and triggers are NOT copied.
- Permissions: You need CREATE TABLE rights in the target database.
- The new table is created in the current database unless you fully qualify its name:
```sql
SELECT * INTO AnotherDB.dbo.NewProject FROM MyCompany.dbo.Project
```

## 5. INSERT Based on SELECT

Instead of providing literal values in an `INSERT` statement,  
you can **insert rows from the result of a query on another table**.

This is sometimes called **INSERT…SELECT**.

---

### Basic Syntax
```sql
INSERT INTO TargetTable
SELECT column_list
FROM   SourceTable
[WHERE condition]
```
- Key Points
The number of columns in the SELECT must match the number of columns in the INSERT target list.
The data types must be compatible position by position.

### Examples
- 1️⃣ Insert All Columns (Order Matters)
```sql
INSERT INTO EmployeesArchive
SELECT *
FROM Employees
WHERE HireDate < '2020-01-01'
```
- Copies all columns from Employees into EmployeesArchive.
- Columns must match exactly in count, order, and type.

- 2️⃣ Insert into Specific Columns

You can explicitly list target columns to control mapping:
```sql
INSERT INTO EmployeesArchive (EmpID, EmpName, Salary)
SELECT EmpID, EmpName, Salary
FROM Employees
WHERE Department = 'IT'
```
The columns in the SELECT must correspond in order to those listed in the INSERT.

### Notes & Tips
You can select from multiple tables (using JOINs) as long as the final projection matches the target table columns.
DEFAULT constraints on target columns will fill in any omitted columns if not specified.
Unlike SELECT INTO, this statement does not create the target table—it must already exist.

### Quick Comparison
| Feature                 | `SELECT INTO`                           | `INSERT ... SELECT`                    |
| ----------------------- | --------------------------------------- | -------------------------------------- |
| Creates target table    | ✅ Yes                                   | ❌ No (table must exist)                |
| Copies structure & data | ✅ Structure + rows                      | ❌ Data only, target structure pre-made |
| Keeps indexes/keys      | ❌ Keys/indexes not copied automatically | N/A (existing table keeps its indexes) |
---
## 6. DELETE vs TRUNCATE vs DROP

These three commands remove data or database objects,  
but they differ in **scope**, **logging**, **performance**, and **recoverability**.

---
## Quick Comparison Table

| Feature / Command | **DELETE**                          | **TRUNCATE**                               | **DROP**                                  |
|-------------------|--------------------------------------|---------------------------------------------|--------------------------------------------|
| **Purpose**       | Remove **some or all** rows from a table. | Remove **all** rows from a table.           | Remove the **entire table (object)** from the database. |
| **WHERE clause**  | ✅ Yes – can filter specific rows.    | ❌ No – all rows removed.                    | ❌ Not applicable.                          |
| **Table structure** | Preserved (table remains).          | Preserved (table remains).                   | Removed (table no longer exists).           |
| **Schema/Definition** | Unchanged.                        | Unchanged.                                   | Lost – must `CREATE TABLE` again to reuse. |
| **Logging**       | Fully logged (row by row).           | Minimal logging (faster for large tables).   | Logs object removal.                         |
| **Identity reset**| ❌ By default, identity seed not reset (can use `DBCC CHECKIDENT`). | ✅ Identity column reset to seed.            | N/A (table dropped).                         |
| **Rollback**      | ✅ Transaction-safe (can rollback).   | ✅ Transaction-safe (can rollback).          | ✅ Transaction-safe (can rollback if inside explicit transaction). |
| **Foreign Key**   | Can delete rows referenced by FK if allowed (or use `ON DELETE` rules). | Must remove/disable FKs referencing table.   | Must remove/disable FKs referencing table.   |
| **Performance**   | Slower for large tables (row logging).| Faster for large tables.                     | N/A (object-level operation).                |

---

### Examples

#### 1️⃣ DELETE
Remove specific rows but keep the table and structure:
```sql
DELETE FROM Employees
WHERE Department = 'Sales';
```
#### 2️⃣ TRUNCATE
Remove all rows quickly, reset identity seed:
```sql
TRUNCATE TABLE Employees
```
#### 3️⃣ DROP
Completely remove the table and its definition:

```sql
DROP TABLE Employees
```
### Key Takeaways
DELETE: Use when you need to remove specific rows or log each deletion.
TRUNCATE: Use when you need to clear a table entirely but keep its structure for reuse.
DROP: Use when you no longer need the table or want to permanently remove its schema object.
---

## 7. Relationship Rules (ON UPDATE / ON DELETE)

When a **parent row** in a table has related **child rows** in another table  
(or in the same table for self-referencing), you must decide what happens when the parent is **updated** or **deleted**.

These behaviors are controlled by **FOREIGN KEY constraints** using `ON UPDATE` and `ON DELETE` rules.

---

### The Four Actions

| Rule         | Description                                                                 | Requirements / Notes                                              |
|--------------|-------------------------------------------------------------------------------|--------------------------------------------------------------------|
| **NO ACTION** (default) | Prevents the parent row from being updated or deleted if matching child rows exist. | Standard default if no rule is specified.                          |
| **CASCADE**  | Updates or deletes the child rows automatically when the parent row changes.  | Use carefully—can remove large sets of data in one command.        |
| **SET NULL** | Sets the foreign key in child rows to `NULL` when the parent row changes.     | The FK column **must allow NULL**.                                 |
| **SET DEFAULT** | Sets the foreign key in child rows to its **default value**.               | The FK column must have a **DEFAULT constraint**.                  |

---

### Adding a Foreign Key with Rules

```sql
ALTER TABLE Student
ADD CONSTRAINT FK_Student_Department FOREIGN KEY (Dept_Id) REFERENCES Department(Dept_Id) ON UPDATE CASCADE ON DELETE SET NULL
```
- ON UPDATE CASCADE → If a department’s ID changes, the student rows update automatically.
- ON DELETE SET NULL → If a department is deleted, the student’s Dept_Id becomes NULL.


- Wizard Path in SQL Server (GUI)
```sql
Database Diagram
   → Relationships
      → Right Click → Properties
         → Insert & Update Specification
             → Choose actions for DELETE and UPDATE
```
This eliminates the need to write manual SQL each time.


### Examples of Each Rule

Assume:
Student.Dept_Id is a FK referencing Department.Dept_Id.

- 1️⃣ NO ACTION
```sql
-- Attempt to delete department 10 with existing students
DELETE FROM Department WHERE Dept_Id = 10;
-- ❌ Error: The DELETE statement conflicted with the REFERENCE constraint.
```

- 2️⃣ CASCADE
```sql
DELETE FROM Department WHERE Dept_Id = 10;
-- ✅ All students in Dept_Id = 10 are automatically deleted.
```

- 3️⃣ SET NULL
```sql
DELETE FROM Department WHERE Dept_Id = 10;
-- ✅ Department removed; affected students now have Dept_Id = NULL.
```

- 4️⃣ SET DEFAULT
```sql
-- Default Dept_Id is 70
DELETE FROM Department WHERE Dept_Id = 10;
-- ✅ Department removed; affected students now have Dept_Id = 70.
```

#### Self-Referencing Relationships
A table that references itself (e.g., Employee.ManagerID FK → Employee.EmpID)
usually defaults to NO ACTION in GUI tools.

To implement other actions, you must define them manually in SQL.

### Key Takeaway
Before performing UPDATE or DELETE on a parent table:
- Identify any foreign keys referencing it.
- Ensure the desired ON UPDATE/ON DELETE rules are defined to maintain data integrity.
---

## 8. User-Defined Functions (UDFs)

A **User-Defined Function (UDF)** is a reusable database object that you create to  
encapsulate logic and return a value or table.  
It behaves like a function in programming languages but runs inside SQL Server.

---

### Definition
A UDF is a **Transact-SQL routine** you write and store in the database.  
You can invoke it inside `SELECT`, `WHERE`, `JOIN`, or other T-SQL statements.

Types:
- **Scalar Function** – returns a single value.
- **Inline Table-Valued Function** – returns a table that can be queried like a view.
- **Multi-statement Table-Valued Function** – returns a table built with multiple statements.

---

### Key Advantages (from Microsoft Docs)

According to [Microsoft documentation](https://learn.microsoft.com/sql/relational-databases/user-defined-functions),
User-Defined Functions offer several benefits:

1. **Modularity & Reuse**  
   - Encapsulate business logic once and reuse it in multiple queries, views, or procedures.

2. **Maintainability**  
   - Changing logic in one function updates every query that uses it,  
     simplifying maintenance and reducing code duplication.

3. **Composability in Queries**  
   - Can be called directly in `SELECT`, `WHERE`, or `JOIN` clauses,  
     making complex expressions easier to read.

4. **Performance Improvements in Certain Scenarios**  
   - Inline table-valued functions can be optimized by the query optimizer  
     similar to views, sometimes yielding better performance than repeating subqueries.

5. **Security & Permissions**  
   - Provide a controlled interface: users can be granted permission to execute the function  
     without direct access to the underlying tables.

6. **Parameterization**  
   - Accept parameters, allowing flexible calculations or filtering inside a single definition.

---

### User-Defined Function Structure

A **User-Defined Function (UDF)** is made up of **two main parts**:

---

#### 1️⃣ Function Signature
Defines **name**, **parameters**, and **return type**.

```sql
CREATE FUNCTION [SchemaName].[FunctionName] ( @param1 datatype, @param2 datatype )
RETURNS <ReturnType>
```
- ReturnType
Scalar UDF → a single value (INT, VARCHAR, DATETIME, etc.).
Inline Table-Valued UDF → TABLE.
Multi-Statement Table-Valued UDF → @TableVariable TABLE(...) with column definitions.


Example Signatures:

-- Scalar
```sql
CREATE FUNCTION dbo.GetStudentNameById (@id INT)
RETURNS VARCHAR(30)
```

-- Inline Table-Valued
```sql
CREATE FUNCTION dbo.ActiveStudents()
RETURNS TABLE
```

#### 2️⃣ Function Body

Contains the SQL logic.
General Rules: 

- May use SELECT, JOIN, variables, and control flow (IF, WHILE).
- Cannot perform INSERT, UPDATE, or DELETE on real tables
(only allowed on local table variables defined inside the function).
- No TRY…CATCH or transactions inside UDFs.

- Variables can be declared and assigned.

Scalar Function Body
```sql
AS
BEGIN
    -- statements
    RETURN @variable   -- must return a single value
END
```

Example
```sql
GO
CREATE FUNCTION dbo.GetStudentNameById (@id INT)
RETURNS VARCHAR(30)
AS
BEGIN
    DECLARE @studentname VARCHAR(30);

    SELECT @studentname = CONCAT_WS(' ', fname, lname)
    FROM   Student
    WHERE  st_id = @id;

    RETURN @studentname;
END;

SELECT dbo.GetStudentNameById(1) -- Call
```
Note: Even if the schema is dbo, you must prefix the schema name when calling a scalar function.


Inline Table-Valued Function Body

Returns a table directly.
```sql
AS
RETURN
(
    SELECT st_id, st_fname
    FROM   Student
    WHERE  st_age > 18
)
```

Usage:
```sql
SELECT * FROM dbo.StudentsAbove18();
```
Schema prefix is optional for inline table-valued UDFs when using the default dbo.

Multi-Statement Table-Valued Function

Used when you need conditional logic or multiple inserts into a table variable.
```sql
AS
BEGIN
    DECLARE @datatable TABLE
    (
        stid INT,
        stname VARCHAR(50)
    );

    IF @Format = 'First'
        INSERT INTO @datatable
        SELECT st_id, st_fname
        FROM Student;
    ELSE IF @Format = 'Last'
        INSERT INTO @datatable
        SELECT st_id, st_lname
        FROM Student;
    ELSE IF @Format = 'Full'
        INSERT INTO @datatable
        SELECT st_id, CONCAT_WS(' ', st_fname, st_lname)
        FROM Student;

    RETURN;
END
```

Call:
```sql
SELECT * FROM dbo.GetData('Full');
```
### Maintenance & Deployment

CREATE OR ALTER FUNCTION
Creates the function if it doesn’t exist or alters it if it does:
```sql
CREATE OR ALTER FUNCTION dbo.MyFunction ...
```

ALTER
To modify an existing UDF:
```sql
ALTER FUNCTION dbo.MyFunction ...
```
- Parsing/Compilation occurs once when the function is first executed.

### Key Takeaways

- Signature = name + parameters + return type.

- Body = only read operations or operations on local table variables.

- Use scalar, inline table, or multi-statement table UDFs depending on the complexity of logic.