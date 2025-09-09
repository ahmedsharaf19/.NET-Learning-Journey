# Database Lecture Summary

## 📌 Agenda
1. Data Manipulation Language (DML) Category  
2. Data Query Language (DQL) Category - SELECT  
3. Joins  
4. Joins + DML  
5. Backup and Restore  
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