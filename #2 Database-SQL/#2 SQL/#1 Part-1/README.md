# Agenda
- Database Implementation
- SQL Server Service
- Server
- Comments command (single line / multiline)
- Variables
- Data Types
- SQL Server Categories
- DDL Category

---
## 1 - Database Life Cycle
- First, we started with **Design (ERD)**.  
- After creating the ERD, we did **Mapping** and came up with the **Schema**.  
- All of this was just a **visualization** of the data and information.  
- Now, we need to implement the database **physically**.  
- To do that, we need a **Database Provider** using a **Database Management System (DBMS)**.

### Example: DB Providers (Relational Databases)
- Oracle
- MySQL
- PostgreSQL
- SQL Server  

> Once you learn SQL Server, the others are almost the same, with only small syntax differences.

---

## 2 - SQL Server Service
- A **Windows service** included in the Windows packages and installed separately.  
- Provides **storage**, **processing**, and **control** for the database.  
- Must always be **running** to make the DB work.  
- Multiple **instances** of the service can exist.

### History
- In the past: connections to SQL Server were done using **CMD**, which was difficult and boring.  
- Now: we use **SQL Server Management Studio (SSMS)**, a tool to manage the server.

### Connecting to SQL Server
1. **Server Type**  
   - Select the type of service to work with.  
   - We usually work with **Database Engine** (responsible for parsing and executing queries).  

2. **Authentication**  
   - **Windows Authentication** → login with the same Windows user.  
   - **SQL Server Authentication** → login with username & password provided by the **Database Administrator**.  

3. **Server Name**  
   - If the server is your local machine → use `.` or your computer name.  
   - If the server is remote → use the **IP address** of the server.

---
## 3 - Server
- A **server** is simply a computer (like a normal PC) but with higher specifications and special configurations.  
- It is connected to the internet and has SQL Server installed on it.  

### Types of Servers
1. **Physical Server**  
   - The server hardware is owned and managed by you.  
   - Can also be configured as a **remote server**.  

2. **Virtual Server**  
   - Provided by cloud providers (e.g., **AWS**).  
   - You get a portion of a larger server shared with other clients.  
   - Less secure for **highly sensitive data** compared to physical servers.  

---

### Connecting to a Remote Server
- We use **Remote Desktop Connection** (a built-in Windows app).  

**Scenarios:**
- If I am on the **same company network** → I can connect directly using the server's IP address.  
- If I am **at home or on another network** → I need to connect via **VPN**, then authenticate with:
  - Username  
  - Password  
  - IP Address  
  - Domain  

---

### Why use Remote Desktop Connection?
- To access the **server** or the **company machine** remotely.  
- For tasks like:
  - Deployment  
  - Publishing applications  
  - Troubleshooting publishing issues  
---
## 4 - Comments
```sql
-- Single-line comment

/*
   Multi-line comment
*/

-- Comments are important to explain the code 
-- and make it easier for others to understand later.

---
## 5 - Variables
Variables are used to store values that may change.  
There are two types:

```sql
-- 1. Global Variables
-- Built-in variables in SQL Server, accessible by anyone.
-- Always start with @@
@@VERSION
@@SERVERNAME
@@LANGUAGE


-- 2. Local Variables
-- Defined by the user
DECLARE @age INT = 25;

-- Assign or update a value
SET @age = 30;


-- Printing variables
PRINT @@VERSION;
PRINT @age;

--
## Naming Conventions

```sql
-- Variable Naming Conventions in SQL:

-- 1. Pascal Case
-- First letter of every word is capitalized.
DECLARE @FirstName VARCHAR(50);

-- 2. Camel Case
-- First word starts with lowercase, 
-- then every next word starts with capital letter.
DECLARE @firstName VARCHAR(50);


-- Important Note:
-- SQL Server is NOT case sensitive.
-- So 'ahmed' is the same as 'AHMED'.
SELECT 'ahmed' AS Name;
SELECT 'AHMED' AS Name;
---
## 6 - DataTypes Categories

- **Exact Numerics**: `tinyint`, `smallint`, `int`, `bigint`, `bit`, `decimal`, `numeric`, `money`, `smallmoney`  
- **Approximate Numerics**: `float`, `real`  
- **Date and Time**: `time`, `date`, `smalldatetime`, `datetime`, `datetime2`, `datetimeoffset`  
- **Character String**: `char`, `varchar`, `varchar(max)`  
- **Unicode Character String**: `nchar`, `nvarchar`, `nvarchar(max)`  
- **Binary String**: `binary`, `varbinary`, `image`  
- **Other Data Types**: `cursor`, `geography`, `geometry`, `hierarchyid`, `json`, `rowversion`, `sql_variant`, `table`, `uniqueidentifier`, `xml`  

### Usage
- Data types are used when defining **variables** and **columns**.  

### Most Commonly Used
- `int`, `decimal`, `money`, `smallmoney`, `bit`  
- `time`, `date`, `datetime`, `smalldatetime`  
- `varchar`, `nvarchar`  
- `varbinary`  

### Note on `varchar`
- If the stored length is **less** than the defined length → no wasted space.  
- If the stored length is **greater** than the defined length → data **loss** occurs.  
---
## 7 - SQL Category

- SQL was developed and standardized by **ANSI** (American National Standard Institute).  
- Later, different companies created their own customized versions, such as:  
  - **Microsoft** → Transact-SQL (T-SQL)  
    - Called *Transact* because every query is considered a **transaction** (an action or modification).  
  - **Oracle** → PL/SQL  
  - **IBM** → IBM PL/SQL  
  - **Open Source** → MySQL 

We will focus on **Transact-SQL (T-SQL)**, which is divided into five main categories:

### 1 - DDL (Data Definition Language)
- Deals with **metadata** and **structure** of database objects.  
- Commands:  
  - `CREATE` → create a table, view, or function.  
  - `ALTER` → modify existing metadata.  
  - `DROP` → remove metadata objects.  
  - `SELECT INTO` → create a new table and insert data into it.  

**Metadata** includes:  
- Columns  
- Constraints  

---

### 2 - DML (Data Manipulation Language)
- Deals with the **data itself** (values, records, or instances).  
- Commands:  
  - `INSERT` → add a record.  
  - `UPDATE` → modify a record.  
  - `DELETE` → remove a record.  
  - `MERGE` → combine multiple records.  

---

### 3 - DCL (Data Control Language)
- Deals with **security and permissions**.  
- Used to give or restrict access for users.  
- Commands:  
  - `GRANT` → give permission.  
  - `DENY` → deny permission.  
  - `REVOKE` → remove permission.  

---

### 4 - DQL (Data Query Language)
- Used only to **query (read) data**.  
- Main command:  
  - `SELECT`  
- Can be used with:  
  - Joins  
  - Aggregate functions  
  - Grouping  
  - Union  
  - Subqueries  

---

### 5 - TCL (Transaction Control Language)
- Controls the **execution of queries** and ensures data consistency.  
- Commands:  
  - `BEGIN TRANSACTION` → start a transaction.  
  - `COMMIT` → save changes.  
  - `ROLLBACK` → undo changes if errors occur.  
---
## 8 - DDL Category

```sql
-- DDL (Data Definition Language) deals with metadata (Columns, Constraints) 
-- and structure (Table, Database, View, Function, or any object).


-- 1. CREATE
-- Create Database
CREATE DATABASE DatabaseName;

-- Create Table
CREATE TABLE TableName (
    ColumnName DataType Constraints,
    ColumnName DataType Constraints,
    ...
);


-- Common Constraints:
-- PRIMARY KEY       → defines a primary key
-- IDENTITY(start, step) → auto-increment values
-- NOT NULL          → column cannot be null (default is NULL)
-- UNIQUE            → ensures values are not duplicated
-- REFERENCES TableName(ColumnsName)       → FOREIGN KEY is REFERENCES to OtherTable
-- DEFAULT value     → set a default value



-- Notes:
-- - For composite primary key, define at the end:
PRIMARY KEY (Column1, Column2);

-- - Reserved keywords can be used as names if enclosed in brackets:
[Column] INT;

-- - Foreign key’s datatype must match the referenced primary key datatype.


## 2. ALTER

```sql
-- ALTER
-- Used to modify structure or metadata of database objects.

-- Examples:

-- 1. Rename a Database
ALTER DATABASE OldDBName 
MODIFY NAME = NewDBName;

-- 2. Add a new Column
ALTER TABLE TableName
ADD NewColumn DataType Constraints;

-- 3. Add a new Constraint
ALTER TABLE TableName
ADD CONSTRAINT ConstraintName UNIQUE (ColumnName);

-- UNIQUE -> As Example 
-- We Can Remove Constrint Namge
ALTER TABLE TableName
ADD UNIQUE (ColumnName);

-- 4. Modify an existing Column
ALTER TABLE TableName
ALTER COLUMN ColumnName NewDataType;

-- 5. Drop a Column
ALTER TABLE TableName
DROP COLUMN ColumnName;

-- 6. Drop a Constraint
ALTER TABLE TableName
DROP CONSTRAINT ConstraintName;

-- Notes:
-- - Any structure or metadata currently in use 
--   or part of a relation with another object cannot be dropped.

-- Adding a Foreign Key after the table is created:
ALTER TABLE TableName
ADD CONSTRAINT ConstraintName FOREIGN KEY (ColumnInThisTable)
REFERENCES AnotherTable(ColumnPK);

-- Without specifying a constraint name:
ALTER TABLE TableName
ADD FOREIGN KEY (ColumnInThisTable)
REFERENCES AnotherTable(ColumnPK);


## 3. DROP

```sql
-- DROP
-- Used to delete structures (metadata/objects).

-- Examples:
DROP TABLE TableName;
DROP DATABASE DatabaseName;

---- 
## Note
- These actions can also be performed using the Wizard (GUI) in SQL Server Management Studio (SSMS).


---
## Database Files

When a database is created in SQL Server, it is stored in two files:

1. **MDF (Main Database File)**  
   - Contains **metadata** and **structure**.  
   - Includes tables, columns, data types, etc.  

2. **LDF (Log Database File)**  
   - Stores all **transactions** that modify the database.  
   - Used for **recovery** and maintaining data integrity.  


