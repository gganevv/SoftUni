--1
SELECT [FirstName], [LastName] FROM Employees 
 WHERE SUBSTRING([FirstName], 1, 2) = 'Sa'

--2
SELECT [FirstName], [LastName] FROM Employees 
 WHERE [LastName] LIKE '%ei%';

--3
SELECT [FirstName] FROM Employees 
 WHERE [DepartmentID] in (3, 10) 
   AND [HireDate] BETWEEN '1995' AND '2006'

--4
SELECT [FirstName], [LastName] FROM Employees 
 WHERE [JobTitle] NOT LIKE '%Engineer%'

--5
   SELECT [Name] FROM Towns 
WHERE LEN([Name]) BETWEEN 5 AND 6
 ORDER BY [Name]

--6
 SELECT * FROM Towns
 WHERE LEFT([Name], 1) IN('M', 'K', 'B', 'E')
  ORDER BY [Name]

--7
SELECT * FROM Towns
WHERE LEFT([Name], 1) NOT IN('R', 'B', 'D')
  ORDER BY [Name]

--8
CREATE VIEW V_EmployeesHiredAfter2000 AS
	 SELECT [FirstName], [LastName] 
       FROM [Employees]
      WHERE [HireDate] > '2000'

--9
SELECT [FirstName], [LastName] 
FROM Employees
WHERE LEN([LastName]) = 5

--10
SELECT [EmployeeID], [FirstName], [LastName], [Salary],
DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS Rank
FROM Employees
WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

--11
SELECT * FROM (
SELECT [EmployeeID], [FirstName], [LastName], [Salary],
DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS Rank
FROM Employees
)
AS [RankedSelection]
WHERE [Salary] BETWEEN 10000 AND 50000 AND [Rank] = 2
ORDER BY [Salary] DESC

--12
SELECT [CountryName] AS [Country Name], [IsoCode] as [ISO Code] FROM [Countries]
WHERE [CountryName] LIKE '%a%a%a%'
ORDER BY [IsoCode]

--13
SELECT [PeakName], [RiverName], LOWER(SUBSTRING([PeakName], 1, LEN([PeakName]) - 1) + [RiverName]) AS [Mix]
FROM [Rivers], [Peaks]
WHERE LEFT([RiverName], 1) = RIGHT([PeakName], 1)
ORDER BY [Mix]

--14
SELECT TOP(50) 
[Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start] FROM Games
WHERE YEAR([Start]) IN ('2011', '2012')
ORDER BY [Start], [Name]

--15
SELECT [Username], 
SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN(Email)) AS [Email Provider] 
FROM Users
ORDER BY [Email Provider], [Username]

--16
SELECT [USername], [IpAddress] FROM Users
WHERE [IpAddress] LIKE '___.1%.%.___'
ORDER BY [Username]

--17
SELECT [Name] as [Game],
CASE
        WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
        WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
		WHEN DATEPART(HOUR, [Start]) >= 18 THEN 'Evening'
		END AS [Part of the Day],
CASE 
		WHEN [Duration] <= 3 THEN 'Extra Short'
		WHEN [Duration] >= 4 AND [Duration] <= 6 THEN 'Short'
		WHEN [Duration] > 6 THEN 'Long'
		ELSE 'Extra Long'
		END AS [Duration]
FROM [Games]
ORDER BY [Name], [Duration]

--18
SELECT [ProductName], 
[OrderDate],
	DATEADD(DAY, 3, [OrderDate]) AS [Pay Due],
	DATEADD(MONTH, 1, [OrderDate]) AS [Deliver Due]
FROM [Orders]