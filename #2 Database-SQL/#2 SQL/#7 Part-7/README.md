## Agenda
- Overview of database triggers  
- Types of triggers (DML, DDL, LOGON)  
---
## 1. Triggers
A **trigger** is a special kind of stored procedure that:
- **Takes no parameters.**
- **Fires automatically** in response to a specific event, acting like an event listener.

### Types of Triggers
- **DML Trigger** – Fires when a Data Manipulation Language (DML) statement occurs: `INSERT`, `UPDATE`, or `DELETE`.
- **DDL Trigger** – Fires when a Data Definition Language (DDL) statement occurs: `CREATE`, `ALTER`, `DROP`, or when a stored procedure executes actions similar to DDL.
- **LOGON Trigger** – Fires when a user logs on to the SQL Server, creating a new session.

---
## 2. DML Triggers
DML triggers execute in response to data changes.

### Basic Syntax
```sql
CREATE TRIGGER TriggerName
ON Table | View
WITH ENCRYPTION
FOR | AFTER | INSTEAD OF
AS
    -- SQL statements
```
### Notes

- A trigger can only be created on a **table or view** within the database you are currently connected to.  
- **ON** specifies the target object (table or view).  
- **FOR / AFTER**: Executes **after** the triggering event. The event (e.g., `INSERT`) runs first; if it succeeds, the trigger fires.  
- **INSTEAD OF**: Executes **instead of** the DML statement. The original operation (`INSERT`, `UPDATE`, `DELETE`) does **not** run unless you explicitly code it inside the trigger.

---

#### Triggers vs. Constraints
DML triggers can enforce:
- **Entity Integrity**  
- **Domain Integrity**  
- **Referential Integrity**

Use a DML trigger when a complex rule **cannot** be expressed with a standard SQL constraint.

---

#### Why Use DML Triggers
- Perform **cross-table checks** (e.g., ensure an address inserted in one table exists in another).  
- Enforce **custom restrictions** during `INSERT`, `UPDATE`, or `DELETE` by comparing new values to other data.  
- Evaluate **data before and after** changes.  
- Provide **customized error messages**.

---

#### Special Scenarios
- **MERGE statement**: If a `MERGE` operation performs `INSERT`, `UPDATE`, and `DELETE`, each event fires its own trigger separately.  
- **INSTEAD OF triggers on views**: Allow complex logic such as splitting a single `INSERT` into multiple tables or performing checks before allowing the operation.

---

#### Key Takeaways
- Triggers provide **automation** and complex **validation** beyond what constraints alone can enforce.  
- They run automatically, require **no parameters**, and can act **after** or **instead of** the triggering event.  
- Always test triggers carefully to avoid performance issues or unintended side effects.
---

## 2. DDL Triggers
A **DDL trigger** fires when a Data Definition Language (DDL) event occurs, such as:
- `GRANT`, `ALTER`, `DROP`, `DENY`, `REVOKE`
- Executing a **system stored procedure** that behaves like a DDL operation

### Use Cases
1. **Prevent schema changes** (e.g., disallow a user from altering a database object).
2. **Send a custom response** when specific schema changes occur.
3. **Audit schema events** and record them for tracking.

### Types of DDL Triggers
- **Server-Level**  
  - Respond to events across the entire server.  
  - Examples: `CREATE_DATABASE`, `ALTER_DATABASE`  
  - Stored in the server-level trigger files.
- **Database-Level**  
  - Respond to events within a single database.  
  - Examples: `CREATE_FUNCTION`, `ALTER_VIEW`  

> Multiple DDL triggers can be created for the **same event**.

### Events and Event Groups
- **Event**: A single DDL action (e.g., `CREATE_FUNCTION`, `ALTER_TABLE`).
- **Event Group**: A collection of related events that can be handled together.  
  - Example: `DDL_FUNCTION_EVENTS` covers `CREATE_FUNCTION`, `ALTER_FUNCTION`, and `DROP_FUNCTION`.

### Basic Syntax
```sql
CREATE TRIGGER TriggerName
ON ALL SERVER | DATABASE
WITH ENCRYPTION
FOR | AFTER <EventType | EventGroup>
AS
    -- SQL statements
```
## 3. LOGON Triggers
A LOGON trigger fires when:
- A user successfully logs on to the SQL Server.
- A new session is created after authentication.

### Typical Uses
- Control or limit the number of concurrent server sessions.
- Enforce login policies or custom security rules.

### 
```sql
CREATE TRIGGER TriggerName
ON ALL SERVER
WITH ENCRYPTION
FOR | AFTER LOGON
AS
    -- SQL statements
```
---
## DML Support Tables

### Overview
When a **DML trigger** fires, SQL Server automatically creates two special, memory-resident tables that you can query inside the trigger:

- **INSERTED** – Contains the **new** values that are being inserted or the updated values after a change.  
- **DELETED** – Contains the **old** values that were deleted or the previous values before an update.

These tables are **read-only** and exist only for the duration of the trigger’s execution.

### Common Uses
- **Compare data before and after** an operation to detect changes.  
- **Enforce complex validation rules** that go beyond standard constraints.  
- **Maintain audit logs** by capturing old and new row values.

---

## Additional Key Reminders

- **DDL triggers** can be defined at either **server** or **database** scope.  
- **Server-scope triggers** are stored with the server’s trigger definitions and can monitor events across all databases.  
- You can attach **multiple triggers** to the **same event or event group** for flexible auditing and control.
