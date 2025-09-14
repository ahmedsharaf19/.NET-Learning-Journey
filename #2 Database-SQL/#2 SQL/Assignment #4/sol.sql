/*== Part 01 ==*/
--Use ITI DB
use ITI

--1.Write a query to select the highest two salaries in Each Department for instructors who have salaries. �using one of Ranking Functions�
Select * From
(Select Salary , Dept_Id,
	Row_Number() over(PArtition By Dept_Id Order by Salary Desc) as RN
From Instructor
Where Salary is not NULL) as newTable
Where RN in (1,2)

--2.Write a query to select a random  student from each department.  �using one of Ranking Functions�
Select * From
(Select St_Fname , Dept_Id ,
		ROW_NUMBER() over (Partition By Dept_Id Order by newId()) as RN
From Student 
Where Dept_Id is not NULL) as newTable
Where RN = 1


/*=========================================================================================================================*/

/*== Part 02 ==*/
--Restore adventureworks2012 Database Then :
use AdventureWorks2012
--1.Display the SalesOrderID, ShipDate of the SalesOrderHearder table (Sales schema) to designate SalesOrders that occurred within the period �7/28/2002� and �7/29/2014�

Select SalesOrderID , ShipDate
From Sales.SalesOrderHeader
Where OrderDate between  '7/28/2002' and  '7/29/2014'


--2.Display only Products(Production schema) with a StandardCost below $110.00 (show ProductID, Name only)

Select ProductID , Name , StandardCost
From Production.Product
Where StandardCost < 110

--3.Display ProductID, Name if its weight is unknown

Select ProductID , Name
From Production.Product
Where Weight is Null


--4.Display all Products with a Silver, Black, or Red Color

Select *
From Production.Product
where Color in ('Silver' , 'Black' , 'Red')
--5.Display any Product with a Name starting with the letter B
Select *
From Production.Product
Where Name Like 'B%'

--6.Run the following Query
--UPDATE Production.ProductDescription
--SET Description = 'Chromoly steel_High of defects'
--WHERE ProductDescriptionID = 3
--Then write a query that displays any Product description with underscore value in its description.

UPDATE Production.ProductDescription
SET Description = 'Chromoly steel_High of defects'
WHERE ProductDescriptionID = 3

Select Description
From Production.ProductDescription
Where Description Like '%[_]%'

--7.Display the Employees HireDate (note no repeated values are allowed)

Select Distinct HireDate
From HumanResources.Employee



--8.Display the Product Name and its ListPrice within the values of 100 and 120 the list should have the following format "The [product name] is only! [List price]" (the list will be sorted according to its ListPrice value)

Select CONCAT('The ' , Name , ' is only! ', ListPrice) ProductWithPrice
From Production.Product
Where ListPrice between 100 and 120
Order by ListPrice
 




