------------- Trigger -------------------
-- ##########################################
---------- DML Triggers -----------------
-- Trigger Fire when event occurred in Table | View
-- Event (Not Select Or Truncat - NOT LOGGED IN LDF)
-- 1. Insert 
-- 2. Update
-- 3. Delete 
------------------------------------------
-- Welecom Trigger In Table Student
------------------------------------------

Use ITI

Insert Into Student(St_id, St_Fname, St_Address, St_Age)
Values (20, 'Mona', 'Alex', 25)

Go
Create Or Alter Trigger SayWelcomToNewStudent
On Student
With Encryption
After Insert
As 
	Print 'Welcom To ITI'
Go
-- This Trigger Fire When Insert In Table Student

Insert Into Student(St_id, St_Fname, St_Address, St_Age)
Values (21, 'Ali', 'Cairo', 30)
-- Trigger Fired Then Print 'Welcom To ITI'

------------------------------------------
-- Transfer Table To Another Schema
------------------------------------------
-- Trigger in the same schema of the table 
-- We Can Move Table This Action Will Also Move Trigger Automatically
GO
Create Schema HR
GO

Alter Schema HR
Transfer Student

------------------------------------------
-- Alter Trigger
------------------------------------------
Go
Create Or Alter Trigger SayWelcomToNewStudent
On HR.Student
With Encryption
After Insert
As 
	Select 'Welecom To ITI'
Go

/*
Msg 2714, Level 16, State 2, Procedure SayWelcomToNewStudent, Line 1 [Batch Start Line 46]
There is already an object named 'SayWelcomToNewStudent' in the database.
*/
-- لازم احددله اني هعدل على ال trigger اللى ف الاسكيما الفلانيه
Go
Create Or Alter Trigger HR.SayWelcomToNewStudent
On HR.Student
With Encryption
After Insert
As 
	Select 'Welecom To ITI'
Go

Insert Into HR.Student(St_id, St_Fname, St_Address, St_Age)
Values (22, 'Omar', 'Alex', 20)

Alter Schema dbo
Transfer HR.Student

---------------------------------------------------------
-- When An Update On Table Student Occurred Return Time Of Modification And User
---------------------------------------------------------
update Student 
Set St_Address = 'Cairo'
Where St_Id = 22

Go
Create Or Alter Trigger NotifyOnUpdateStudent
On Student
With Encryption
After Update  
As 
	Select SUSER_NAME()[Updated By], GETDATE() [Updated On] -- Return Logined Cuurent User 
Go

update Student 
Set St_Address = 'Alex'
Where St_Id = 22

------------------------------------
-- Prevent Delete From table student
------------------------------------
-- Instead Of (Prevent Action Replcae)
Delete From Student
Where St_Id = 22

/* بمنع اي حد انه يعمل حذف من الجدول دا */
Go
Create Trigger DisableDeleteFromStudent
On Student
With Encryption
Instead Of Delete
As
	print 'You Can''t Delete From This Table'
Go

Delete From Student
Where St_Id = 21

/*
(1 row affected)  -> مقصدو ان ف transaction كان المفروض باثر على row واحد 
هي فشلت بس خزنها بردوا ف LDF
*/


Go
Create Or Alter Trigger DisableDeleteFromStudent
On Student
With Encryption
For Delete
As
	print 'You Can''t Delete From This Table'
	ROLLBACK Transaction -- يعني هسيبه يمسح وبعدين ارجع ف كلامى واخليه يرجع ال TRANSACTION
	-- ال INSTEAD OF افضل ف الحاله دي 
Go

-----------------------------------------------
-- Raise ERROR 
-----------------------------------------------

Go
Create Or Alter Trigger DisableDeleteFromStudent
On Student
With Encryption
Instead Of Delete 
AS 
	RAISERROR('You Can''t Delete From This Table', 15, 1) 
Go

/*
{Msg_ID fROM sYSTEM | Msg_String | @localVar Contain Error Msg}, 
severity قوة ال  error مصيبه ولا عادري  (Security Level) اهمية الايرور دا اى
level from 19 - 25, must use with log يخزن الايرور دي ف ال log
اى severity من الصفر هيتعامل معاه على انه صفر
واى واحد اكبر من 25 كانه 25

from 0 to 18 -> Warning
From 19 to 25 -> With Log Error
From 20 To 25 -> Fetal Error يقدر يقفل ال connection


State   -> number from 0 to 255
any negative value == 1 
any greater value from 255 (can't use)

علشان لما يجيي state اعرف انا ف انهى مكان 
*/

Delete From Student
Where St_Id = 21

Go
Create Or Alter Trigger DisableDeleteFromStudent
On Student
With Encryption
Instead Of Delete 
AS 
	RAISERROR('You Can''t Delete From This Table', 19, 1)  With LOG
Go

Delete From Student
Where St_Id = 21


Go
Create Or Alter Trigger DisableDeleteFromStudent
On Student
With Encryption
Instead Of Delete 
AS 
	RAISERROR('You Can''t Delete From This Table', 21, 1)  With LOG
Go

Delete From Student
Where St_Id = 21


--------------------------------------------------
-- Prevent Insret, Update, Delete From Department
--------------------------------------------------
GO
Create Trigger DisableDMLOnDepartment
On Department
With Encryption
Instead Of Delete, Update, Insert
As
	Print 'You Can''t Do Any DML Commands On Department Table'
GO

Delete From Department
Where Dept_Id = 10

Insert Into Department(Dept_Id, Dept_Name)
Values (80, 'HR')

Update Department
Set Dept_Name = 'HR'
Where Dept_Id = 70

---------------------------------------------------
-- Drop Trigger Or Disable Trigger
---------------------------------------------------
Drop Trigger DisableDMLOnDepartment  



-- Wayes Disable 
-- 1. 
Alter Table Department
Disable Trigger DisableDMLOnDepartment

-- Now Can Insert 
Insert Into Department(Dept_Id, Dept_Name)
Values (80, 'HR')

-- Enable Trigger
Alter Table Department
Enable Trigger DisableDMLOnDepartment


-- 2. Right Click Of Trigger And Disable/Enable

--3. 
Disable Trigger DisableDMLOnDepartment
On Department

-- Enable
Enable Trigger DisableDMLOnDepartment
On Department

/*
بنستخدم ال Drop لو عايز اعمل instead of حاجه غير اللى كنت عاملها فلازم احذفه
*/
-- 1. Alter Trigger      2. Drop Trigger 

/*
ه check ان ال onbject موجود ولا لا ولو موجود احذه
*/

SELECT OBJECT_ID('DisableDMLOnDepartment')

If OBJECT_ID('DisableDMLOnDepartment') is not null
Drop Trigger DisableDMLOnDepartment


-------------------------------------
-- Inserted And Deleted 
-------------------------------------
--بيتنشاو لما التريجر يفاير ويتحذفو بعدها على طول 

-- Audit Update On Table Course 

Go
Create Or Alter Trigger AuditOnCourse
On Course
With Encryption
After Update
As 
	Select * From inserted
	Select * From deleted
Go

Update Course
Set Crs_Name = 'C#'
Where Crs_Id = 100

----------------------------------------------
-- Prevent Delete On Table Topic
-- And Display Message For User That He/She Can Not Delete This Topic
-- Message => 'You Can''t Delete Topic With id = {} and name = {}'
----------------------------------------------
/*
هستخدم الجدول deleted اجيب منه id, name للى كان هيتحذف
*/
Go
Create Trigger DisableDeleteFromTopic
On Topic
With Encryption
Instead Of Delete
As
	Select CONCAT_WS(' ', 'You Can''t Delete Topic With id =', (Select Top_Id From deleted) ,'and name =', (Select Top_Name From deleted))
Go

Delete From Topic
Where Top_Id = 1


-----------------------------------------------------
-- Prevent Delete From Table Course If Day Is Sunday
-----------------------------------------------------
/*
After Delete 
اقدر استخدمها احذف وبعدين اعمل check لو يوم الاحدي ارجع ف العمليه

instead of 
اقوله check الاول لو انهارده الاحد متحذفش غير كدا احذف
*/

/*
ال statment اللى جوه ال trigger مش بتنادى ال trigger
*/

-- 1. Instead OF
Go
Create Trigger DisableDeleteFromCourse
On Course
With Encryption
INSTEAD OF Delete
As
	IF (DATENAME(WEEKDAY, GETDATE()) != 'Sunday')
		Delete From Course
		Where Crs_Id in (Select Crs_Id From deleted)
	ELSE
		Select 'You Can''t Delete Course On Sunday'
Go

Delete From Course
Where Crs_Id = 1400

-- 2. After
Go
Create Or Alter Trigger DisableDeleteFromCourse
On Course
With Encryption
After Delete
As
	IF (DATENAME(WEEKDAY, GETDATE()) = 'Sunday')
		Begin
			ROLLBACK Transaction
			Select 'You Can''t Delete Course On Sunday'
		End
Go

Delete From Course
Where Crs_Id = 1400


---------------------- DDL Trigger ---------------
-- Database / Server Scope
-- Events [Create, Alter, Drop]
--------------------------------------------------

-------------------------------------------------
-- Database Created Successfully After Creation
-------------------------------------------------
Create Database Test

GO
Create Trigger NotifiyOnDatabaseCreation
On All Server
With Encryption
For CREATE_DATABASE
As 
	Print 'Database Is Created Successfully'
Go

Create Database Test1

-------------------------------------------------------------
-- Prevent Database Creation For All Member Except db_owner
-------------------------------------------------------------

/*
IS_MEMBER(group, role)

0 -> Current user isn't a member of group or role
1 -> Current user is a member of group or role
NULL -> Either Group or role isn't valid. when queried by a SQL server login or a login role, returns NULL for a Windows Group
*/
Go
Create Trigger DisableDatabaseCreation
On All Server
With Encryption
For CREATE_DATABASE
As
	IF IS_MEMBER('db_owner') = 0 -- if currnet user is db_owner return 1
		BEGIN
			ROLLBACK TRANSACTION
			Print 'You Are''t The Owner, Go Out'
		END

Go

Create Database Test2

Go
Create or Alter Trigger DisableDatabaseCreation
On All Server
With Encryption
For CREATE_DATABASE
As
	IF IS_MEMBER('db_owner') = 1 -- if currnet user is db_owner return 1
		BEGIN
			ROLLBACK TRANSACTION
			Print 'You Are''t The Owner, Go Out'
		END

Go

Create Database Test3


--------------------------------------------------------------
-- Database Object [Table, Function, View ...) -- Database Scope
-- Events [Create - Alter - Drop]
--------------------------------------------------------------

--------------------------------------------------------
-- Table Created Successfully After Creation
--------------------------------------------------------
Go
Create Trigger NotifiyOnTableCreation
On Database
With Encryption
For CREATE_TABLE
AS
	Print 'Table Is Created Successfully'
Go

Create Table NewTable
(Id int Primary Key, 
Test VarChar(20))

--------------------------------------------------------
-- Modified Successfully after any modification on table
--------------------------------------------------------
Go
Create Or Alter Trigger NotifiyOnTableCreation
On Database
With Encryption
For CREATE_TABLE, ALTER_TABLE, DROP_TABLE   -- we can shortcut this by using group event (DDL_TABLE_EVENTS)
AS
	Print 'Table Is Created Successfully'
Go



Go
Create Trigger NotifiyOnTableModification
On Database
With Encryption
For DDL_TABLE_EVENTS
AS
	Print 'Modified Successfully'
Go

Create Table Test03
(
id int
)

Alter Table NewTable
Drop Column Test


Drop Table Test03

--------------------------------------------------------
-- EventData After Any Modification On Table
--------------------------------------------------------
GO
Create Or Alter Trigger NotifiyOnTableModification
On Database
With Encryption
For DDL_TABLE_EVENTS
AS
	Select EVENTDATA() -- Return XML File Contain ALL Data
GO

Drop Table Test03


--------------------------------------------------------
-- Disable Alter On Table
--------------------------------------------------------

Go
Create Trigger DisableAlter
On Database
With Encryption
For ALTER_TABLE
AS
	ROLLBACK 
	Print 'You Can''t Do This Modification On Table'
GO


----------------- LOGON Trigger --------------------------------
GO
Create Trigger LimitConOfLogins
On All Server
With Encryption
For LOGON
AS
	BEGIN
			-- N Meaning Convert to nvarchar
		IF ORIGINAL_LOGIN() = N'AhmedSharaf/ahmedsharaf' AND (Select Count(*) From Sys.dm_exec_sessions Where is_user_process = 1 And original_login_name = N'AhmedSharaf/ahmedsharaf') > 2
			ROLLBACK
	END
GO


Select ORIGINAL_LOGIN() -- Who Logoned Now
--dm_exec_sessions -- Veiw In Maseter DB Contain All Info ABOUT SESSIONS

-- Number OF Session Created By this user
Select Count(*)
From Sys.dm_exec_sessions
Where is_user_process = 1 And original_login_name = N'AhmedSharaf/ahmedsharaf'


