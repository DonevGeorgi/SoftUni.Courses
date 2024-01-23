CREATE DATABASE TouristAgency

CREATE TABLE Countries(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Destinations(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	CountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Rooms(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(40) NOT NULL,
	Price DECIMAL(18,2) NOT NULL,
	BedCount INT NOT NULL CHECK(BedCount BETWEEN 1 AND 10)
)

CREATE TABLE Hotels(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DestinationId INT NOT NULL FOREIGN KEY REFERENCES Destinations(Id)
)

CREATE TABLE Tourists(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	Email VARCHAR(80),
	CountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Bookings(
	Id INT PRIMARY KEY IDENTITY,
	ArrivalDate DATETIME2 NOT NULL,
	DepartureDate DATETIME2 NOT NULL,
	AdultsCount INT NOT NULL CHECK(AdultsCount BETWEEN 1 AND 10),
	ChildrenCount INT NOT NULL CHECK(ChildrenCount BETWEEN 0 AND 9),
	TouristId INT NOT NULL FOREIGN KEY REFERENCES Tourists(Id),
	HotelId INT NOT NULL FOREIGN KEY REFERENCES Hotels(Id),
	RoomId INT NOT NULL FOREIGN KEY REFERENCES Rooms(Id)
)

CREATE TABLE HotelsRooms(
	HotelId INT NOT NULL FOREIGN KEY REFERENCES Hotels(Id),
	RoomId INT NOT NULL FOREIGN KEY REFERENCES Rooms(Id),
	PRIMARY KEY (HotelId,RoomId)
)

INSERT INTO Tourists ([Name],PhoneNumber,Email,CountryId)
	VALUES  ('John Rivers','653-551-1555','john.rivers@example.com',6),
			('Adeline Aglaé','122-654-8726','adeline.aglae@example.com',2),
			('Sergio Ramirez','233-465-2876','s.ramirez@example.com',3),
			('Johan Müller','322-876-9826','j.muller@example.com',7),
			('Eden Smith','551-874-2234','eden.smith@example.com',6)

INSERT INTO Bookings (ArrivalDate,DepartureDate,AdultsCount,ChildrenCount,TouristId,HotelId,RoomId)
	VALUES  ('2024-03-01','2024-03-11',1,0,21,3,5),
			('2023-12-28','2024-01-06',2,1,22,13,3),
			('2023-11-15','2023-11-20',1,2,23,19,7),
			('2023-12-05','2023-12-09',4,0,24,6,4),
			('2024-05-01','2024-05-07',6,0,25,14,6)

	UPDATE Bookings
	SET  DepartureDate = DATEADD(day,1,DepartureDate)
	WHERE MONTH(ArrivalDate) = 12 AND YEAR(ArrivalDate) = 2023 
	
	UPDATE Tourists
	SET Email = NULL
	WHERE [Name] LIKE '%MA%'

DELETE 
FROM Tourists
WHERE [Name] LIKE '% Smith'
DELETE 
FROM Bookings 
WHERE TouristId IN (6,16)


SELECT FORMAT(b.ArrivalDate,'yyyy-MM-dd'),b.AdultsCount,b.ChildrenCount
FROM Bookings AS b
JOIN Rooms AS r ON r.Id = b.RoomId
ORDER BY r.Price DESC, b.ArrivalDate

SELECT h.Id,h.[Name]
FROM Hotels AS h
JOIN HotelsRooms AS hr ON hr.HotelId = h.Id
JOIN Rooms AS r ON r.Id = hr.RoomId
WHERE  r.[Type] = 'VIP Apartment'
ORDER BY (SELECT COUNT(Id)
FROM Bookings) DESC

SELECT t.Id,t.[Name],t.PhoneNumber 
FROM Tourists AS t
LEFT JOIN Bookings AS b ON b.TouristId = t.Id
WHERE b.Id IS NULL
ORDER BY t.[Name]

SELECT TOP(10) h.[Name] AS HotelName,d.[Name] AS DescriptionName, c.[Name] AS CountryName
FROM Bookings AS b
JOIN Hotels AS h ON h.Id = b.HotelId
JOIN Destinations AS d ON d.Id = h.DestinationId
JOIN Countries AS c ON c.Id = d.CountryId
WHERE b.ArrivalDate < '2023/12/31' AND h.Id % 2 = 1
ORDER BY c.[Name],b.ArrivalDate

SELECT h.[Name] AS HotelName, r.Price AS RoomPrice
FROM Bookings AS b
LEFT JOIN Hotels AS h ON h.Id = b.HotelId
LEFT JOIN Rooms AS r ON r.Id = b.RoomId
LEFT JOIN Tourists AS t ON t.Id = b.TouristId
WHERE t.[Name] NOT LIKE '%EZ' AND 
ORDER BY r.Price DESC

SELECT * FROM Bookings

SELECT h.[Name] AS HotelName, SUM(DATEDIFF(DAY,b.ArrivalDate,b.DepartureDate) * r.Price) AS HotelRevenue
FROM Bookings AS b 
JOIN Hotels AS h ON h.Id = b.HotelId
JOIN Rooms AS r ON r.Id = b.RoomId
GROUP BY h.[Name],b.ArrivalDate,b.DepartureDate,r.Price
ORDER BY SUM(DATEDIFF(DAY,b.ArrivalDate,b.DepartureDate) * r.Price) DESC

SELECT h.[Name] AS HotelName, COUNT(SUM(DATEDIFF(DAY,b.ArrivalDate,b.DepartureDate) * r.Price)) AS HotelRevenue
FROM Bookings AS b 
JOIN Hotels AS h ON h.Id = b.HotelId
JOIN Rooms AS r ON r.Id = b.RoomId
GROUP BY h.[Name]

CREATE FUNCTION udf_RoomsWithTourists(@name NVARCHAR(80))
	RETURNS INT
		BEGIN
			DECLARE @total INT = 0
				SELECT @total += (b.AdultsCount + b.ChildrenCount)
				FROM Rooms AS r
				JOIN Bookings AS b ON b.RoomId = r.Id
				WHERE r.[Type] = @name

			RETURN @total
		END;

CREATE PROCEDURE usp_SearchByCountry(@country NVARCHAR(50)) 
	AS 
		SELECT t.[Name],t.PhoneNumber,t.Email,COUNT(b.TouristId) AS CountOfBookings 
		FROM Tourists AS t
		JOIN Countries AS c ON c.Id = t.CountryId
		JOIN Bookings AS b ON b.TouristId = t.Id
		WHERE c.[Name] = @country
		GROUP BY t.[Name],t.PhoneNumber,t.Email
		ORDER BY t.[Name], CountOfBookings DESC