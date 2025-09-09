# Database Lecture Summary

## 📌 Agenda
1. Data Manipulation Language (DML) Category  
2. Data Query Language (DQL) Category - SELECT  
3. Joins  
4. Joins + DML  
---
## 📝 1. Data Manipulation Language (DML)

In this category, we deal directly with the **values (records)** inside the database.  
The main operations are: INSERT → Add new records, UPDATE → Modify existing records, DELETE → Remove records.  

### 🔹 INSERT
The INSERT statement is used to add new records into a table.  

To add a single record we write:  
```sql
    INSERT INTO TableName  
    VALUES (value1, value2, value3);  
```
Here, the values must follow the same order of the table columns.  

To add multiple records at once we write them separated by commas: 
```sql 
    INSERT INTO TableName  
    VALUES  
        (value1, value2, value3),  
        (value4, value5, value6),  
        (value7, value8, value9);  
```
We can also insert into specific columns only by listing their names:
```sql  
    INSERT INTO TableName (Column1, Column2)  
    VALUES (value1, value2);  
```
⚡ Important Notes:  
If a column is not specified in the INSERT statement, it must satisfy at least one of the following conditions:  
1. It is an Identity column → generated automatically.  
2. It has a Default Value.  
3. It is a Timestamp column → automatically filled with the current time.  
4. It allows NULL values.  
5. It is a Computed column → automatically calculated.  

### 🔹 UPDATE
The `UPDATE` statement is used to modify existing values in a record.  

To update a column for **all rows**:  
```sql
UPDATE TableName
SET ColumnName = value;
```
⚠️ This will change the value for every row in that column.

To update a specific row, we use a condition:
```sql 
UPDATE TableName
SET ColumnName = value
WHERE Condition;
```
The condition usually targets the Primary Key (PK) or an Identity column, for example:
```sql
UPDATE Employees
SET Salary = 5000
WHERE ID = 4;
```
We can also update multiple columns at once:
```sql
UPDATE TableName
SET Column1 = value1, Column2 = value2
WHERE Condition;
```
To update multiple rows at once, we control the condition to match more than one record. 

For example, increase the salary by 10% for all female employees earning less than or equal to 4000:
```sql
UPDATE Employees
SET Salary = Salary + (Salary * 0.1)
WHERE Gender = 'F' AND Salary <= 4000;
```

### 🔹 DELETE
The `DELETE` statement is used to remove records from a table.  

To delete **all records** in a table:  
```sql
DELETE FROM TableName;
```
To delete a specific record, we use a condition:
```sql
DELETE FROM TableName
WHERE Condition;
```
⚡ Important Notes:

1. The condition usually targets the Primary Key (PK) or another unique column.
2. You can only delete records that do not have related data in other tables (no existing Foreign Key references).
3. If a record is referenced by another table, you must delete the relationship first (or set the FK to NULL) before deleting the record.
---
## 📝 2. Data Query Language (DQL) - SELECT

DQL is mainly about **displaying data** without changing anything in the database.  
The primary command is `SELECT`.  

Before working with a database, it is important to check its **diagram** to understand the tables and their relationships.  

---
### 🔹 Basic SELECT
To select specific columns from a table:  
```sql
SELECT ColumnName
FROM TableName;
```
To select all columns from a table, use *:
```sql
SELECT *
FROM TableName;
```
### 🔹 SELECT with Condition
To display specific records based on a condition:
```sql
SELECT ColumnName
FROM TableName
WHERE Condition;
```
### 🔹 Range Conditions
We can filter rows using range conditions:
1. With **AND**:
```sql
SELECT *
FROM TableName
WHERE Column >= MinValue AND Column <= MaxValue;
```
2. With **BETWEEN**:
```sql
SELECT *
FROM TableName
WHERE Column BETWEEN MinValue AND MaxValue;
```
3. To exclude a range, use ***NOT BETWEEN**:
```sql
SELECT *
FROM TableName
WHERE Column NOT BETWEEN MinValue AND MaxValue;
```
### 🔹 Multiple Values
If a record can match multiple values:
```sql
SELECT *
FROM TableName
WHERE Column = Value1 OR Column = Value2;
```
Or use **IN**:
```sql
SELECT *
FROM TableName
WHERE Column IN (Value1, Value2, Value3);
```
To exclude values, use **NOT IN**:
```sql
SELECT *
FROM TableName
WHERE Column NOT IN (Value1, Value2, Value3);
```
### 🔹 NULL Values
NULL is not considered a value, so normal conditions don’t work with it.
Check for null:
```sql 
SELECT *
FROM TableName
WHERE Column IS NULL;
```
Check for not null:
```sql
SELECT *
FROM TableName
WHERE Column IS NOT NULL;
```
### 🔹 Pattern Matching (LIKE with Wildcards)

The LIKE operator is used with wildcards to match patterns in text.
Wildcards:
- _ → Matches a single character.
- % → Matches zero, one, or many characters.
- [] → Matches any character within the brackets.
- [^] → Matches any character not in the brackets.
- [-] → Matches a range of characters.

Ex:
```sql
SELECT *
FROM TableName
WHERE Column LIKE '_a';
```
👉 This means the second character must be a.

### 🔹 Additional Features in SELECT
#### ✅ Remove Duplicates with DISTINCT
To display data without duplication:  
```sql
SELECT DISTINCT ColumnName
FROM TableName;
```
#### ✅ Sorting Results with ORDER BY
To return the values sorted (ascending by default):
```sql
SELECT ColumnName
FROM TableName
ORDER BY ColumnName ASC;
```
To sort in descending order:
```sql
SELECT ColumnName
FROM TableName
ORDER BY ColumnName DESC;
```
#### ✅ Multi-Column Sorting
If two rows have the same value in the first column, sorting can be based on the second column:
```sql
SELECT Column1, Column2
FROM TableName
ORDER BY Column1 ASC, Column2 DESC;
```
#### ⚡ Note on Execution Order:
When writing a query, the logical execution order is:
1. **FROM**
2. **SELECT**
3. **ORDER BY**
---
## 📝 3. Joins

`JOINS` are used with `SELECT` to display data from **multiple tables**.  
They are needed when the required information is not stored in a single table.  

⚠️ Note: Joins are **not the best in performance**, so if the needed data can be retrieved from one table, it’s better to avoid using them.  
---
### 🔹 1. Cross Join (Cartesian Product)
In a Cross Join, **every record** in the first table is combined with **every record** in the second table.  

Old Syntax:  
```sql
SELECT Emp_Name, Dept_Name
FROM Employees, Departments;
```
New Syntax:  
```sql
SELECT Emp_Name, Dept_Name
FROM Employees Cross Join Departments;
```

- This will return the Cartesian Product of the two tables.
👉 Typically, the result contains data that is not real (combinations without actual relationships).
We use it rarely, only if the business logic requires it.

### 🔹 Using Table Aliases
We can assign aliases (short names) to tables for easier reference in queries:
```sql
SELECT S.Size, C.Color
FROM Sizes S, Colors C;
```
Here:
Sizes → S .
Colors → C .
- Aliases make queries shorter and more readable, especially when dealing with multiple tables.

### 🔹 2. Inner Join
The `INNER JOIN` returns only the **matching records** between the two tables — that is, the records in the first table that have a related record in the second table.  

---

#### ✅ Old Syntax
```sql
SELECT Emp_Name, Dept_Name
FROM Employees E, Departments D
WHERE D.Id = E.Dept_Id;
```
#### ✅ New Syntax
```sql
SELECT Emp_Name, Dept_Name
FROM Employees E INNER JOIN Departments D
ON D.Id = E.Dept_Id;
```
👉 The keyword INNER is optional; you can simply write JOIN.
✅ Notes
- The join condition is usually written as: PK = FK.
- Additional filtering conditions can be applied.
- Best practice: put filtering conditions in the WHERE clause at the end.
Example with filter:
```sql
SELECT Emp_Name, Dept_Name
FROM Employees E INNER JOIN Departments D
ON D.Id = E.Dept_Id
WHERE E.Salary >= 4000;
```
### 🔹 3. Outer Join
The `OUTER JOIN` is used to return both the **matching records** and the **non-matching records** from one or both tables.  
There are 3 types:  
---

#### ✅ 1. Left Outer Join
Returns all records from the **left table**, and the matching records from the right table.  
If there is no match, `NULL` will appear for the right table’s columns.  

```sql
SELECT Emp_Name, Dept_Name
FROM Departments D LEFT OUTER JOIN Employees E
ON D.Id = E.Dept_Id;
```
👉 The keyword OUTER is optional:
```sql
SELECT Emp_Name, Dept_Name
FROM Departments D LEFT JOIN Employees E
ON D.Id = E.Dept_Id;
```
#### ✅ 2. Right Outer Join
Returns all records from the right table, and the matching records from the left table.
If there is no match, NULL will appear for the left table’s columns.
```sql
SELECT Emp_Name, Dept_Name
FROM Departments D RIGHT OUTER JOIN Employees E
ON D.Id = E.Dept_Id;
```
👉 The keyword OUTER is optional:
```sql
SELECT Emp_Name, Dept_Name
FROM Departments D RIGHT JOIN Employees E
ON D.Id = E.Dept_Id;
```
#### ✅ 3. Full Outer Join
Returns all records from both tables, whether they match or not.
Unmatched records will show NULL in the corresponding columns.
```sql
SELECT Emp_Name, Dept_Name
FROM Departments D FULL OUTER JOIN Employees E
ON D.Id = E.Dept_Id;
```
#### ⚡ Notes:
The order of tables matters in LEFT and RIGHT OUTER JOIN.
The order also matters in multi-table joins.

### 🔹 4. Self Join
A `SELF JOIN` is when a table is joined with itself.  
This is typically used to represent a **self-relationship** inside the same table.  
We treat the same table as if it were two separate tables by giving each one an **alias**.  
---
#### ✅ Example 1: Employees with their Managers
```sql
SELECT Emp.*, Manager.Emp_Name
FROM Employees Manager JOIN Employees Emp
ON Manager.Id = Emp.Manager_Id;
```
Here, the Employees table is used twice:
Manager alias → represents the manager .
Emp alias → represents the employee .

##### ✅ Example 2: Students with or without Supervisors
A SELF JOIN can be done with either INNER JOIN or OUTER JOIN.
Using LEFT JOIN to include students with no supervisors:
```sql
SELECT Std.*, Supervisor.St_FName
FROM Student Std LEFT JOIN Student Supervisor
ON Supervisor.St_Id = Std.St_Supervisor;
```
#### ⚡ Notes:
A SELF JOIN is useful for hierarchical data like employees and managers, or students and supervisors.
Works with INNER, LEFT, RIGHT, or FULL OUTER JOIN.


### 🔹 5. Multi-Table Join
A `Multi-Table Join` is used when we need information from more than two tables.  
This usually happens in a **many-to-many (M:M) relationship** that was converted into two **one-to-many (1:M)** relationships using a linking table.  

---
#### ✅ Example 1: Employees, Projects, and EmployeeProjects
```sql
SELECT Emp.Emp_Name, Proj.PName, EmpPro.Hours
FROM Employees Emp, Projects Pro, EmployeeProjects EmpPro
WHERE Emp.Id = EmpPro.Emp_Id AND Pro.Pnum = EmpPro.Project_Num;
```
#### ✅ Example 2: Using Virtual Table with INNER JOIN
```sql
SELECT Std.St_FName, Crs.Crs_Name, StdCrs.Grade
FROM Student Std INNER JOIN Std_Course StdCrs
ON Std.St_Id = StdCrs.St_Id
INNER JOIN Course Crs
ON Crs.Crs_Id = StdCrs.Crs_Id;
```
#### ✅ Outer Joins in Multi-Table Join
We can use LEFT or RIGHT OUTER JOIN in multi-table joins.
👉 Here, the order of tables matters and becomes very important.

---
### 🔹 Summary of Joins

- Joins are used when retrieving data from multiple tables.
- The join condition is almost always (PK = FK).

#### Types of Joins:

- Cross Join → Cartesian product (rarely used, unless required by business).
- Inner Join → Only matching records.
- Outer Join → Matching + non-matching (Left, Right, Full).
- Self Join → Joining a table with itself.
- Multi-Table Join → Joining 3+ tables, often for M:M relationships.
---
### 🔹 4. Joins + DML

Sometimes we need to **update** or **delete** records that depend on data from multiple tables.  
The trick is to first **think in terms of a SELECT with JOIN**, then convert it to `UPDATE` or `DELETE`.  
---

#### ✅ 1. UPDATE with JOIN
Suppose we want to increase the grade by 10 for all students living in **Cairo**.  

First, we would select them:
```sql
SELECT *
FROM Student Std
WHERE Std.st_address = 'Cairo';
```
Now, we modify it into an UPDATE with JOIN:
```sql
UPDATE Std_Crs
SET Grade = Grade + 10
FROM Student Std JOIN Std_Course Std_Crs
ON Std.st_id = Std_Crs.st_id
WHERE Std.st_address = 'Cairo';
```

#### ✅ 2. DELETE with JOIN
Suppose we want to delete all course records for students older than 28 years.
```sql
DELETE Std_Crs
FROM Student Std JOIN Std_Course Std_Crs
ON Std.st_id = Std_Crs.st_id
WHERE Std.st_age > 28;
```
#### ⚡ Notes:
- Always start by writing the SELECT to confirm which rows will be affected.
- Then carefully convert it to UPDATE or DELETE.
- Be extra cautious: a missing WHERE will affect all rows.