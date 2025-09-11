## Agenda
- Subqueries  
- TOP Clause  
- Random Selection  
- Ranking Functions

---
## 1. Subqueries

A **subquery** is a query nested inside another query.  
The output of the inner query is used as the input for the outer query.

### Key Points
- A subquery must contain at least:
  - `SELECT`
  - `FROM`
- It can also include `WHERE`, `HAVING`, `GROUP BY`, or other clauses.
- Subqueries can be used inside:
  - `SELECT`
  - `FROM`
  - `WHERE`
- If the same result can be achieved with a `JOIN` or another method, that is usually preferred for performance.

### Example: Using a Subquery in `WHERE`
❌ **Incorrect** (cannot use an aggregate directly in `WHERE`):
```sql
SELECT St_id, St_Fname, St_Age
FROM Student
WHERE St_Age > AVG(St_Age);
```
❌ Also incorrect to move the aggregate to HAVING without grouping:
```sql
SELECT St_id, St_Fname, St_Age
FROM Student
HAVING St_Age > AVG(St_Age);
```
✅ Correct: Use a subquery to calculate the average first:
```sql
SELECT St_id, St_Fname, St_Age
FROM Student
WHERE St_Age > (
    SELECT AVG(St_Age)
    FROM Student
)
```
The inner query runs first, returning a single value (AVG(St_Age)).
The outer query then compares each student's age to that value.

Example: Subquery in FROM
When using a subquery in the FROM clause, you must assign an alias to its result set:
```sql
SELECT Ins_Id, Ins_Name
FROM (
    SELECT Ins_Id, Ins_Name, Salary
    FROM Instructor
    ORDER BY Salary DESC
) AS HighestSalary
ORDER BY Salary ASC;
```

### Important Note on Aggregates
When selecting non-aggregated columns alongside aggregate functions, you must use GROUP BY on those non-aggregated columns.

- Aggregates and GROUP BY
- When selecting non-aggregated columns alongside aggregates, you **must use `GROUP BY`**.

❌ **Incorrect**
```sql
SELECT St_id, COUNT(*)
FROM Student;
```
✅ Correct
```sql
SELECT St_id, COUNT(*)
FROM Student
GROUP BY St_id;
```
#### Get Departments That Have Students

Join Method:
```sql
SELECT DISTINCT D.Dept_Name
FROM Department D
JOIN Student S ON D.Dept_Id = S.Dept_Id;
```

Subquery Method:
```sql
SELECT Dept_Name
FROM Department
WHERE Dept_Id IN (
    SELECT DISTINCT Dept_Id
    FROM Student
    WHERE Dept_Id IS NOT NULL
)
```
#### Show Total Student Count Beside Each Student
- Step 1 – Stand-alone Count
```sql
SELECT COUNT(*)
FROM Student;
-- Returns 19
```

- Step 2 – Add Static Value
```sql
SELECT St_id, 19
FROM Student;
```

- Dynamic Using Subquery
```sql
SELECT St_id,
       (SELECT COUNT(*) FROM Student) AS TotalStudents
FROM Student;
```
#### Delete Grades of Students Living in Mansoura

Use IN to handle multiple matches:
```sql
DELETE
FROM Std_Course
WHERE St_id IN (
    SELECT St_id
    FROM Student
    WHERE St_Address = 'Mansoura'
)
```
---
## 2. TOP Clause

The **TOP** clause is not a function—it’s a **class/keyword** used to limit the number of rows returned by a query.

## Syntax
```sql
SELECT TOP (n) column_list
FROM table_name
[ORDER BY ...];
```
n can be:
A constant value (e.g., TOP(5)).
A variable or parameter.
It specifies the number of rows to return.
TOP is written immediately after SELECT and before the column list.
-TOP (n) PERCENT
Returns the top n% of rows based on the total row count.
```sql
SELECT TOP (10) PERCENT column_list
FROM table_name
ORDER BY column_name DESC;
```
Example: Highest Salary

Get the ID and Name of the instructor with the highest salary:
```sql
SELECT TOP (1) Ins_Id, Ins_Name
FROM Instructor
ORDER BY Salary DESC;
```
ORDER BY is required to ensure you get the highest value.

#### WITH TIES
WITH TIES includes additional rows with the same ordering value as the last row selected.
ORDER BY is mandatory.
Example: 
If you ask for TOP(2) WITH TIES on a table where the ordered column has duplicate values, all matching rows are returned:
```sql
SELECT TOP (7) WITH TIES St_Age
FROM Student
WHERE St_Age IS NOT NULL
ORDER BY St_Age DESC;
```
If the top 7 include ties (e.g., multiple students sharing the same 7th-highest age), all tied rows are included.

#### Key Points

- Always use ORDER BY to get predictable results.
- WITH TIES ensures no rows with the same ordered value are left out.
---
## 3. Random Selection

### 1. NEWID()
- `NEWID()` generates a **Globally Unique Identifier (GUID)**.
- Format: **36 characters** divided as `8-4-4-4-12` (e.g., `550e8400-e29b-41d4-a716-446655440000`).
- Each call returns a value that will **never repeat**.
- Commonly used to create unique primary keys or as a default value for `uniqueidentifier` columns.

### Random Selection with NEWID()
You can leverage the randomness of `NEWID()` to return rows in a **random order**:
```sql
SELECT St_id, St_Fname, St_Age
FROM Student
ORDER BY NEWID();
```
Every execution returns the rows in a different random order.

- NEWSEQUENTIALID()
Similar to NEWID() but generates sequential GUIDs.
Useful for IDs because it avoids random page splits in indexes.
Not used in SELECT queries.
Typically applied as a default value when defining a column:
```sql
CREATE TABLE MyTable (
    MyID uniqueidentifier DEFAULT NEWSEQUENTIALID() PRIMARY KEY,
    ...
)
```
#### Key Notes
- Use NEWID() when you need randomness (e.g., random row selection or shuffling).
- Use NEWSEQUENTIALID() for auto-generated keys where order matters but uniqueness is still required.
---

## 4.Ranking Functions

Ranking functions assign a **rank value** to each row in a result set.  
Rows with the same ordering value may share the same rank, depending on the function.

All ranking functions must be used with an **`OVER()`** clause and **require `ORDER BY`** inside the window.

---
### 1. ROW_NUMBER()
- Assigns a **unique sequential number** to each row.
- No duplicates or gaps.
- Purely for simple row numbering.

```sql
SELECT Ename, Did,
       ROW_NUMBER() OVER (ORDER BY Salary DESC) AS [Row Number]
FROM Employees;
```
### 2. RANK()
Assigns a sequential rank.
Rows with the same ordering value receive the same rank.
Gaps appear when ranks are repeated.
Example of ranks: 1, 2, 2, 4

```sql
SELECT Ename, Salary,
       RANK() OVER (ORDER BY Salary DESC) AS [Rank]
FROM Employees;
```
### 3. DENSE_RANK()
Similar to RANK() but no gaps.
Rows with the same ordering value share the same rank, but the next rank is consecutive.
Example of ranks: 1, 2, 2, 3, 3, 4
```sql
SELECT Ename, Salary,
       DENSE_RANK() OVER (ORDER BY Salary DESC) AS [Dense Rank]
FROM Employees;
```

### 4. NTILE(N)
Divides the ordered result set into N groups (tiles).
Useful for data paging or evenly distributing rows.
```sql
SELECT Ins_Id, Ins_Name, Salary,
       NTILE(3) OVER (ORDER BY Salary DESC) AS GroupNum
FROM Instructor;
```
This divides the rows into 3 groups of nearly equal size and numbers each group starting at 1.
Partitioning with Ranking.
You can reset the ranking within each partition:
```sql
SELECT Ename, Salary, Did,
       ROW_NUMBER() OVER (
           PARTITION BY Did
           ORDER BY Salary DESC
       ) AS [Row Number]
FROM Employees;
```
Each department (Did) is treated separately.
Ranking restarts from 1 for every partition.

###  Key Notes

- ORDER BY is mandatory inside the OVER() clause.
- Choose the ranking function based on whether you need gaps (RANK) or no gaps (DENSE_RANK).
- ROW_NUMBER is ideal when each row must have a unique sequence number.
- NTILE is perfect for paging or dividing data into equal-sized buckets.
