CREATE DATABASE Airport
GO
USE Airport
GO

--Section 1. DDL (30 pts)
CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FullName VARCHAR(100) UNIQUE NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Pilots
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) UNIQUE NOT NULL,
	LastName VARCHAR(30) UNIQUE NOT NULL,
	Age TINYINT NOT NULL CHECK(Age BETWEEN 21 AND 62),
	Rating FLOAT CHECK(Rating BETWEEN 0 AND 10)
)

CREATE TABLE AircraftTypes
(
	Id INT PRIMARY KEY IDENTITY,
	TypeName VARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE Aircraft
(
	Id INT PRIMARY KEY IDENTITY,
	Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition CHAR(1) NOT NULL,
	TypeId INT FOREIGN KEY REFERENCES AircraftTypes(Id) NOT NULL,
)

CREATE TABLE PilotsAircraft
(
	AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
	PilotId INT FOREIGN KEY REFERENCES Pilots(Id) NOT NULL,
	PRIMARY KEY(AircraftId, PilotId)
)

CREATE TABLE Airports
(
	Id INT PRIMARY KEY IDENTITY,
	AirportName VARCHAR(70) UNIQUE NOT NULL,
	Country VARCHAR(100) UNIQUE NOT NULL,
)

CREATE TABLE FlightDestinations
(
	Id INT PRIMARY KEY IDENTITY,
	AirportId INT FOREIGN KEY REFERENCES Airports(Id) NOT NULL,
	[Start] DATETIME NOT NULL,
	AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	TicketPrice DECIMAL(18,2) DEFAULT 15 NOT NULL
)

--Section 2. DML (10 pts)
--2. Insert
INSERT INTO Passengers(FullName, Email)
SELECT 
	CONCAT(FirstName, ' ', LastName) AS FullName,
	CONCAT(FirstName, LastName, '@gmail.com') AS Email
FROM Pilots 
WHERE Id BETWEEN 5 AND 15

--03. Update
UPDATE Aircraft
SET Condition = 'A'
WHERE (Condition = 'B' OR Condition = 'C')
AND (FlightHours IS NULL OR FlightHours <= 100)
AND [Year] >= 2013

--04. Delete
DELETE FROM Passengers
WHERE LEN(FullName) <= 10 

--Section 3. Querying (40 pts)
--05. Aircraft
SELECT Manufacturer,
		Model,
		FlightHours,
		Condition
FROM Aircraft
ORDER BY FlightHours DESC

--06. Pilots and Aircraft
SELECT p.FirstName,
		p.LastName,
		a.Manufacturer,
		a.Model,
		a.FlightHours
FROM Pilots AS p
JOIN PilotsAircraft AS pa
ON p.Id = pa.PilotId
JOIN Aircraft AS a
ON pa.AircraftId = a.Id
WHERE a.FlightHours IS NOT NULL 
AND a.FlightHours <= 304
ORDER BY a.FlightHours DESC, p.FirstName

--07. Top 20 Flight Destinations
SELECT TOP(20)
		fd.Id AS DestinationId,
		fd.[Start],
		p.FullName,
		a.AirportName,
		fd.TicketPrice
FROM FlightDestinations AS fd
JOIN Passengers AS p ON fd.PassengerId = p.Id
JOIN Airports AS a ON fd.AirportId = a.Id
WHERE DAY(fd.[Start]) % 2 = 0
ORDER BY fd.TicketPrice DESC, a.AirportName 

--08. Number of Flights for Each Aircraft
SELECT a.Id AS AircraftId,
		a.Manufacturer,
		a.FlightHours,
		COUNT(fd.Id) AS FlightDestinationsCount,
		ROUND(AVG(fd.TicketPrice), 2) AS AvgPrice
FROM Aircraft AS a
JOIN FlightDestinations AS fd
ON a.Id = fd.AircraftId
GROUP BY a.Id, a.Manufacturer, a.FlightHours
HAVING COUNT(fd.Id) >= 2
ORDER BY FlightDestinationsCount DESC, a.Id

--09. Regular Passengers
SELECT p.FullName,
		COUNT(*) AS CountOfAircraft,
		SUM(fd.TicketPrice) AS TotalPayed
FROM Passengers AS p
JOIN FlightDestinations AS fd
ON p.Id = fd.PassengerId
WHERE SUBSTRING(p.FullName, 2, 1) = 'a'
GROUP BY p.FullName
HAVING COUNT(*) > 1
ORDER BY p.FullName

--10. Full Info for Flight Destinations
SELECT ap.AirportName,
		fd.[Start] AS DayTime,
		fd.TicketPrice,
		p.FullName,
		a.Manufacturer,
		a.Model
FROM FlightDestinations AS fd
JOIN Aircraft AS a
ON fd.AircraftId = a.Id
JOIN Passengers AS p
ON fd.PassengerId = p.Id
JOIN Airports AS ap
ON fd.AirportId = ap.Id
WHERE DATEPART(HOUR, fd.[Start]) BETWEEN 6 AND 20
AND fd.TicketPrice > 2500
ORDER BY a.Model

--11. Find all Destinations by Email Address
GO
CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT 
AS
BEGIN
	RETURN
	(
		SELECT COUNT(*) 
		FROM Passengers AS p
		JOIN FlightDestinations AS fd
		ON fd.PassengerId = p.Id
		WHERE p.Email = @email
	)
END
GO

SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com')

--12. Full Info for Airports
GO
CREATE PROC usp_SearchByAirportName(@airportName VARCHAR(70))
AS
BEGIN
	SELECT a.AirportName,
			p.FullName,
			CASE
				WHEN fd.TicketPrice <= 400 THEN 'Low'
				WHEN fd.TicketPrice <= 1500 THEN 'Medium'
				ELSE 'High'
			END AS LevelOfTickerPrice,
			ac.Manufacturer,
			ac.Condition,
			[at].TypeName
	FROM Airports AS a
	JOIN FlightDestinations AS fd
	ON a.Id = fd.AirportId
	JOIN Passengers AS p 
	ON fd.PassengerId = p.Id
	JOIN Aircraft AS ac
	ON fd.AircraftId = ac.Id
	JOIN AircraftTypes AS [at]
	ON ac.TypeId = [at].Id
	WHERE a.[AirportName] = @airportName
	ORDER BY ac.Manufacturer, p.FullName
END
GO

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'