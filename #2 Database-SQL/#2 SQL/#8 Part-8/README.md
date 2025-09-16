## Agenda
- **Index**  
- **Indexed View**  
- **TCL (Transaction Control Language)**  
- **DCL (Data Control Language)**  
---
## 1. Index
An **index** in SQL Server is similar to a book index: it speeds up **data access and retrieval**.

- **Storage Basics**: Data is stored in 8 KB **pages**.  
- When you create an index, SQL Server builds a **B-Tree** structure and keeps it in memory.  
- During a query, the engine checks whether a column has an index:
  - **If yes** → it searches the B-Tree (fast).
  - **If no** → it scans the table row by row (slow).

### Checking Existing Indexes
You can view all indexes in the `master` database’s catalog view:
```sql
SELECT *
FROM sys.indexes
WHERE object_id = OBJECT_ID('YourTableName');
```

### 1.1 Clustered Index
**Definition**: Physically reorders the table rows on disk and in memory based on the indexed column.
**One per table**: A table can have only one clustered index.
**Primary Key**: By default, a primary key automatically creates a clustered index (unless you override it).
**Manual Creation**: You can drop the default and create your own.

#### Advantages: 
- Very fast for range queries and ordered retrieval.
#### Drawbacks:
- INSERT and UPDATE operations can be slower because data must remain in physical order.
- When a page fills, SQL Server splits it and reorders data, which can be expensive.
- Fill Factor : To reduce page splits, you can set a fill factor (e.g., 70%) so each page leaves free space for future inserts.

### 1.2 Non-Clustered Index

**Definition**: Creates a separate B-Tree that does not affect the physical order of the table.
- Leaf nodes contain pointers to the actual data rows (either in the clustered index or the base table).
**Performance**: Slightly slower than a clustered index but much faster than a full table scan.

#### Key Facts
- Up to 999 non-clustered indexes can exist on a single table.
- INSERT and UPDATE are generally faster than on a clustered index because the base table order remains unchanged.
---
### Summary
- Use a clustered index when you need sorted data and frequent range queries.
- Use non-clustered indexes for additional searchable columns without altering the table’s physical order.
---

### Syntax
#### Clustered Index
```sql
CREATE CLUSTERED INDEX IndexName
ON TableName (ColumnName);
```
#### Non-Unique, Non-Clustered Index
```sql
CREATE INDEX IndexName
ON TableName (ColumnName);
```
#### Unique Non-Clustered Index
```sql
CREATE UNIQUE INDEX IndexName
ON TableName (ColumnName);
```
- Note: The column(s) must contain unique values, otherwise SQL Server will return an error.

#### Unique Clustered Index
```sql
CREATE UNIQUE CLUSTERED INDEX IndexName
ON TableName (ColumnName);
```
- A table can have only one clustered index, so you must ensure no other clustered index exists.

### Using the Wizard (GUI)

1. Right-click the table → Design.
2. Right-click in the design area → Indexes/Keys.
3. Configure the index type, columns, and options.

### Choosing Columns for Indexing

- Consult the Business Team:
Ask which columns are most frequently used in search or filtering operations.

- Trace and Analyze:
Use SQL Server Profiler to capture real query activity.
Feed the trace into the Database Engine Tuning Advisor to identify columns and queries that would benefit from indexing.

**Best Practice**:
Always balance the performance gains of faster reads with the maintenance cost of slower writes (INSERT, UPDATE, DELETE) when deciding which columns to index.
---

## 2. Indexed View

An **indexed view** is a SQL Server view that has a **physical index** built on it.  
Unlike a regular view (which is a saved query and recalculates its result every time you query it),  
an indexed view **stores the result set on disk**. This can significantly **improve performance**  
for complex aggregations or joins.

---

### Why Use an Indexed View
- Speeds up queries that repeatedly aggregate or join large tables.
- Provides a pre-computed, persisted result set.
- Reduces I/O because the data is stored and maintained automatically.

---

### Requirements to Create an Indexed View
Before you can create an index on a view, the view itself must meet **strict conditions**:

1. **Schema Binding**  
   - The view must be created **WITH SCHEMABINDING**.  
   - This ensures that underlying tables cannot be altered in ways that would invalidate the view.

2. **Deterministic Expressions**  
   - All functions and expressions inside the view must be deterministic (always return the same result for the same input).  
   - For example, you cannot use `GETDATE()` or `NEWID()`.

3. **Object Ownership**  
   - All referenced tables must be in the **same database** and have the same owner.

4. **Unique Clustered Index First**  
   - The **first index** on an indexed view **must be a unique clustered index**.  
   - After that, you can create **additional non-clustered indexes**.

5. **Other Restrictions**  
   - The view cannot use `TOP`, `DISTINCT`, `ORDER BY`, `UNION`, `TEXT/IMAGE` columns, or other disallowed features.
   - All referenced tables must be **two-part named** (e.g., `dbo.TableName`).

---

### Syntax

**Step 1 – Create the View with Schema Binding**
```sql
CREATE VIEW dbo.SalesSummary
WITH SCHEMABINDING
AS
    SELECT
        s.CustomerID,
        SUM(s.TotalAmount) AS TotalSales
    FROM dbo.Sales AS s
    GROUP BY s.CustomerID;
```
**Step 2 – Create the Unique Clustered Index**
```sql
CREATE UNIQUE CLUSTERED INDEX IX_SalesSummary
ON dbo.SalesSummary (CustomerID);
```
- The unique clustered index physically stores the view’s data and allows it to behave like a materialized table.
**Step 3 – (Optional) Create Additional Non-Clustered Indexes**
```sql
CREATE NONCLUSTERED INDEX IX_SalesSummary_TotalSales
ON dbo.SalesSummary (TotalSales);
```

- Key Points
1. You cannot create a non-clustered index on a view until a unique clustered index exists.
2. The unique clustered index guarantees that each row in the view is uniquely identifiable and can be maintained efficiently.
---
## 3. TCL – Transaction Control Language

**TCL** commands manage the changes made by **DML statements** (e.g., `INSERT`, `UPDATE`, `DELETE`) and control the logical units of work known as **transactions**.

---

### Types of Transactions

#### 1. Implicit Transactions
- SQL Server automatically treats each individual `INSERT`, `UPDATE`, or `DELETE` as a **single transaction**.
- If the statement succeeds, it is **automatically committed**.
- If it fails, it is automatically rolled back.

Example:
```sql
UPDATE Products
SET Price = Price * 1.10
WHERE CategoryID = 3;
-- This runs as one implicit transaction.
```
#### 2. Explicit Transactions

An **explicit transaction** is one where the **developer manually defines** the start and end of the transaction.  
Use this approach when **multiple SQL statements must succeed or fail together** as a single logical unit.

### Key Commands
- **`BEGIN TRANSACTION`** – Marks the **start** of the transaction.
- **`COMMIT TRANSACTION`** – **Saves** all changes made during the transaction permanently.
- **`ROLLBACK TRANSACTION`** – **Undoes** all changes since the last `BEGIN TRANSACTION` (or to a defined `SAVEPOINT`).

### Example
```sql

BEGIN TRANSACTION;

-- Multiple DML operations
UPDATE Orders
SET Status = 'Shipped'
WHERE OrderID = 1001;

INSERT INTO ShippingLog (OrderID, ShipDate)
VALUES (1001, GETDATE());

-- If an error occurs, roll back all changes
IF @@ERROR <> 0
    ROLLBACK TRANSACTION;
ELSE
    COMMIT TRANSACTION;
```
- Explanation:

Both the **UPDATE** and the **INSERT** will be committed only if both succeed.
If any statement fails, ROLLBACK TRANSACTION ensures that no partial changes remain.
---
## 4. DCL – Data Control Language

**DCL** commands manage **security and permissions** in SQL Server.  
Typical commands include:

- **`GRANT`** – Give a user permission to perform specific actions.
- **`DENY`** – Explicitly block a user from performing specific actions.
- **`REVOKE`** – Remove previously granted or denied permissions.

---

### Steps to Create a User and Assign Permissions

#### 1. Create a Server-Level Login
A login provides **server-level access**.

**T-SQL**
```sql
CREATE LOGIN LoginName
WITH PASSWORD = 'StrongPassword123!';
```
**Wizard (GUI)**:
Object Explorer → Server → Security → Logins → Right-click → New Login

#### 2. Create a Database User for the Login
Map the server login to a specific database.

**T-SQL**
```sql
CREATE USER UserName
FOR LOGIN LoginName;
```
**Wizard**:
Database → Security → Users → Right-click → New User

#### 3. Grant or Deny Access to Objects
Assign permissions at the schema or table level.

**Wizard**:
Database → Security → Schemas → Right-click → Properties → Permissions

- Grant – Give the selected permission.
- Deny – Explicitly prevent the permission.
- With Grant Option – Allow the user to grant the same permission to others.

#### Granting Permissions on a Specific Table (T-SQL)

- Grant a Permission
```sql
GRANT SELECT
ON HR.Employee
TO Sharaf;
```
This allows user Sharaf to run SELECT queries on the HR.Employee table.

- Revoke a Permission
```sql
REVOKE SELECT
ON HR.Employee
FROM Sharaf;
```
Removes the previously granted SELECT permission.

#### Tip:
- GRANT gives a permission.
- DENY blocks it explicitly.
- REVOKE removes either a GRANT or DENY.

**Use these commands carefully to maintain proper database security.**