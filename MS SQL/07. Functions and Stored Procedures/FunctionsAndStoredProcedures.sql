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

--06. Employees by Salary Level
GO
CREATE OR ALTER PROCEDURE usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(10))
AS
BEGIN
	SELECT FirstName 
			,LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
END

EXEC dbo.usp_EmployeesBySalaryLevel 'High'

--07. Define Function
GO
CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @index INT = 1;
	WHILE (@index <= LEN(@word))
	BEGIN
		DECLARE @currentLetter CHAR = SUBSTRING(@word, @index, 1)

		IF CHARINDEX(@currentLetter, @setOfLetters) = 0
			RETURN 0;
		SET @index += 1
	END
	RETURN 1
END
GO

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')

--08. Delete Employees and Departments
GO
CREATE OR ALTER PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
							SELECT EmployeeID
							FROM Employees
							WHERE DepartmentID = @departmentId
						)
	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (
							SELECT EmployeeID
							FROM Employees
							WHERE DepartmentID = @departmentId
						)

	ALTER TABLE [Departments]
	ALTER COLUMN [ManagerID] INT
	
	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (
							SELECT EmployeeID
							FROM Employees
							WHERE DepartmentID = @departmentId
						)
	
	DELETE FROM [Employees]
		   WHERE [DepartmentID] = @departmentId

	DELETE FROM [Departments]
	       WHERE [DepartmentID] = @departmentId

	SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID = @departmentId
END
GO

EXECUTE dbo.usp_DeleteEmployeesFromDepartment 2

select * from Employees
where DepartmentID = 2

--Part II – Queries for Bank Database
--09. Find Full Name
USE Bank
GO
CREATE OR ALTER PROCEDURE usp_GetHoldersFullName
AS
BEGIN 
	SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM AccountHolders
END

EXEC dbo.usp_GetHoldersFullName

--10. People with Balance Higher Than
GO
CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan(@total DECIMAL(18, 4))
AS
BEGIN 
	SELECT FirstName, LastName
	FROM AccountHolders AS ah
	JOIN Accounts AS a 
	ON ah.Id = a.AccountHolderId
	GROUP BY FirstName, LastName
	HAVING SUM(a.Balance) > @total
	ORDER BY FirstName, LastName
END

EXEC dbo.usp_GetHoldersWithBalanceHigherThan 15000

--11. Future Value Function
GO
CREATE OR ALTER FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(8,2), @rate FLOAT, @years INT)
RETURNS DECIMAL (10,4)
AS
BEGIN
	RETURN @sum * (POWER((1 + @rate), @years))
END
GO

SELECT dbo.ufn_CalculateFutureValue (1000, 0.1, 5)

--12. Calculating Interest
GO
CREATE OR ALTER PROC usp_CalculateFutureValueForAccount (@AccountId INT, @Interest FLOAT)
AS
BEGIN
	SELECT a.Id AS [Account Id]
			,ah.FirstName AS [First Name]
			,ah.LastName AS [Last Name]
			,a.Balance AS [Current Balance]
			,[dbo].[ufn_CalculateFutureValue](a.[Balance], @Interest, 5) AS [Balance in 5 years]
	FROM Accounts AS a
	JOIN AccountHolders AS ah
	ON a.AccountHolderId = ah.Id
	WHERE a.Id = @AccountId
END
GO

EXEC dbo.usp_CalculateFutureValueForAccount 1, 0.1

--Part III – Queries for Diablo Database
--13. Cash in User Games Odd Rows
USE Diablo

GO
CREATE OR ALTER FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE 
AS
	RETURN SELECT SUM(Cash) AS SumCash
	FROM (
			SELECT  g.[Name]
					,ug.Cash
					,ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RowNumber
			FROM Games AS g
			JOIN UsersGames AS ug
			ON g.Id = ug.GameId
			WHERE g.[Name] = @gameName
		 ) AS RankingSubquery
	WHERE RowNumber % 2 = 1
GO

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')