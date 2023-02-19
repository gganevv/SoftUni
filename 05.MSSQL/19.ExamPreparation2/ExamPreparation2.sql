CREATE DATABASE Airport
GO

USE Airport
Go

--1
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
			 Age TINYINT NOT NULL CHECK(Age >= 21 AND Age <= 62),
			 Rating FLOAT CHECK(Rating >= 0.0 AND Rating <= 10.0)
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
			 FlightHours INT NULL,
			 Condition CHAR(1) NOT NULL,
			 TypeId INT FOREIGN KEY REFERENCES AircraftTypes(Id) NOT NULL
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
			 Country VARCHAR(100) UNIQUE NOT NULL
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

--2
INSERT INTO [Passengers]([FullName], [Email])
     SELECT [FirstName] + ' ' + [LastName],
	        [FirstName] + [LastName] + '@gmail.com'
       FROM [Pilots]
	  WHERE [Id] >= 5 AND [Id] <= 15

--3
UPDATE [Aircraft]
SET [Condition] = 'A'
WHERE ([Condition] = 'C' OR [Condition] = 'B') AND ([FlightHours] IS NULL OR [FlightHours] <= 100) AND [Year] >= 2013

--4
DELETE FROM [Passengers]
WHERE LEN([FullName]) <= 10

--5
  SELECT [Manufacturer],
	     [Model],
	     [FlightHours],
   	     [Condition]
    FROM [Aircraft]
ORDER BY [FlightHours] DESC

--6
  SELECT p.[FirstName],
	     p.[LastName],
	     a.[Manufacturer],
	     a.[Model],
	     a.[FlightHours]
    FROM [Pilots] AS [p]
    JOIN [PilotsAircraft] AS [pa]
      ON p.[Id] = pa.[PilotId]
    JOIN [Aircraft] AS [a]
      ON pa.[AircraftId] = a.[Id]
   WHERE [FlightHours] < 304
ORDER BY [FlightHours] DESC, p.[FirstName]

--7
SELECT TOP(20)
	           fd.[Id] AS [DestinationId],
			   fd.[Start],
			   p.[FullName],
			   a.[AirportName],
			   fd.[TicketPrice]
		  FROM [FlightDestinations] AS [fd]
		  JOIN [Passengers] AS [p]
		    ON p.[Id] = fd.[PassengerId]
		  JOIN [Airports] AS [a]
		    ON a.[Id] = fd.[AirportId]
		 WHERE DATEPART(DAY, [Start]) % 2 = 0
	  ORDER BY fd.[TicketPrice] DESC, a.[AirportName]

--8
SELECT   a.[Id] AS [AircraftId], 
		 a.[Manufacturer], 
		 a.[FlightHours], 
		 COUNT(*) AS [FlightDestinationsCount],
		 ROUND(AVG(fd.[TicketPrice]), 2) AS [AvgPrice]
    FROM [Aircraft] AS [a]
	JOIN [FlightDestinations] AS [fd]
      ON fd.[AircraftId] = a.[Id]
GROUP BY a.[Id], a.[Manufacturer], a.[FlightHours]
  HAVING COUNT(*) >= 2
ORDER BY COUNT(*) DESC, a.[Id]

--9
  SELECT p.[FullName], 
	     COUNT(*) AS [CountOfAircraft],
	     SUM(fd.[TicketPrice]) AS [TotalPayed]
    FROM [Passengers] AS [p]
    JOIN [FlightDestinations] AS [fd]
      ON fd.[PassengerId] = p.[Id]
GROUP BY p.[FullName]
  HAVING COUNT(*) > 1 AND SUBSTRING(p.[FullName], 2, 1) = 'a'
ORDER BY p.[FullName]

--10
  SELECT a.[AirportName],
	     fd.[Start] AS [DayTime],
	     fd.[TicketPrice],
	     p.[FullName],
	     ac.[Manufacturer],
	     ac.[Model]
    FROM [FlightDestinations] AS [fd]
    JOIN [Airports] AS [a]
      ON fd.[AirportId] = a.[Id]
    JOIN [Passengers] AS [p]
      ON p.[Id] = fd.[PassengerId]
    JOIN [Aircraft] AS [ac]
      ON ac.[Id] = fd.[AircraftId]
   WHERE DATEPART(HOUR, [Start]) >= 6 AND DATEPART(HOUR, [Start]) <= 20 AND [TicketPrice] > 2500
ORDER BY ac.[Model]

--11
GO
CREATE FUNCTION udf_FlightDestinationsByEmail
(@email VARCHAR(50))
RETURNS INT
AS
BEGIN
DECLARE @passengerId INT = (SELECT Id FROM Passengers WHERE Email = @email)
DECLARE @count INT =
(
    SELECT COUNT(Id) FROM FlightDestinations 
    WHERE PassengerId = @passengerId 
    GROUP BY PassengerId    
)
RETURN IIF(@count IS NULL, 0, @count)
END
GO

--12
CREATE PROC usp_SearchByAirportName
(@airportName varchar(70))
AS
BEGIN
  SELECT a.AirportName,
         p.FullName,
    CASE 
    WHEN (fd.TicketPrice <= 400) THEN 'Low'
    WHEN (fd.TicketPrice <= 1500) THEN 'Medium'
    ELSE 'High'
  END AS LevelOfTickerPrice,
		 ac.Manufacturer,
		 ac.Condition,
         at.TypeName
    FROM Airports AS a
    JOIN FlightDestinations AS [fd]
      ON a.[Id] = fd.[AirportId]
    JOIN Passengers AS [p]
      ON fd.[PassengerId] = p.[Id]
    JOIN [Aircraft] AS [ac]
      ON fd.[AircraftId] = ac.[Id]
    JOIN AircraftTypes AS at 
      ON ac.[TypeId] = at.[Id]
   WHERE a.[AirportName] = @airportName
ORDER BY ac.[Manufacturer], p.[FullName]
END