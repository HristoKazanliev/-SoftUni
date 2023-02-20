CREATE DATABASE Boardgames 
GO
USE Boardgames
GO
--Section 1. DDL (30 pts)
CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	StreetName NVARCHAR(100) NOT NULL,
	StreetNumber INT NOT NULL,
	Town VARCHAR(30) NOT NULL,
	Country VARCHAR(50) NOT NULL,
	ZIP INT NOT NULL,
)

CREATE TABLE Publishers
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) UNIQUE NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL,
	Website NVARCHAR(40),
	Phone NVARCHAR(20) 
)

CREATE TABLE PlayersRanges
(
	Id INT PRIMARY KEY IDENTITY,
	PlayersMin INT NOT NULL,
	PlayersMax INT NOT NULL
)

CREATE TABLE Boardgames
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	YearPublished INT NOT NULL,
	Rating Decimal(18,2)  NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	PublisherId INT FOREIGN KEY REFERENCES Publishers(Id) NOT NULL,
	PlayersRangeId INT FOREIGN KEY REFERENCES PlayersRanges(Id) NOT NULL
)

CREATE TABLE Creators
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(30) NOT NULL,
)

CREATE TABLE CreatorsBoardgames
(
	CreatorId INT FOREIGN KEY REFERENCES Creators(Id) NOT NULL,
	BoardgameId INT FOREIGN KEY REFERENCES Boardgames(Id) NOT NULL,
	PRIMARY KEY(CreatorId, BoardgameId)
)

--Section 2. DML (10 pts)
--02. Insert
INSERT INTO Publishers([Name], AddressId, Website, Phone)
	VALUES
('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')

INSERT INTO Boardgames([Name], YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId)
	VALUES
('Deep Blue', 2019, 5.67, 1, 15, 7),
('Paris', 2016, 9.78, 7, 1, 5),
('Catan: Starfarerse', 2021, 9.87, 7, 13, 6),
('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
('One Small Step', 2019, 5.75, 5, 9, 2)

SELECT * FROM Boardgames
--03. Update
SELECT * FROM PlayersRanges

UPDATE Boardgames
	SET [Name] = CONCAT([Name], 'V2')
	WHERE YearPublished >= 2020

UPDATE PlayersRanges
	SET PlayersMax = PlayersMax + 1
	WHERE PlayersMin = 2 AND PlayersMax = 2

--04. Delete
DELETE FROM CreatorsBoardgames
WHERE BoardgameId IN (1, 16, 31, 47)

DELETE FROM Boardgames
WHERE PublisherId IN (1,16)

DELETE FROM Publishers
WHERE AddressId = 5

DELETE FROM Addresses
WHERE SUBSTRING(Town,1,1) = 'L'

--05. Boardgames by Year of Publication
SELECT [Name], Rating
FROM Boardgames
ORDER BY YearPublished, [Name] DESC

--06. Boardgames by Category
SELECT bg.Id, bg.[Name], bg.YearPublished, c.[Name] 
FROM Boardgames AS bg
JOIN Categories AS c
ON bg.CategoryId = c.Id
WHERE c.[Name] = 'Wargames' OR c.[Name] = 'Strategy Games'
ORDER BY bg.YearPublished DESC

--07. Creators without Boardgames
SELECT c.Id, CONCAT(c.FirstName, ' ', c.LastName) AS CreatorName, c.Email
FROM Creators AS c
LEFT JOIN CreatorsBoardgames AS cb
ON c.Id = cb.CreatorId
LEFT JOIN Boardgames AS b
ON cb.BoardgameId = b.Id
WHERE cb.BoardgameId IS NULL

--08. First 5 Boardgames
SELECT TOP(5)
		b.[Name],
		b.Rating,
		c.[Name]
FROM Boardgames AS b
JOIN PlayersRanges AS pr 
ON b.PlayersRangeId = pr.Id
JOIN Categories AS c
ON b.CategoryId = c.Id
WHERE (b.Rating > 7.00 AND b.[Name] LIKE '%a%')
	  OR (b.Rating > 7.50 AND pr.PlayersMin = 2 AND pr.PlayersMax = 5)
ORDER BY b.[Name], b.Rating DESC

--09. Creators with Emails
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
		c.Email,
		MAX(b.Rating) AS Rating
FROM Creators AS c
JOIN CreatorsBoardgames AS cb
ON c.Id = cb.CreatorId
JOIN Boardgames AS b
ON cb.BoardgameId = b.Id
WHERE c.Email LIKE '%.com'
GROUP BY c.FirstName, c.LastName, c.Email
ORDER BY FullName 

--10. Creators by Rating
SELECT c.LastName, CEILING(AVG(b.Rating)) AS AverageRating, p.[Name] AS PublisherName
FROM Creators AS c
JOIN CreatorsBoardgames AS cb
ON c.Id = cb.CreatorId
JOIN Boardgames AS b
ON cb.BoardgameId = b.Id
JOIN Publishers AS p
ON b.PublisherId = p.Id
WHERE p.[Name] = 'Stonemaier Games'
GROUP BY c.LastName, p.[Name]
ORDER BY AVG(b.Rating) DESC

--11. Creator with Boardgames
GO
CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT 
AS
BEGIN
	RETURN
	(
		SELECT COUNT(*) 
		FROM Creators AS c
		JOIN CreatorsBoardgames AS cb
		ON cb.CreatorId = c.Id
		WHERE c.FirstName = @name
	)
END
GO

SELECT dbo.udf_CreatorWithBoardgames('Bruno')
--12. Search for Boardgame with Specific Category
GO
CREATE PROC usp_SearchByCategory(@category VARCHAR(50)) 
AS
BEGIN
	SELECT b.[Name],
			b.YearPublished,
			b.Rating,
			c.[Name],
			p.[Name],
			CONCAT(pr.PlayersMin, ' people') As MinPlayers,
			CONCAT(pr.PlayersMax, ' people') As MinPlayers
	FROM Boardgames AS b
	JOIN Categories AS c 
	ON b.CategoryId = c.Id
	JOIN Publishers AS p
	ON b.PublisherId = p.Id
	JOIN PlayersRanges AS pr
	ON pr.Id = b.PlayersRangeId
	WHERE c.[Name] = @category
	ORDER BY p.[Name], b.YearPublished DESC
END
GO

EXEC usp_SearchByCategory 'Wargames'