------------------------------------------------------------
--                 DML TRIGGERS (TABLE LEVEL)
------------------------------------------------------------
--  • DML triggers fire on INSERT, UPDATE, DELETE.
--  • They do NOT fire on SELECT or TRUNCATE.
--  • They are recorded in the transaction log (LDF).
------------------------------------------------------------

USE ITI;
GO

/*----------------------------------------------------------
  1. Welcome trigger on Student table
----------------------------------------------------------*/
-- Fires after a row is inserted and prints a welcome message.
CREATE OR ALTER TRIGGER SayWelcomToNewStudent
ON Student
WITH ENCRYPTION
AFTER INSERT
AS
    PRINT 'Welcome To ITI';
GO

-- Test:
INSERT INTO Student (St_id, St_Fname, St_Address, St_Age)
VALUES (20, 'Mona', 'Alex', 25);
INSERT INTO Student (St_id, St_Fname, St_Address, St_Age)
VALUES (21, 'Ali',  'Cairo', 30);
------------------------------------------------------------


/*----------------------------------------------------------
  2. Moving a table (and its triggers) to another schema
----------------------------------------------------------*/
CREATE SCHEMA HR;
GO

-- Move Student to schema HR (trigger moves automatically).
ALTER SCHEMA HR TRANSFER Student;
GO

-- Alter trigger to reference the new schema.
CREATE OR ALTER TRIGGER HR.SayWelcomToNewStudent
ON HR.Student
WITH ENCRYPTION
AFTER INSERT
AS
    SELECT 'Welcome To ITI';
GO

-- Move Student back to dbo.
ALTER SCHEMA dbo TRANSFER HR.Student;
GO
------------------------------------------------------------


/*----------------------------------------------------------
  3. Update audit trigger
----------------------------------------------------------*/
-- Returns the current login and timestamp after any update.
CREATE OR ALTER TRIGGER NotifyOnUpdateStudent
ON Student
WITH ENCRYPTION
AFTER UPDATE
AS
    SELECT SUSER_NAME() AS [Updated By],
           GETDATE()    AS [Updated On];
GO
------------------------------------------------------------


/*----------------------------------------------------------
  4. Prevent DELETE from Student table
----------------------------------------------------------*/
-- a) Using INSTEAD OF DELETE (best way: prevents the action).
CREATE OR ALTER TRIGGER DisableDeleteFromStudent
ON Student
WITH ENCRYPTION
INSTEAD OF DELETE
AS
    RAISERROR('You cannot delete from this table', 16, 1);
GO

-- b) Alternative: AFTER DELETE + ROLLBACK (deletes then rolls back).
--   (kept for reference; INSTEAD OF is cleaner.)
------------------------------------------------------------


/*----------------------------------------------------------
  5. Block all DML on Department table
----------------------------------------------------------*/
CREATE TRIGGER DisableDMLOnDepartment
ON Department
WITH ENCRYPTION
INSTEAD OF INSERT, UPDATE, DELETE
AS
    PRINT 'You cannot perform DML on Department table';
GO
------------------------------------------------------------


/*----------------------------------------------------------
  6. Using inserted & deleted pseudo-tables
----------------------------------------------------------*/
-- Audit UPDATE on Course: show old & new rows.
CREATE OR ALTER TRIGGER AuditOnCourse
ON Course
WITH ENCRYPTION
AFTER UPDATE
AS
    SELECT * FROM inserted;  -- new values
    SELECT * FROM deleted;   -- old values
GO
------------------------------------------------------------


/*----------------------------------------------------------
  7. Custom message when deleting from Topic
----------------------------------------------------------*/
CREATE TRIGGER DisableDeleteFromTopic
ON Topic
WITH ENCRYPTION
INSTEAD OF DELETE
AS
    SELECT CONCAT_WS(' ',
                     'You cannot delete Topic with id =',
                     (SELECT TOP_Id   FROM deleted),
                     'and name =',
                     (SELECT TOP_Name FROM deleted));
GO
------------------------------------------------------------


/*----------------------------------------------------------
  8. Prevent Course deletion on Sundays
----------------------------------------------------------*/
-- Option A: INSTEAD OF DELETE (check before delete).
CREATE TRIGGER DisableDeleteFromCourse
ON Course
WITH ENCRYPTION
INSTEAD OF DELETE
AS
    IF DATENAME(WEEKDAY, GETDATE()) != 'Sunday'
        DELETE FROM Course
        WHERE Crs_Id IN (SELECT Crs_Id FROM deleted);
    ELSE
        SELECT 'You cannot delete a course on Sunday';
GO

-- Option B: AFTER DELETE + ROLLBACK (delete then undo).
CREATE OR ALTER TRIGGER DisableDeleteFromCourse
ON Course
WITH ENCRYPTION
AFTER DELETE
AS
    IF DATENAME(WEEKDAY, GETDATE()) = 'Sunday'
    BEGIN
        ROLLBACK TRANSACTION;
        SELECT 'You cannot delete a course on Sunday';
    END;
GO
------------------------------------------------------------


------------------------------------------------------------
--                 DDL TRIGGERS
------------------------------------------------------------
--  • Fire on schema changes: CREATE, ALTER, DROP, etc.
--  • Can be scoped to DATABASE or ALL SERVER.
------------------------------------------------------------

/*----------------------------------------------------------
  9. Server-scope: notify on database creation
----------------------------------------------------------*/
CREATE TRIGGER NotifyOnDatabaseCreation
ON ALL SERVER
WITH ENCRYPTION
FOR CREATE_DATABASE
AS
    PRINT 'Database created successfully';
GO
------------------------------------------------------------


/*----------------------------------------------------------
 10. Prevent database creation for non-db_owner users
----------------------------------------------------------*/
CREATE OR ALTER TRIGGER DisableDatabaseCreation
ON ALL SERVER
WITH ENCRYPTION
FOR CREATE_DATABASE
AS
    IF IS_MEMBER('db_owner') = 0
    BEGIN
        ROLLBACK TRANSACTION;
        PRINT 'You are not the owner. Database creation denied.';
    END;
GO
------------------------------------------------------------


/*----------------------------------------------------------
 11. Database-scope: notify on table DDL
----------------------------------------------------------*/
-- Simple notification on table create.
CREATE TRIGGER NotifyOnTableCreation
ON DATABASE
WITH ENCRYPTION
FOR CREATE_TABLE
AS
    PRINT 'Table created successfully';
GO

-- Notify on create/alter/drop using event group DDL_TABLE_EVENTS.
CREATE OR ALTER TRIGGER NotifyOnTableModification
ON DATABASE
WITH ENCRYPTION
FOR DDL_TABLE_EVENTS
AS
    SELECT EVENTDATA();  -- returns XML with full details
GO
------------------------------------------------------------


/*----------------------------------------------------------
 12. Block ALTER TABLE commands
----------------------------------------------------------*/
CREATE TRIGGER DisableAlter
ON DATABASE
WITH ENCRYPTION
FOR ALTER_TABLE
AS
    ROLLBACK;
    PRINT 'You cannot modify tables';
GO
------------------------------------------------------------


/*----------------------------------------------------------
 13. LOGON trigger: limit sessions for a specific login
----------------------------------------------------------*/
CREATE TRIGGER LimitConOfLogins
ON ALL SERVER
WITH ENCRYPTION
FOR LOGON
AS
BEGIN
    IF ORIGINAL_LOGIN() = N'AhmedSharaf/ahmedsharaf'
       AND (
           SELECT COUNT(*)
           FROM sys.dm_exec_sessions
           WHERE is_user_process = 1
             AND original_login_name = N'AhmedSharaf/ahmedsharaf'
       ) > 2
    BEGIN
        ROLLBACK;  -- reject new session
    END
END;
GO
------------------------------------------------------------
