--Part I – Queries for SoftUni Database
USE SoftUni
--01. Employees with Salary Above 35000
GO
CREATE PROCEDURE  dbo.usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary > 35000
END

EXEC dbo.usp_GetEmployeesSalaryAbove35000

--02. Employees with Salary Above Number
GO
CREATE PROCEDURE dbo.usp_GetEmployeesSalaryAboveNumber(@minSalary DECIMAL(18,4))
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @minSalary
END

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 48100

--03. Town Names Starting With
GO
CREATE PROCEDURE dbo.usp_GetTownsStartingWith (@townString NVARCHAR(20))
AS
BEGIN
	SELECT [Name] 
	FROM Towns
	WHERE [Name] LIKE @townString + '%'
END

EXEC dbo.usp_GetTownsStartingWith 'b'

--04. Employees from Town
GO
CREATE PROCEDURE dbo.usp_GetEmployeesFromTown (@townName NVARCHAR(50))
AS
BEGIN
	SELECT e.FirstName, e.LastName  
	FROM Employees AS e
	JOIN Addresses AS a 
	ON e.AddressID = a.AddressID
	JOIN Towns AS t 
	ON t.TownID = a.TownID
	WHERE t.[Name] = @townName
END

EXEC dbo.usp_GetEmployeesFromTown 'Sofia'

--05. Salary Level Function
GO
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
		DECLARE @salarylevel VARCHAR(8)

		IF @salary < 30000
			SET @salarylevel = 'Low'
		ELSE IF @salary BETWEEN 30000 AND 50000
			SET @salarylevel = 'Average'
		ELSE
			SET @salarylevel = 'High'
RETURN @salarylevel
END
GO

SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel
FROM Employees