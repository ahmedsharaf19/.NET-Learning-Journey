
--------------- Part 01 ------------------
-- Restore MyCompany Database and then:
-- Try to create the following Queries:
USE MyCompany

--1.	Display all the employees Data.
Select *
From Employee
--2.	Display the employee First name, last name, Salary and Department number.
Select Fname, Lname, Salary, Dno
From Employee
--3.	Display all the projects names, locations and the department which is responsible for it.
Select proj.Pname, proj.Dnum, Dep.Dname
From Project proj inner join Departments Dep
ON proj.Dnum = Dep.Dnum
--4.	If you know that the company policy is to pay an annual commission for each employee with specific percent equals 10% of his/her annual salary. Display each employee full name and his annual commission in an ANNUAL COMM column (alias).
Select Fname + ' ' + Lname [Employee Name],  Salary * 12 * 0.1 [ANNUAL COMM]
From Employee
--5.	Display the employees Id, name who earns more than 1000 LE monthly.
Select SSN, Fname + ' ' + Lname
From Employee
Where Salary > 1000
--6.	Display the employees Id, name who earns more than 10000 LE annually.
Select SSN, Fname + ' ' + Lname
From Employee
Where (Salary * 12) > 10000
--7.	Display the names and salaries of the female employees 
Select Fname, Salary
From Employee
Where Sex Like 'F%'
--8.	Display each department id, name which is managed by a manager with id equals 968574.
select dep.Dnum, dep.Dname
from Departments dep
where dep.MGRSSN = 968574
--9.	Display the ids, names and locations of  the projects which are controlled with department 10. 
Select proj.Pnumber, proj.Pname, proj.Plocation
From Project proj
Where proj.Dnum = 10


--------------- Part 02 ------------------
-- Restore ITI Database and then:
Use ITI
--1.	Get all instructors Names without repetition
Select DISTINCT  Ins_Name 
From Instructor
--2.	Display instructor Name and Department Name Note: display all the instructors if they are attached to a department or not.
Select ins.Ins_Name, dep.Dept_Name
From Instructor ins Left Join Department dep
On ins.Dept_Id = dep.Dept_Id
--3.	Display student full name and the name of the course he is taking for only courses which have a grade.
Select S.St_Fname + ' ' + S.St_Lname [Full Name], C.Crs_Name, SC.Grade
From Student S, Course C, Stud_Course SC
Where S.St_Id = SC.St_Id and C.Crs_Id = SC.Crs_Id and SC.Grade is not null
--4.	Select Student first name and the data of his supervisor. 
Select Std.St_Fname + ' ' + Std.St_Lname [Student Name], Super.*
From Student Std, Student Super
Where Std.St_Id = Super.St_super
--5.	Display student with the following Format.  Student ID	Student Full Name	Department name
Select S.St_Id [Student ID], CONCAT(S.St_Fname, ' ', S.St_Lname) [Student Full Name], D.Dept_Name
From Student S join Department D 
On S.Dept_Id = D.Dept_Id 


--Bouns
--Display results of the following two statements and explain what is the meaning of @@AnyExpression
--select @@VERSION
Select @@VERSION  -- sql server version
--select @@SERVERNAME
Select @@SERVERNAME -- server name



--------------- Part 03 ------------------
--Using MyCompany Database and try to create the following Queries:
use MyCompany

--1.	Display the Department id, name and id and the name of its manager.
Select D.Dnum, D.Dname, Manager.Fname
From Departments D, Employee Manager
Where D.MGRSSN = Manager.SSN
--2.	Display the name of the departments and the name of the projects under its control.
Select D.Dname, P.Pname
From Departments D, Project P
Where P.Dnum = D.Dnum 
--3.	Display the full data about all the dependence associated with the name of the employee they depend on.
Select D.*, E.Fname
From Dependent D, Employee E
Where D.ESSN = E.SSN
--4.	Display the Id, name, and location of the projects in Cairo or Alex city.
Select Pnumber, Pname, Plocation, City
From Project
Where City In ('Cairo', 'Alex')
--5.	Display the Projects full data of the projects with a name starting with "a" letter.
Select *
From Project
Where Pname Like 'a%'
--6.	display all the employees in department 30 whose salary from 1000 to 2000 LE monthly
Select * 
From Employee
Where Dno = 30 and Salary between 1000 and 2000
--7.	Retrieve the names of all employees in department 10 who work more than or equal 10 hours per week on the "AL Rabwah" project.
Select E.Fname + ' ' + E.Lname [Employee Name]
From Employee E, Works_for W, Project P
Where  E.SSN = W.ESSn and  W.Hours >= 10 and W.Pno = P.Pnumber and E.Dno = 10 and P.Pname = 'AL Rabwah'
--8.	Find the names of the employees who were directly supervised by Kamel Mohamed
Select E.Fname + ' ' + E.Lname [Employee Name], S.Fname + ' ' + S.Lname [Supervisor Name]
From Employee E, Employee S
Where E.SSN = S.Superssn and S.Fname + ' ' + S.Lname = 'Kamel Mohamed'
--9.	Display All Data of the managers
Select E.* 
From Employee E, Departments D
Where E.SSN = D.MGRSSN
--10.	Retrieve the names of all employees and the names of the projects they are working on, sorted by the project name.
Select E.Fname + ' ' + E.Lname [Employee Name], P.Pname [Project Name] 
From Employee E, Works_for W, Project P
Where E.SSN = W.ESSn and W.Pno = P.Pnumber
order by P.Pname
--11.	For each project located in Cairo City, find the project number, the controlling department name, the department manager’s last name, address and birthdate.
Select P.Pnumber, D.Dname, Manager.Lname, Manager.Address, Manager.Bdate
From Project P, Departments D, Employee Manager
Where P.Dnum = D.Dnum and D.MGRSSN = Manager.SSN and  P.City = 'Cairo'
--12.Display All Employees data and the data of their dependents even if they have no dependents.
Select E.*
From Employee E Left Join Dependent D
ON D.ESSN = E.SSN

--------------- Part 04 ------------------
--Use MyCompany DB
use MyCompany
--DQL:
--1.	Retrieve a list of employees and the projects they are working on ordered by department and within each department, 
-- ordered alphabetically by last name, first name.
Select *
From Employee E, Works_for W, Project P
Where E.SSN = W.ESSn and W.Pno = P.Pnumber
Order By E.Dno, E.Lname, E.Fname

--2.	Try to update all salaries of employees who work in Project ‘Al Rabwah’ by 30% 	
update E
Set E.Salary += 0.3
From Employee E, Works_for W, Project P
Where E.SSN = W.ESSn And W.Pno = P.Pnumber and  P.Pname = 'Al Rabwah'
--DML:
--1.	In the department table insert a new department called "DEPT IT”, with id 100, employee with SSN = 112233 as a manager for this department. The start date for this manager is '1-11-2006'.
Insert Into Departments
Values('DEPT IT', 100, 112233, '1-11-2006')
--2.	Do what is required if you know that: Mrs. Oha Mohamed (SSN=968574) moved to be the manager of the new department (id = 100), and they give you (your SSN =102672) her position (Dept. 20 manager) 
--a.	First try to update her record in the department table.
update Departments
set MGRSSN = 968574
where Dnum = 100
--b.	Update your record to be department 20 manager.
Insert Into Employee
Values('Ahmed', 'Sharaf', 102672, '9-1-2002', 'Cairo', 'M', 15000, NULL, 20)
--c.	Update the data of employee number=102660 to be in your teamwork (he will be supervised by you) (your SSN =102672)
update Employee
set Superssn = 102672
WHERE SSN = 102660
--3.	Unfortunately, the company ended the contract with Mr. Kamel Mohamed (SSN=223344) so try to delete him from your database in case you know that you will be temporarily in his position.
--Hint: (Check if Mr. Kamel has dependents, works as a department manager, supervises any employees or works in any projects and handles these cases).
update Employee
Set Superssn = 102672
where Superssn = 223344

update Departments
set MGRSSN = 102672
where MGRSSN = 223344

update Works_for
set ESSn = 102672
where ESSn = 223344

delete Dependent
where ESSN = 223344

delete Employee
where SSN = 223344