--1
SELECT COUNT(*) 
	AS [Count]
  FROM [WizzardDeposits]

--2
SELECT MAX([MagicWandSize]) 
    AS [LongestMagicWand]
  FROM [WizzardDeposits]

--3
  SELECT [DepositGroup],
         MAX([MagicWandSize])
	  AS [LonguestMagicWand]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]

--4
  SELECT
  TOP(2) [DepositGroup]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]
ORDER BY AVG([MagicWandSize])

--5
  SELECT [DepositGroup],
         SUM([DepositAmount])
	  AS [TotalSum]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]

--6
  SELECT [DepositGroup],
         SUM([DepositAmount])
	  AS [TotalSum]
    FROM [WizzardDeposits]
   WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]

--7
 SELECT [DepositGroup],
         SUM([DepositAmount])
	  AS [TotalSum]
    FROM [WizzardDeposits]
   WHERE [MagicWandCreator] = 'Ollivander family' 
GROUP BY [DepositGroup]
  HAVING SUM([DepositAmount]) < 150000
ORDER BY SUM([DepositAmount]) DESC

--8
  SELECT [DepositGroup]
  ,[MagicWandCreator]
    ,MIN([DepositCharge])
	  AS [MinDepositCharge]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup], [MagicWandCreator]
ORDER BY [MagicWandCreator], [DepositGroup]

--9
SELECT [AgeGroup],
 COUNT([AgeGroup])
	AS [WizardCount]
  FROM
     (
       SELECT 
         CASE
		 WHEN Age >= 0 AND AGE <= 10 THEN '[0-10]'
		 WHEN Age >= 11 AND AGE <= 20 THEN '[11-20]'
		 WHEN Age >= 21 AND AGE <= 30 THEN '[21-30]'
		 WHEN Age >= 31 AND AGE <= 40 THEN '[31-40]'
		 WHEN Age >= 41 AND AGE <= 50 THEN '[41-50]'
		 WHEN Age >= 51 AND AGE <= 60 THEN '[51-60]'
		 WHEN Age >= 61 THEN '[61+]'
	   END AS [AgeGroup]
		 FROM [WizzardDeposits]
	) AS [a]
GROUP BY [AgeGroup]

--10
SELECT DISTINCT SUBSTRING([FirstName], 1, 1) 
		   FROM [WizzardDeposits]
		  WHERE [DepositGroup] = 'Troll Chest';

--11
  SELECT [DepositGroup], 
	     [IsDepositExpired], 
     AVG([DepositInterest])
	  AS [AverageInterest]
	FROM [WizzardDeposits]
   WHERE [DepositStartDate] > '1.1.1985'
GROUP BY [DepositGroup], [IsDepositExpired]
ORDER BY [DepositGroup] DESC, [IsDepositExpired]

--12
SELECT SUM([Difference])
	AS [SumDifference]
  FROM (
				  SELECT [FirstName]
					  AS [Host Wizard],
						 [DepositAmount],
					LEAD([FirstName]) OVER(ORDER BY[Id])
					  AS [Host Wizzard Deposit],
			        LEAD([DepositAmount]) OVER(ORDER BY [Id])
					  AS [Guest Wizzard Deposit],
						 [DepositAmount] - LEAD([DepositAmount]) OVER(ORDER BY [Id])
					  AS [Difference]
					FROM [WizzardDeposits]
		) AS [DifferenceSubquery]

--13
  SELECT [DepartmentId], 
         SUM([Salary])
    FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]

--14
  SELECT [DepartmentId],
	     MIN([Salary])
	  AS [MinimumSalary]
    FROM [Employees]
   WHERE [DepartmentID] IN (2, 5, 7)
     AND [HireDate] > '1.1.2000'
GROUP BY [DepartmentID]

--15
SELECT *
  INTO [SalariesNew]
  FROM [Employees]
 WHERE [Salary] > 30000

DELETE 
 FROM [SalariesNew]
WHERE [ManagerID] = 42

UPDATE [SalariesNew]
   SET [Salary] += 5000
 WHERE [DepartmentID] = 1

  SELECT [DepartmentId],
		 AVG(Salary)
	  AS [AverageSalary]
    FROM [SalariesNew]
GROUP BY [DepartmentID]

--16
  SELECT [DepartmentId],
         MAX([Salary]) 
      AS [MaxSalary] 
    FROM [Employees]
GROUP BY [DepartmentID]
HAVING MAX([Salary]) < 30000 OR MAX([Salary]) > 70000

--17
SELECT COUNT(*) 
	AS [Count]
  FROM [Employees] 
 WHERE [ManagerID] IS NULL