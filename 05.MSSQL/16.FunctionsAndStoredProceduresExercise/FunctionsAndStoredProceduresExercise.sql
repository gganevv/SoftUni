--1
CREATE PROCEDURE [usp_GetEmployeesSalaryAbove35000]
AS
BEGIN
SELECT [FirstName], 
	   [LastName] 
  FROM [Employees]
 WHERE [Salary] > 35000
END

GO

--2
CREATE PROCEDURE [usp_GetEmployeesSalaryAboveNumber](@SALARY DECIMAL(18,4))
AS
BEGIN
SELECT [FirstName],
       [LastName]
  FROM [Employees]
 WHERE [Salary] >= @SALARY
END

GO

--3
CREATE PROCEDURE [usp_GetTownsStartingWith](@STR VARCHAR(50))
AS
BEGIN
SELECT [Name] 
    AS [Town] 
  FROM [Towns]
WHERE SUBSTRING(Name, 1, LEN(@STR)) = @STR
END

GO

--4
CREATE PROCEDURE [usp_GetEmployeesFromTown](@TOWNNAME VARCHAR(50))
AS
BEGIN
    SELECT [FirstName], 
           [LastName] 
      FROM [Employees] 
        AS [e]
INNER JOIN [Addresses] 
        AS [a]
        ON e.[AddressID] = a.[AddressID]
INNER JOIN [Towns] 
        AS [t]
        ON t.[townID] = a.[TownID]
     WHERE t.[Name] = @TOWNNAME
END

GO

--5
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10) 
AS
BEGIN
DECLARE @LVL VARCHAR(10)
IF (@salary < 30000)
SET @LVL = 'Low'
ELSE IF @salary BETWEEN 30000 AND 50000
SET @LVL = 'Average'
ELSE 
SET @LVL = 'High'
RETURN @LVL
END

GO

--6
CREATE PROCEDURE [usp_EmployeesBySalaryLevel](@LVL VARCHAR(10))
AS
	BEGIN
			SELECT [FirstName] 
			    AS [First Name], 
				   [LastName] 
				AS [Last Name] 
			  FROM [Employees]
			 WHERE dbo.ufn_GetSalaryLevel([Salary]) = @LVL
	END

GO

--7
CREATE FUNCTION [ufn_IsWordComprised]
(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
DECLARE @index INT = 1;

WHILE @index <= LEN(@word)
	 BEGIN
		DECLARE @char CHAR(1) = SUBSTRING(@word, @index, 1);

			 IF (CHARINDEX(@char, @setOfLetters) = 0)
				RETURN 0

			SET @index += 1
	  END
RETURN 1
END

GO

--9
CREATE PROCEDURE usp_GetHoldersFullName 
AS
BEGIN
SELECT [FirstName] + ' ' + [LastName] AS [Full Name] FROM AccountHolders 
END

GO

--10
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@Money DECIMAL(14,2))
AS
BEGIN
SELECT a.FirstName, a.LastName FROM AccountHolders AS [a]
INNER JOIN Accounts AS [ac]
ON [a].Id = [ac].AccountHolderId
GROUP BY [a].Id, a.FirstName, a.LastName
HAVING SUM(ac.Balance) > @Money
ORDER BY a.FirstName, a.LastName
END

GO

--11
CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(18, 4), @Interest FLOAT, @Years INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN
RETURN @sum * POWER(1 + @Interest, @Years)
END

GO

--12
CREATE PROCEDURE usp_CalculateFutureValueForAccount
(@AccountID INT, @Interest FLOAT)
AS
	SELECT
		acc.[Id] AS [Account Id],
		h.[FirstName] AS [First Name],
		h.[LastName] AS [Last Name],
		acc.[Balance] AS [Current Balance],
		dbo.ufn_CalculateFutureValue(acc.[Balance], @Interest, 5) AS [Balance in 5 years]
	FROM [Accounts] AS [acc]
	JOIN [AccountHolders] AS [h]
		ON acc.[AccountHolderId] = h.[Id]
	WHERE acc.[Id] = @AccountID

GO

EXEC usp_CalculateFutureValueForAccount 2, 0.1