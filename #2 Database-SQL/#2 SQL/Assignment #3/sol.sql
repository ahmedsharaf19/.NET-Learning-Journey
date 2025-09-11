--------------------- Part 01 ---------------------
-- Use ITI DB
use ITI

--1.	Retrieve a number of students who have a value in their age. 
Select Count(St_age) [Number Of Student]
From Student

--2.	Display number of courses for each topic name
Select Top_Name, COUNT(*) [Number Of Courses]
From Course C, Topic T
Where C.Top_Id = T.Top_Id
Group By Top_Name

--3.	Display student with the following Format (use isNull function)
--Student ID	Student Full Name	Department name
Select S.St_Id [Student ID] , S.St_Fname + ' ' + ISNULL(S.St_Lname, '') [Student Full Name], D.Dept_Name [Department name] 
From Student S, Department D
Where S.Dept_Id = D.Dept_Id

--4.	Select instructor name and his salary but if there is no salary display value ‘0000’ . “use one of Null Function” 
Select Ins_Name, ISNULL(Salary, 0000)
From Instructor

--5.	Select Supervisor first name and the count of students who supervises on them
Select sup.St_Fname, count(S.St_Id)
From Student S, Student sup
Where sup.St_Id = S.St_super
group by sup.St_Fname

--6.	Display max and min salary for instructors
Select Max(Salary) [Max Salary], Min(Salary) [Min Salary]
From Instructor

--7.	Select Average Salary for instructors 
Select  Avg(Salary) [Average Salary]
From Instructor

--8.	Display instructors who have salaries less than the average salary of all instructors.
Select *
From Instructor
Where Salary < (Select Avg(Salary) From Instructor)

--9.	Display the Department name that contains the instructor who receives the minimum salary
Select D.Dept_Name
From  Department D, Instructor I
Where D.Dept_Id = I.Dept_Id and I.Salary = (Select MIN(Salary) From Instructor)

--10.	Select max two salaries in instructor table.
Select Top(2)*
From Instructor
Where Salary IS NOT NULL
Order By Salary Desc





--Part 02

--Use MyCompany DB
use MyCompany

--1.	For each project, list the project name and the total hours per week (for all employees) spent on that project.
Select P.Pname, Sum(W.Hours) [Total Hour]
From Project P, Works_for W
Where P.Pnumber = W.Pno
Group by P.Pname

--2.	For each department, retrieve the department name and the maximum, minimum and average salary of its employees.
Select Dname, Max(Salary) [Max Salary], Min(Salary) [Min Salary], Avg(Salary) [Avg Salary]
From Departments D, Employee E
Where D.Dnum = E.Dno
Group by Dname

--3.	Display the data of the department which has the smallest employee ID over all employees' ID.
Select Top(1) Dname, Dnum, MGRSSN, [MGRStart Date]
From Departments D, Employee E
Where D.Dnum = E.Dno
order by E.SSN

-----------
Select D.*
From Employee E , Departments D
Where D.Dnum = E.Dno and E.SSN = (Select MIN(SSN) From Employee Where Dno is not NULL)

--4.	List the last name of all managers who have no dependents
Select E.Lname , D.Dname
From Employee E , Departments D
Where E.SSN = D.MGRSSN and E.SSN not in (Select ESSN From Dependent)

--5.	For each department-- if its average salary is less than the average salary of all employees display its number, name and number of its employees.
Select D.Dnum, D.Dname, Count(E.SSN) [Number Of Employee]
From Departments D, Employee E
Where D.Dnum = E.Dno
Group by D.Dname, D.Dnum
Having Avg(E.Salary) < (Select AVG(Salary) From Employee)

--6.	Try to get the max 2 salaries using subquery.

Select (Select  MAX(Salary) From Employee), (Select MAX(Salary) From Employee
											 Where Salary < (Select MAX(Salary) From Employee))


--7.	Display the employee number and name if he/she has at least one dependent (use exists keyword) self-study.
Select Distinct E.Fname , E.SSN
From Employee E , Dependent D
Where E.SSN = D.ESSN and Exists(Select ESSN From Dependent )







