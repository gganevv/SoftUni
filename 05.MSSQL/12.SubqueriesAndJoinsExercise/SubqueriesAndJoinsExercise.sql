--1
SELECT TOP(5) e.[EmployeeID], e.[JobTitle], e.[AddressID], a.[AddressText] FROM [Employees] AS [e]
INNER JOIN [Addresses] as [a]
ON e.AddressID = a.AddressID
ORDER BY e.[AddressID]

--2
SELECT TOP(50) [FirstName], [LastName], t.[Name] AS [Town], a.[AddressText] FROM [Employees] AS [e]
INNER JOIN [Addresses] AS [a]
ON a.AddressID = e.AddressID
INNER JOIN [Towns] AS [t]
ON a.[TownID] = t.[TownID]
ORDER BY [FirstName], [LastName]

--3
SELECT [EmployeeID], [FirstName], [LastName], d.[Name] FROM Employees AS [e]
INNER JOIN [Departments] AS [d]
ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY d.[Name]

--4
SELECT TOP(5) e.[EmployeeID], e.[FirstName], e.[Salary], d.[Name] AS [DepartmentName] FROM [Employees] AS [e]
INNER JOIN [Departments] AS [d]
ON e.[DepartmentID] = d.[DepartmentID]
WHERE e.[Salary] > 15000
ORDER BY d.[DepartmentID]

--5
SELECT TOP(3) e.[EmployeeID], e.[FirstName] FROM [Employees] AS [e]
LEFT JOIN [EmployeesProjects] AS [ep]
ON e.[EmployeeID] = ep.[EmployeeID]
WHERE ep.[ProjectID] IS NULL

--6
SELECT e.[FirstName], e.[LastName], e.[HireDate], d.[Name] AS [DeptName] FROM [Employees] AS [e]
INNER JOIN [Departments] AS [d]
ON e.[DepartmentID] = d.[DepartmentID]
WHERE e.[HireDate] > '1.1.1999' AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.[HireDate]

--7
SELECT TOP(5) e.[EmployeeID], e.[FirstName], p.[Name] AS [ProjectName] FROM [Employees] AS [e]
INNER JOIN [EmployeesProjects] AS [ep]
ON e.[EmployeeID] = ep.EmployeeID
INNER JOIN [Projects] AS [p]
ON p.[ProjectID] = ep.[ProjectID]
WHERE p.[StartDate] > '2002.08.13' AND p.[EndDate] IS NULL

--8
SELECT e.[EmployeeID], e.[FirstName],
CASE 
WHEN DATEPART(YEAR, p.[StartDate]) >= 2005 THEN NULL
ELSE p.[Name]
END AS [ProjectName]
FROM [Employees] AS [e]
INNER JOIN [EmployeesProjects] AS [ep]
ON e.[EmployeeID] = ep.[EmployeeID]
INNER JOIN [Projects] AS [p]
ON ep.[ProjectID] = p.[ProjectID]
WHERE e.[EmployeeID] = 24

--9
SELECT e.[EmployeeID], e.[FirstName], e.[ManagerID], m.[FirstName] AS [Manager Name] FROM [Employees] AS [e]
INNER JOIN [Employees] AS [m]
ON e.[ManagerID] = m.[EmployeeID]
WHERE e.[ManagerID] IN (3, 7)
ORDER BY e.[EmployeeID]

--10
SELECT TOP(50) e.[EmployeeID], e.[FirstName] + ' ' + e.[LastName] AS [EmployeeName], m.[FirstName] + ' ' + m.[LastName] AS [ManagerName], d.[Name] AS [DepartmentName] FROM [Employees] AS [e]
INNER JOIN [Employees] AS [m]
ON e.[ManagerID] = m.[EmployeeID]
INNER JOIN [Departments] as [d]
ON e.[DepartmentID] = d.[DepartmentID]
ORDER BY e.[EmployeeID]

--11
SELECT
MIN(a.AverageSalary) AS MinAverageSalary
FROM
(
SELECT e.[DepartmentID],
AVG(e.[Salary]) AS [AverageSalary]
FROM [Employees] AS [e]
GROUP BY e.[DepartmentID]
) AS [a]

--12
SELECT c.[CountryCode], m.[MountainRange], p.[PeakName], p.[Elevation] FROM [Countries] AS [c]
INNER JOIN [MountainsCountries] AS [mc]
ON c.[CountryCode] = mc.[CountryCode]
INNER JOIN [Mountains] AS [m]
ON mc.[MountainId] = m.[Id]
INNER JOIN [Peaks] AS [p]
ON p.[MountainId] = m.[Id]
WHERE [CountryName] = 'Bulgaria' AND p.[Elevation] > 2835
ORDER BY p.[Elevation] DESC

--13
SELECT c.[CountryCode], COUNT(m.[MountainRange]) AS [MountainRanges]
FROM [Countries] AS [c]
INNER JOIN [MountainsCountries] AS [mc]
ON c.[CountryCode] = mc.[CountryCode]
INNER JOIN [Mountains] AS [m]
ON mc.[MountainId] = m.[Id]
WHERE [CountryName] IN('Bulgaria', 'Russia', 'United States') 
GROUP BY c.[CountryCode]

--14
     SELECT TOP(5) 
	      c.[CountryName], 
		  r.[RiverName] 
	   FROM [Countries] AS [c]
  LEFT JOIN [CountriesRivers] AS [cr]
         ON [cr].CountryCode = [c].CountryCode
  LEFT JOIN [Rivers] AS [r]
         ON [r].Id = cr.[RiverId]
      WHERE [ContinentCode] = 'AF'
 ORDER BY c.[CountryName]

 --15
 SELECT [ContinentCode], [CurrencyCode], [CurrencyUsage] FROM (
				SELECT *,
						DENSE_RANK() OVER (PARTITION BY [ContinentCode] ORDER BY [CurrencyUsage] DESC)
					AS [CurrencyRank]
				  FROM (
							SELECT [ContinentCode],
								   [CurrencyCode],
								   COUNT(*)
								AS [CurrencyUsage]
		   FROM [Countries]
	   GROUP BY [ContinentCode], [CurrencyCode]
				HAVING COUNT(*) > 1
				) 
			AS [CurrencyUsageSubquerry]
			) 
   AS [CurrencyRankigSubquery]
WHERE [CurrencyRank] = 1


--16
SELECT COUNT(*)
FROM [Countries] AS [c]
LEFT JOIN [MountainsCountries] AS [mc]
ON c.[CountryCode] = mc.[CountryCode]
WHERE mc.[MountainId] IS NULL

--17
SELECT TOP(5) c.[CountryName], MAX(p.Elevation) AS [HighestPeakElevation], MAX(r.Length) AS [LongestRiverLength] FROM [Countries] AS [c]
LEFT JOIN [MountainsCountries] AS [mc]
ON mc.[CountryCode] = c.[CountryCode]
LEFT JOIN Mountains AS [m]
ON m.[Id] = mc.[MountainId]
LEFT JOIN [Peaks] AS [p]
ON p.[MountainId] = m.[Id]
LEFT JOIN [CountriesRivers] AS [cr]
ON cr.[CountryCode] = c.[CountryCode]
LEFT JOIN [Rivers] AS [r]
ON cr.[RiverId] = r.[Id]
GROUP BY c.CountryName
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, c.[CountryName]