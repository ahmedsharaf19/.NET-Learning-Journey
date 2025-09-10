## Agenda

- Functions
- Aggregate Functions
- Null Functions
- Datetime Functions
- Conversion Functions
- String Functions
- Group By

---
## 1. Functions

A **function** is a Database Object used to encapsulate a block of code that can be reused whenever needed.  
Instead of repeating the same code multiple times, we create a function and call it anywhere in our queries.

### Key Characteristics
- **Reusable**: Can be called multiple times without rewriting the logic.  
- **Maintainable**: Easy to update, since modifications are done in one place only.  

### Types of Functions

1. **Built-in Functions**  
   - Already provided by SQL.  
   - Developers just use them directly.  
   - Examples will be covered in this lecture.  

2. **User-defined Functions (UDFs)**  
   - Created by developers to implement custom logic.  
   - Two subtypes:  
     - **Scalar Function** → Returns a single value.  
     - **Table-Valued Function** → Returns a full table.  
---
## 2. Aggregate Functions

Aggregate functions are **scalar functions** that return a single value, which is not stored directly in the table but calculated from it.  

### Common Aggregate Functions
- **`COUNT()` / `COUNT_BIG()`**  
  - `COUNT()` returns an integer.  
  - `COUNT_BIG()` returns a `BIGINT`.  
  - Both are used to count rows.  

### Usage
- **`COUNT(*)`** → Counts all rows in the table.  
- **`COUNT(column)`** → Counts the number of **non-null values** in that column.  
  - Example: `COUNT(salary)` → Counts how many rows have a non-null `salary`.  

### Notes
- `COUNT()` does **not** include `NULL` values.  
- `COUNT(*)` is equivalent to `COUNT(PrimaryKeyColumn)`.  

- **`SUM(column)`**  
  - Returns the sum of numeric values in a column (except `BIT`).  
  - Ignores `NULL` values.  
  - Supports `DISTINCT` to exclude duplicates.  
    - Example: `SUM(DISTINCT salary)`  

- **`AVG(column)`**  
  - Returns the average of numeric values in a column.  
  - Ignores `NULL` values.  
  - Supports `DISTINCT`.  

- **`MAX(column)` / `MIN(column)`**  
  - `MAX()` → Returns the highest value.  
  - `MIN()` → Returns the lowest value.  
  - Works with numeric and character data (but not `BIT`).  
  - For characters:  
    - `MAX()` returns the last value in alphabetical order (e.g., `Z`).  
    - `MIN()` returns the first value in alphabetical order (e.g., `A`).  
  - If the column only has `NULL`, the result is `NULL`.  

  ---
## 3. Null Functions

Null functions are used to handle `NULL` values in SQL.  

### 1. ISNULL()
- Category: System function.  
- Checks if an expression is `NULL`.  
- If `NULL`, it replaces it with a specified value.  

**Syntax:**  
```sql
ISNULL(check_expression, replacement_value)
```

Example 1:
```sql
SELECT ISNULL(Lname, 'Not Found')
FROM Students;
```
If Lname is NULL, it will return 'Not Found'.
Example 2:
```sql
SELECT ISNULL(Lname, Fname)
FROM Students;
```
If Lname is NULL, it will return Fname.

⚠️ Note on concatenation:
When concatenating strings using +, if one value is NULL, the whole result becomes NULL.
To avoid this, use ISNULL():
```sql
SELECT Fname + ' ' + ISNULL(Lname, '')
FROM Students;
```
### 2. COALESCE()

Similar to ISNULL(), but accepts multiple arguments.
Returns the first non-null value from the list.

Example:
```sql
SELECT COALESCE(Lname, Fname, 'Unknown')
FROM Students;
```
If Lname is NULL, it will check Fname.
If both are NULL, it will return 'Unknown'.
---
## 4. Date and Time Functions

Date and time functions are used to work with dates and times in SQL.

### System Date Functions
- **`SYSDATETIME()`** → Returns the current system date and time in `DATETIME2` format.  
- **`SYSUTCDATETIME()`** → Returns the current system date and time in **UTC** (about 2 hours earlier).  
- **`GETDATE()`** → Returns the current system date and time in `DATETIME` format.  
- **`GETUTCDATE()`** → Returns the current system date and time in **UTC**.  

---

### Extracting Date Parts
- **`DATENAME(datepart, date)`** → Returns a string value for the specified part of a date.  
  - Example:  
    ```sql
    SELECT DATENAME(dayofyear, '2024-11-13');
    ```
    → Returns the day number of the year for that date.  
- **`DAY(date)`** → Returns the day number of the month.  
- **`MONTH(date)`** → Returns the month number.  
- **`YEAR(date)`** → Returns the year.  

---

### Other Date Functions
- **`EOMONTH(date)`** → Returns the last day of the month for the given date.  
- **`ISDATE(expression)`** → Checks if the value is a valid date.  
  - Returns `1` if it is a valid date, otherwise `0`.  
---
## 5. Conversion Functions

Conversion functions are used to change a value from one data type to another.  

### 1. CAST() and CONVERT()
- Both are used to convert between data types.  
- Difference:  
  - **CAST()** → Uses standard SQL syntax.  
  - **CONVERT()** → SQL Server specific, allows an extra parameter for formatting (e.g., date styles).  

**Examples:**  
```sql
SELECT CAST(GETDATE() AS VARCHAR(30));

SELECT CONVERT(VARCHAR(30), GETDATE());

SELECT CONVERT(VARCHAR(30), GETDATE(), 100);  -- Uses style 100 for date formatting
```
Style codes for CONVERT() can be found in SQL Server documentation.

### 2. PARSE()
Used mainly to convert string values into numeric or date/time types.
Requires the input string to be in a valid format.
Also supports culture settings to interpret numbers/dates based on regional format.

Syntax:
```sql
PARSE(string_value AS data_type [USING culture]) -- this sympol [] meaning that is optional
```
Examples:
```sql
SELECT PARSE('Thursday, 14 November 2024' AS DATE);  
-- Returns: 2024-11-14

SELECT PARSE('$35123' AS MONEY USING 'en-us');  
-- Returns: 35123.00
```
---
## 6. String Functions

String functions are used to manipulate and format character data in SQL.

---
### 1. CONCAT()
- Joins multiple strings together.  
- Unlike `+`, it handles `NULL` values (ignores them instead of returning `NULL`).  
- Performs implicit type conversion to string if needed.  

**Examples:**  
```sql
SELECT CONCAT('Ahmed', ' ', 'Sharaf');  
-- Returns: Ahmed Sharaf

SELECT CONCAT('Ahmed', NULL, 'Sharaf');  
-- Returns: AhmedSharaf
```

- CONCAT_WS()
Same as CONCAT() but allows specifying a separator.

Example:
```SQL
SELECT CONCAT_WS('-', 'Ahmed', 'Sharaf');  
-- Returns: Ahmed-Sharaf
```
### 2. LOWER() / UPPER()
LOWER(string) → Converts all characters to lowercase.
UPPER(string) → Converts all characters to uppercase.

### 3. LEN()
Returns the number of characters in a string.

### 4. SUBSTRING(string, start, length)
Extracts part of a string starting at a given position for a specified length.

### 5. FORMAT()
Converts numeric or datetime values into a string with a specific format.
Syntax:
```sql
FORMAT(value, pattern)
```
Examples:
```sql
SELECT FORMAT(1234567890, '##_##-##/##$##');  

SELECT FORMAT(GETDATE(), 'dd/MM/yyyy');  
```
Common Date/Time Patterns:
- d → Day (1–31)
- dd → Day with leading zero (01–31)
- ddd → Abbreviated weekday (Mon–Sun)
- dddd → Full weekday name (Monday–Sunday)

- M → Month (1–12)
- MM → Month with leading zero (01–12)
- MMM → Abbreviated month (Jan–Dec)
- MMMM → Full month name (January–December)

- yy → Two-digit year (00–99)
- yyyy → Four-digit year (1990–9999)

- hh → Hour (01–12)
- HH → Hour (00–23)
- mm → Minute (00–59)
- ss → Second (00–59)
- tt → AM/PM

### 6. ASCII() / CHAR()
ASCII(character) → Returns ASCII code of a character.
CHAR(code) → Returns character for an ASCII code.

### 7. LEFT() / RIGHT()
LEFT(string, n) → Returns the leftmost n characters.
RIGHT(string, n) → Returns the rightmost n characters.

### 8. LTRIM() / RTRIM() / TRIM()
LTRIM(string) → Removes spaces from the left.
RTRIM(string) → Removes spaces from the right.
TRIM(string) → Removes spaces from both sides.

### 9. REVERSE()
Reverses the string.

### 10. REPLACE(string, pattern, replacement)
Replaces all occurrences of a pattern in a string with another value.
---
## 7. GROUP BY

The `GROUP BY` clause is used to divide a large table into smaller groups based on one or more columns.  
It is commonly used with aggregate functions to summarize data.  

---

### Key Points
1. You **cannot** group by `*`.  
2. Grouping by a **Primary Key** does not make sense, since it is always unique → each row becomes its own group.  
3. Typically, grouping is done on a column that has repeating values.  
4. If you select columns **along with aggregate functions**, then all non-aggregated columns must appear in the `GROUP BY` clause.  

---

### Syntax
```sql
SELECT column_name, AGGREGATE_FUNCTION(column_name)
FROM table_name
GROUP BY column_name;
```
### Execution Order in SQL
1. **FROM**  
2. **WHERE**  
3. **GROUP BY**  
4. **SELECT**  
5. **HAVING**  

---

### Key Rules
- `WHERE` always comes **before** `GROUP BY`.  
- Aggregate functions **cannot** be used in `WHERE`.  
- To filter groups using aggregate functions, use **HAVING**.  
- `HAVING` can be used even if there is no `GROUP BY`.  

---

### Filtering with HAVING
```sql
SELECT Dept_Id, COUNT(*)
FROM Students
WHERE Dept_Id IS NOT NULL
GROUP BY Dept_Id
HAVING COUNT(*) > 2;
```
Returns only departments that have more than 2 students.

Important: Any aggregate function must be used with HAVING, not WHERE.
Example:
```sql
SELECT AVG(Salary)
FROM Instructor
HAVING COUNT(*) > 10;
```
→ Returns the average salary only if the number of instructors is greater than 10.

### GROUP BY with Multiple Columns
```sql
SELECT Dept_Id, St_Address, COUNT(*)
FROM Students
WHERE Dept_Id IS NOT NULL
GROUP BY Dept_Id, St_Address;
```
Groups are created first by St_Address, then subdivided by Dept_Id.

The order of columns in GROUP BY affects the grouping sequence but not the final aggregated result.

### GROUP BY with JOIN

When data from multiple tables is needed, perform the JOIN first, then apply GROUP BY.
Any column in SELECT that is not inside an aggregate function must be included in the GROUP BY.
With self-joins, include both the primary key and any columns used with aggregates.

### Partitioning vs. GROUP BY
GROUP BY → Reduces rows (one row per group).
Partitioning (OVER (PARTITION BY ...)) → Does not reduce rows, instead shows aggregate results alongside each original row.

Example:
```sql
SELECT MAX(Salary) OVER (PARTITION BY Dno) AS MaxSalaryPerDept
FROM Employee;
```

Shows the maximum salary per department next to every row of that department.
To mimic GROUP BY, use DISTINCT:
```sql
SELECT DISTINCT MAX(Salary) OVER (PARTITION BY Dno) AS MaxSalaryPerDept
FROM Employee;
```