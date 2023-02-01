--Queries for SoftUni Database
--1 Find Names of All Employees by First Name
USE SoftUni

SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'Sa%'

--2 Find Names of All Employees by Last Name
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

--3 Find First Names of All Employees
SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3, 10)
	AND YEAR(HireDate) BETWEEN 1995 AND 2005

--4 Find All Employees Except Engineers
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--Method 2
SELECT FirstName, LastName
FROM Employees
WHERE CHARINDEX('engineer', JobTitle) = 0

--5 Find Towns with Name Length
SELECT [Name] 
FROM Towns
WHERE LEN([Name]) BETWEEN 5 AND 6
ORDER BY [Name] ASC

--6 Find Towns Starting With
SELECT TownID, [Name] 
FROM Towns
WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name] ASC

--7 Find Towns Not Starting With
SELECT TownID, [Name] 
FROM Towns
WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name] ASC

--METHOD 2
SELECT TownID, [Name] 
FROM Towns
WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name] ASC

--8 Create View Employees Hired After 2000 Year
GO
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName 
FROM Employees
WHERE YEAR(HireDate)> 2000
GO

SELECT * FROM V_EmployeesHiredAfter2000
--9 Length of Last Name
SELECT FirstName, LastName 
FROM Employees
WHERE LEN(LastName) = 5