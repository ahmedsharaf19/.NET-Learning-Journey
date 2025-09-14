--Part 01(Functions)
--Use ITI DB:
Use ITI

--1.	Create a scalar function that takes a date and returns the Month name of that date.
GO
Create or Alter Function dbo.GetMonthNameByDate (@date date)
returns varchar(20)
AS
	Begin 
		Declare @MonthName Varchar(20)
		SET @MonthName = Format(@date, 'MMMM')
		return @MonthName
	End
GO


select dbo.GetMonthNameByDate('9/14/2025')
--2.	 Create a multi-statements table-valued function that takes 2 integers and returns the values between them.


--3.	 Create a table-valued function that takes Student No and returns Department Name with Student full name.
go
Create Or Alter Function DepNameByStdNumber(@st_num int)
returns table
As
	return 
	(
		Select D.Dept_Name, CONCAT_WS(' ', S.St_Fname, S.St_Lname) [Full Name]
		From Student S, Department D
		Where S.Dept_Id = D.Dept_Id and S.St_Id = @st_num
	)
go

Select * From dbo.DepNameByStdNumber(1) 


--4.	Create a scalar function that takes Student ID and returns a message to user. 
	--a.	If first name and Last name are null, then display 'First name & last name are null.'
	--b.	If First name is null, then display 'first name is null'
	--c.	If Last name is null, then display 'last name is null.'
	--d.	Else display 'First name & last name are not null'

Go
Create Or Alter Function dbo.MessageToUser(@StudentId int)
returns varchar(max)
As
	Begin
		Declare @Message Varchar(max),  @Fname Varchar(max), @Lname varchar(max)
		Select @Fname = St_Fname, @Lname = St_Lname
		From Student
		where St_Id = @StudentId
		If @Fname is null and @Lname is null
			Set @Message = 'First name & last name are null.'
		ELSE IF @Fname is null 
			Set @Message = 'First name & last name are null.'
		ELSE IF @Lname is null
			Set @Message = 'last name is null.'
		ELSE 
			Set @Message = 'First name & last name are not null'
		
		return @Message
	End
Go

Select dbo.MessageToUser(16)
Select dbo.MessageToUser(1000)
--5.	Create a function that takes an integer which represents the format of the Manager hiring date and displays department name, Manager Name and hiring date with this format.   
Go
Create Or Alter Function GetManagerData(@style int)
returns Table
As
	Return
	(
		Select D.Dept_Name, I.Ins_Name, CONVERT(VARCHAR(MAX), D.Manager_hiredate, @style) [Hiring Data]
		From Department D, Instructor I
		Where I.Dept_Id = D.Dept_Id
	)
Go

select * from GetManagerData(110)

--6.	Create multi-statement table-valued function that takes a string.
	--a.	If string='first name' returns student first name
	--b.	If string='last name' returns student last name 
	--c.	If string='full name' returns Full Name from student table  
	--Note: Use “ISNULL” function

Go
Create Or Alter Function GetStudentName(@format varchar(30))
returns @data Table (StudentName varchar(30))
As 
	Begin
		IF @format = 'first name'
			Insert Into @data
			Select ISNULL(St_Fname, 'Not Found') From Student
		ELSE IF @format = 'last name'
			insert into @data
			Select ISNULL(St_Lname, 'Not Found') From Student
		ELSE IF @format = 'full name'
			Insert into @data
			Select CONCAT_WS(' ', ISNULL(St_Fname, 'Not Found'), ISNULL(St_Lname, 'Not Found')) From Student
		return 
	End
GO

select * from GetStudentName('first name')
select * from GetStudentName('last name')
select * from GetStudentName('full name')




--7.	Create function that takes project number and display all employees in this project (Use MyCompany DB)
use MyCompany

Go
Create or Alter Function GetProjectNumber(@p_num int)
Returns Table
As
	RETURN 
	(
	Select *
	From Project P, Employee E, Works_for W
	Where W.Pno = P.Pnumber and W.ESSn = E.SSN and P.Pnumber = @p_num
	)
Go

Select * From GetProjectNumber(100)
--------------------------------------------------------------------------------------------------------
--Part 02 (Views)

--Note : # means number and for example d2 means department which has id or number 2

--Use ITI DB:
Use ITI

--1.	 Create a view that displays the student's full name, course name if the student has a grade more than 50. 
go
Create Or Alter View VDisplayStudentData 
With Encryption
As
	Select CONCAT_WS(' ', S.St_Fname, S.St_Lname) [Full Name] , C.Crs_Name
	From Student S, Stud_Course SC, Course C
	Where S.St_Id = SC.St_Id and SC.Crs_Id = C.Crs_Id and SC.Grade > 50
go

select * from VDisplayStudentData
--2.	 Create an Encrypted view that displays instructor names and the topics they teach. 
go
Create Or Alter View VDisplayInstructorNames
WITH ENCRYPTION
AS
	Select Distinct I.Ins_Name, T.Top_Name
	From Instructor I INNER JOIN Ins_Course Crs
	ON I.Ins_Id = Crs.Ins_Id
	Inner Join Course C
	ON C.Crs_Id = crs.crs_id
	Inner Join Topic T
	ON C.Top_Id = T.Top_Id
go

select * from VDisplayInstructorNames
--3.	Create a view that will display Instructor Name, Department Name for the ‘SD’ or ‘Java’ Department “use Schema binding” and describe what is the meaning of Schema Binding
/*
SCHEMABINDING in SQL Server is used with Views or Functions to lock them to the schema of the underlying tables.

Key points:

Prevents structural changes: You cannot drop or modify tables/columns used by the view/function without first removing schemabinding.

Enables performance improvements: Required for features like Indexed Views.

Syntax:
	CREATE VIEW dbo.MyView
	WITH SCHEMABINDING
	AS
	SELECT Col1, Col2
	FROM dbo.MyTable;
Notes:
- Must specify the schema for all tables (e.g., dbo.MyTable).
- Cannot use SELECT * with SCHEMABINDING.
- To modify underlying tables, you must first remove or alter the schemabinding.

It essentially locks the view/function to the table structure to ensure consistency and support optimization.


*/
Go 
Create Or Alter View VDisplayInstructorDepartmentName
With Schemabinding, Encryption 
As
	Select I.Ins_Name [Instructor Name], D.Dept_Name [Department Name]
	From dbo.Instructor I, dbo.Department D
	Where I.Dept_Id = D.Dept_Id and D.Dept_Name in ('SD', 'Java')
Go


Select * From VDisplayInstructorDepartmentName
--4.	 Create a view “V1” that displays student data for students who live in Alex or Cairo. 
--Note: Prevent the users to run the following query 
--Update V1 set st_address=’tanta’
--Where st_address=’alex’;
Go
Create Or Alter View V1
With Encryption
AS
	Select *
	From Student
	where St_Address in ('Alex', 'Cairo') With Check Option
Go

Select * from V1

Update V1 
Set St_Address = 'tanta'
Where St_Address = 'alex'

--5.	Create a view that will display the project name and the number of employees working on it. (Use Company DB)
use MyCompany

go 
Create Or Alter View VDisplayProjectNameEmployeeNum
With Encryption
As 
	Select P.Pname, COUNT(W.ESSn) [Num Employees]
	From Works_for W, Project P
	Where W.Pno = P.Pnumber
	Group by P.Pname
go

Select * From VDisplayProjectNameEmployeeNum

--Use SD32-Company DB:
ALTER AUTHORIZATION ON DATABASE::[SD32-Company] TO [sa]

Use [SD32-Company]

--1.	Create a view named “v_clerk” that will display employee Number, project Number, the date of hiring of all the jobs of the type 'Clerk'.
Go
Create Or Alter View v_clerk
With Encryption 
As
	Select EmpNo [Employee Number], ProjectNo [Project Number], Enter_Date [Hiring Date]
	From Works_on 
	Where Job = 'Clerk'	
go

select * from v_clerk

--2.	 Create view named  “v_without_budget” that will display all the projects data without budget
Go 
Create Or Alter View v_without_budget
with encryption
As 
	Select ProjectNo, ProjectName
	From HR.Project
Go

Select * From v_without_budget
--3.	Create view named  “v_count “ that will display the project name and the Number of jobs in it

go
Create Or Alter View v_count
with encryption
as 
	Select P.ProjectName, Count(W.Job) [Count of job]
	From Hr.Project P, Works_on W
	Where P.ProjectNo = W.ProjectNo
	Group by P.ProjectName
go

select * from v_count
--4.	 Create a view named” v_project_p2” that will display the emp# s for the project# ‘p2’. (use the previously created view  “v_clerk”)
go
Create Or Alter view v_project_p2
with encryption 
As
	Select [Employee Number] 
	From v_clerk
	where [Project Number] = 2
go

select * from v_project_p2
--5.	modify the view named “v_without_budget” to display all DATA in project p1 and p2.
go
Alter View v_without_budget
With Encryption
As
	Select *
	From HR.Project 
	Where ProjectNo in (1, 2)
go
select * from Hr.Project
--6.	Delete the views  “v_ clerk” and “v_count”
Drop View v_clerk, v_count
--7.	Create view that will display the emp# and emp last name who works on deptNumber is ‘d2’
Go
Create Or Alter View DisplayEmpD2
with encryption
as
	Select EmpNo, EmpLname
	From Hr.Employee
	Where DeptNo = 2
go

select * from DisplayEmpD2
--8.	Display the employee  lastname that contains letter “J” (Use the previous view created in Q#7)
Select EmpLname
From DisplayEmpD2 
Where EmpLname Like '%J%'
--9.	Create view named “v_dept” that will display the department# and department name
Go
Create Or Alter view v_dept
With Encryption 
As
	Select DeptNo, DeptName
	From Department
go

select * from v_dept
--10.	using the previous view try enter new department data where dept# is ’d5’ and dept name is ‘Testing’
insert into v_dept
values (5, 'Testing')
--11.	Create view name “v_2006_check” that will display employee Number, the project Number where he works and the date of joining the project which must be from the first of January and the last of December 2006.this view will be used to insert data so make sure that the coming new data must match the condition
GO
Create Or Alter View v_2006_check
With Encryption
AS
	Select EmpNo, ProjectNo, Enter_Date
	From Works_on
	Where Enter_Date between '2006-01-01' and '2006-12-30' with check option
go

select * from v_2006_check

Insert Into v_2006_check
Values(22222, 1, '2006-3-5')

Insert Into v_2006_check
Values(25348, 2, '2008-3-5')

	
--------------------------------------------------------------
--Part 03
--Create a database “by Wizard” named “SharafCompany”
use SharafCompany

--1.	Create the following tables with all the required information and load the required data as specified in each table using insert statements[at least two rows]
--Table Name				Details										Comments

--Department		--DeptNo (PK)	DeptName	Location      --	1-Create it programmatically	--[By Code]						
					--d1			Research		NY
					--d2			Accounting		DS
					--d3			Marketing		KW

Create Table Department
(
	DeptNo INT Primary Key Identity,
	DeptName varchar(30),
	Location VarChar(10)
)

Insert Into Department
Values('Research', 'NY'), ('Accounting', 'DS'), ('Marketing', 'KW')

--Employee	--EmpNo (PK)	Emp Fname	Emp Lname	DeptNo		Salary
			--25348			Mathew		Smith		d3			2500
			--10102			Ann			Jones		d3			3000
			--18316			John		Barrymore	d1			2400
			--29346			James		James		d2			2800
			--9031			Lisa		Bertoni		d2			4000
			--2581			Elisa		Hansel		d2			3600
			--28559			Sybl		Moser		d1			2900
--1-Create it programmatically
--2-PK constraint on EmpNo
--3-FK constraint on DeptNo
--4-Unique constraint on Salary
--5-EmpFname, EmpLname don�t accept null values 

Create Table Employee
(
	EmpNo int primary key,
	EmpFname varchar(30) not null,
	EmpLname varchar(30) not null,
	DeptNo int references Department(DeptNo), -- Fk
	Salary int unique
)

Insert Into Employee
Values (25348, 'Mathew', 'Smith', 3, 2500),
	   (10102, 'Ann', 'Jones', 3, 3000),
	   (18316, 'John', 'Barrymore', 1, 2400),
	   (29346, 'James', 'James', 2, 2800),
	   (9031, 'Lisa', 'Bertoni', 2, 4000),
	   (2581, 'Elisa', 'Hansel', 2, 3600),
	   (28559, 'Sybl', 'Moser', 1, 2900)

--Project	--ProjectNo (PK)	ProjectName		Budget
			--p1				Apollo			120000
			--p2				Gemini			95000
			--p3				Mercury			185600
--1-Create it by Wizard
--2-ProjectName can't contain null values
--3-Budget allow null
Insert Into Project
Values (1, 'Apollo', 120000),
	   (2, 'Gemini', 95000),
	   (3, 'Mercury', 185600)

--Works_on	--EmpNo (PK)	ProjectNo(PK)	Job			Enter_Date
			--10102				p1			Analyst		2006.10.1
			--10102				p3			Manager		2012.1.1
			--25348				p2			Clerk		2007.2.15
			--18316				p2			NULL		2007.6.1
			--29346				p2			NULL		2006.12.15
			--2581				p3			Analyst		2007.10.15
			--9031				p1			Manager		2007.4.15
			--28559				p1			NULL		2007.8.1
			--28559				p2			Clerk		2012.2.1
			--9031				p3			Clerk		2006.11.15
			--29346				p1			Clerk		2007.1.4

--1-Create it Wizard
--2- EmpNo INTEGER NOT NULL
--3-ProjectNo doesn't accept null values
--4-Job can accept null
--5-Enter_Date can�t accept null
--and has the current system date as a default value[visually]
--6-The primary key will be EmpNo,ProjectNo) 
--7-there is a relation between works_on and employee, Project  tables
insert into Works_on
values (10102 , 1 , 'Analyst' ,'2006.10.1'),
       (10102 , 3 , 'Manager' ,'2012.1.1'),
	   (25348 , 2 , 'Clerk' ,'2007.2.15'),
       (18316 ,2,NULL,'2007.6.1'),
       (29346,2,NULL,'2006.12.15'),
       (2581,3,'Analyst','2007.10.15'),
       (9031,1,'Manager','2007.4.15'),
       (28559,1,NULL,'2007.8.1'),
       (28559,2, 'Clerk','2012.2.1'),
       (9031,3,'Clerk','2006.11.15'),
       (29346,1,'Clerk','2007.1.4')



--Testing Referential Integrity	
--1-Add new employee with EmpNo =11111 In the works_on table [what will happen]
insert into works_on (EmpNo)
values (11111)

-- The statement has been terminated (INSERT fails) 
-- Cannot insert the value NULL into column 'ProjectNo'column does not allow nulls

--2-Change the employee number 10102  to 11111  in the works on table [what will happen]
update Works_on
Set EmpNo = 11111
where EmpNo = 10102
-- because there is no employee with number 11111 
-- The UPDATE statement conflicted with the FOREIGN KEY constraint "FK_Works_on_Employee".
-- The conflict occurred in database "RouteCompany", table "HR.Employee", column 'EmpNo'.


--3-Modify the employee number 10102 in the employee table to 22222. [what will happen]
update Employee
Set EmpNo = 22222
wHERE EmpNo = 10102
-- The statement has been terminated.
-- The UPDATE statement conflicted with the REFERENCE constraint "FK_Works_on_Employee". 
-- The conflict occurred in database "RouteCompany", table "dbo.Works_on", column 'EmpNo'.

--4-Delete the employee with id 10102
Delete From Employee
Where EmpNo = 10102
-- The statement has been terminated.
--The DELETE statement conflicted with the REFERENCE constraint "FK_Works_on_Employee". 
-- The conflict occurred in database "RouteCompany", table "dbo.Works_on", column 'EmpNo'.


--Table Modification	
-- 1-Add  TelephoneNumber column to the employee table[programmatically]
Alter Table Employee
Add TelephoneNumber varchar(15)

--2-drop this column[programmatically]
Alter Table Employee
Drop Column TelephoneNumber
--3-Build A diagram to show Relations between tables

--2.	Create the following schema and transfer the following tables to it 

--a.	Company Schema 
--i.	Department table 
--ii.	Project table 
go
Create Schema Company
go

Alter Schema Company
Transfer Department 

Alter Schema Company 
Transfer Project

--b.	Human Resource Schema
--i.	  Employee table 
go 
create schema HR
go

Alter Schema HR
Transfer Employee

--3.	Increase the budget of the project where the manager number is 10102 by 10%.
update P
Set P.Budget += (P.Budget * 0.1)
From Company.Project P, dbo.Works_on W
where P.ProjectNo = W.ProjectNo and W.EmpNo = 10102 and W.Job = 'Manager'

--4.	Change the name of the department for which the employee named James works.The new department name is Sales.
update  D
Set D.DeptName = 'Sales'
from Company.Department D, HR.Employee E
where D.DeptNo = E.DeptNo and E.EmpFname = 'James'

--5.	Change the enter date for the projects for those employees who work in project p1 and belong to department ‘Sales’. The new date is 12.12.2007.
Update W
Set W.Enter_Date = '12-12-2007'
From Works_on W, HR.Employee E, Company.Department D
Where E.EmpNo = W.EmpNo and E.DeptNo = D.DeptNo and W.ProjectNo = 1 and D.DeptName = 'Sales'

--6.	Delete the information in the works_on table for all employees who work for the department located in KW.
Delete From Works_on
Where EmpNo in (select E.EmpNo
				from HR.Employee E, Company.Department D
				Where E.DeptNo = D.DeptNo and D.Location = 'KW'
				)

