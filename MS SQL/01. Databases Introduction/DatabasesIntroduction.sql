--1
CREATE DATABASE [Minions]

USE [Minions]

GO

--2
CREATE TABLE Minions 
(
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	Age INT NOT NULL
)

CREATE TABLE Towns 
(
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
)

--3
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL

ALTER TABLE Minions
ALTER COLUMN Age INT

--4
INSERT INTO Towns(Id, [Name])
VALUES 
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

SELECT * FROM Towns

INSERT INTO Minions(Id, [Name], Age, TownId)
VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

SELECT * FROM Minions

--5
--The TRUNCATE TABLE command deletes the data inside a table, but not the table itself.
TRUNCATE TABLE [Minions]

--6
--The DROP TABLE command deletes a table in the database.
DROP TABLE [Towns]
DROP TABLE [Minions]

--7
CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL (3, 2),
	[Weight] DECIMAL (5, 2),
	Gender CHAR(1) Not null CHECK(Gender='m' OR Gender='f'),
	Birthdate DATE Not Null,
	Biography NVARCHAR(MAX)
)

INSERT INTO People([Name], Picture, Height, [Weight], Gender, Birthdate, Biography) 
	Values
('Stela', Null, 1.65, 44.55, 'f', '2000-09-22', Null),
('Ivan', Null, 2.15, 95.55, 'm', '1989-11-02', Null),
('Qvor', Null, 1.55, 33.00, 'm', '2010-04-11', Null),
('Karolina', Null, 2.15, 55.55, 'f', '2001-11-11', Null),
('Pesho', Null, 1.85, 90.00, 'm', '1983-07-22', Null)

SELECT * FROM People

--8
CREATE TABLE  Users(
	Id BIGINT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATE,
	IsDeleted Bit
)

INSERT INTO Users ([Name], [Password], ProfilePicture, LastLoginTime, IsDeleted) 
	VALUES
('Stela', '123', NULL, '2000-09-22', 0),
('Ivan', '124', NULL, '1989-11-02', 1),
('Qvor', '125', NULL, '2010-04-11', 0),
('Karolina', '126', NULL, '2001-11-11', 1),
('Pesho', '127', NULL, '1983-07-22', 0);

SELECT * FROM Users

--9
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07F433F068

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY(Id, [Name])

--10
ALTER TABLE Users
ADD CONSTRAINT CH_PasswordIsAtLeast5Symbols CHECK (LEN([Password]) >= 5)

--11
ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

--12
ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT UC_Username UNIQUE ([Name])

ALTER TABLE Users
ADD CONSTRAINT CH_UsernameIsAtLeast3Symbols CHECK (LEN([Name]) >= 3)

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY(Id)

--15
CREATE DATABASE Hotels
USE Hotels

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR (100) NOT NULL,
	LastName NVARCHAR (100) NOT NULL,
	Title NVARCHAR(50),
	Notes NVARCHAR(MAX)
)

CREATE TABLE Customers(
	AccountNumber INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR (100) NOT NULL,
	LastName NVARCHAR (100) NOT NULL,
	PhoneNumber CHAR(10) NOT NULL,
	EmergencyName NVARCHAR(100) NOT NULL,
	EmergencyNumber CHAR(10) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE RoomStatus(
	RoomStatus NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE RoomTypes(
	RoomType NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE BedTypes (
	BedType NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Rooms(
	RoomNumber INT PRIMARY KEY,
	RoomType NVARCHAR(100) NOT NULL,
	BedType NVARCHAR(100) NOT NULL,
	Rate INT NOT NULL,
	RoomStatus NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Payments(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	PaymentDate DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATETIME NOT NULL,
	LastDateOccupied DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(10, 2) NOT NULL,
	TaxRate INT NOT NULL,
	TaxAmount DECIMAL(10,2) NOT NULL,
	PaymentTotal DECIMAL(10,2) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Occupancies(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied INT NOT NULL,
	PhoneCharge DECIMAL(10,2) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees(FirstName, LastName, Title) 
	VALUES
('Ivan', 'Petrov', 'Manager'),
('Kalina', 'Ivanova', 'Receptionist'),
('Pesho', 'Ivanov', 'Hostes')

INSERT INTO Customers(FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
	VALUES
('Pesho', 'Petrov', 0882525252, 'Maria', 0326160, 'first note'),
('Georgi', 'Petrov', 0895252525, 'Petar', 0326155, 'random note'),
('Maria', 'Ivanova', 0872525252, 'Ivana', 0326555, 'other note')

INSERT INTO RoomStatus(RoomStatus)
	VALUES
('Available'),
('Reserved'),
('For cleaning')

INSERT INTO RoomTypes(RoomType) 
	VALUES
('Single'),
('Apartment'),
('Double')

INSERT INTO BedTypes(BedType, Notes)
	VALUES
('Single', 'single bed'),
('Double', 'double bed'),
('KIng', 'king size bed')

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) 
	VALUES
(101, 'Double', 'Queen', 1, 'Available', 'test note'),
(102, 'Apartment', 'Queen', 2, 'Reserved', null),
(103, 'Double', 'Queen', 3, 'For cleaning', 'other note')

INSERT INTO Payments(Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal) 
	VALUES
(1, 1, '01/18/2023', 1, '01/11/23', '01/18/2023', 7, 50, 15, 30, 155.50),
(2, 2, '01/18/2023', 2, '01/11/23', '01/18/2023', 7, 50, 15, 30, 150),
(3, 3, '01/18/2023', 3, '01/11/23', '01/18/2023', 7, 50, 15, 40, 200)

INSERT INTO Occupancies(Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge) 
	VALUES
(1, 1, '01/17/2023', 1, 213, 2, 0),
(2, 2, '01/17/2023', 2, 326, 2, 10),
(3, 3, '01/17/2023', 3, 123, 2, 20.50)