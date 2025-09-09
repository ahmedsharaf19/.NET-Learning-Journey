/*========================Assignment 03========================*/
/*============Part01============*/

--Choose 2 Database Schema From The Previous Assignment and Create One using code and another using wizard 

--------------------------------------------------------------------------
Create Database ITIWorkshop

Use ITIWorkshop

Create Table Students
(
Id int Primary Key Identity(1,1),
FName Varchar(30) not Null,
LName Varchar(30) not Null,
Age int,
Address Varchar(100),
Dept_Id int -- FK
)

Create Table Departments
(
Id int Primary Key Identity(10,10),
Name Varchar(20) not Null,
HirringDate Date,
Manager_Id int not null Unique , -- FK
)

Create Table Instructors
(
Id int Primary Key Identity(1,1),
Name Varchar(30) not Null,
Address varchar(50),
Bonus int,
Salary decimal not Null,
Hour_Rate decimal,
Dept_Id int references Departments(Id)
)

Create Table Courses
(
Id int Primary Key Identity(1,1),
Name Varchar(30) not Null,
Duration int not Null,
Description VarChar(40),
Top_Id int -- FK
)

Create Table Topic
(
Id int Primary Key Identity(1,1),
Name Varchar(30) not Null
)

Create Table Stud_Course
(
Stud_Id int references Students(Id),
Course_Id int references Courses(Id),
Grade decimal,
Primary Key(Stud_Id,Course_Id)
)

Create Table Course_Instructor
(
Course_Id int references Courses(Id),
Inst_Id int references Instructors(Id),
Evaluation Varchar(30),
Primary Key(Course_Id,Inst_Id)
)

---------------------------------------------------------------------
Alter Table Students
Add Foreign Key (Dept_Id) references Departments(Id)

Alter Table Departments 
Add Foreign Key (Manager_Id) references Instructors (Id)

Alter Table Courses
Add Foreign Key (Top_Id) references Topic(Id)
----------------------------------------------------------------
----       Insert at least 2 rows per table ----

Insert Into Instructors
Values 
('Ahmed' , 'Cairo' , 100 , 8000.00 , 12 , null),
('Doaa' , 'New Cairo' , 80 , 4000.00 , 5 , null)

Insert Into Departments
Values
('CS' , '02-18-2015' , 1),
('AI' , '05-22-2019' , 2)

Insert Into Students
Values
('Mohamed' , 'Yasser' , 22 , 'Alex' ,10),
('Amr' , 'Ali' , 25 , 'Cairo' ,20)


-- ======================================================================================
/*============Part02============*/

--Data Manipulation Language:
Use CompanyG00

--1.Insert your personal data to the employee table as a new employee in department number 30, SSN = 102672, SupervisorSSN = 112233, salary = 3000.
Insert Into Employees(Id,FName , Age ,Salary , SypervisorId , DepartmentNumber)
Values(102672 , 'Amir' , 25 , 3000 ,112233 , 30)


--2.Insert another employee with your friend's personal data as a new employee in department number 30, SSN = 102660, but don’t enter any value for salary or SupervisorSSN to him.
Insert Into Employees(Id,FName , Age ,Salary , SypervisorId , DepartmentNumber)
Values(102660 , 'Haidy' , 25 , null ,null , 30)
--3.Upgrade your salary by 20 % of its last value.

Update Employees
Set Salary += Salary * 0.2 -- Salary = Salary + Salary*0.2
where Id = 102672




