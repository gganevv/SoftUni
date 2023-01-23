--1
CREATE DATABASE Minions;

--2
USE Minions;
CREATE TABLE dbo.Minions
(
Id INT NOT NULL PRIMARY KEY,
Name nvarchar(50) NOT NULL,
Age INT NOT NULL
);

CREATE TABLE dbo.Towns
(
Id INT PRIMARY KEY NOT NULL,
[Name] NVARCHAR(50) NOT NULL
);

--3
ALTER TABLE dbo.Minions
ADD TownId INT NOT NULL
ALTER TABLE dbo.Minions
ADD FOREIGN KEY (Id) REFERENCES Towns(Id);

--4
ALTER TABLE dbo.Minions
ALTER COLUMN Age INT NULL;
INSERT INTO dbo.Towns(Id, [Name])
VALUES (1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna');

INSERT INTO dbo.Minions(Id, Name, Age, TownId)
VALUES (1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2);

--5
TRUNCATE TABLE dbo.Minions;

--6
DROP TABLE Minions;
DROP TABLE Towns;

--7
CREATE TABLE People
(
Id BIGINT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(200) NOT NULL,
Picture NVARCHAR(200) NULL,
Height FLOAT NULL,
[Weight] FLOAT NULL,
Gender varchar(1) NOT NULL,
Birthdate DATETIME2 NOT NULL,
Biography NVARCHAR(MAX) NULL
);

INSERT INTO People([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
VALUES('Ivan', 'ivan.jpg', 1.69, 80, 'M', '1999-12-18', null),
('Stefka', 'stefka.jpg', 1.50, 65, 'F', '1944-03-10', null),
('Pesho', null, 1.80, 77, 'M', '1991-05-14', null),
('Dimitar', 'dimitar.jpg', 1.77, 85, 'M', '1987-09-13', null),
('Biser', null, 1.45, 120, 'M', '1911-11-11', null);

--8
CREATE TABLE Users
(
Id BIGINT PRIMARY KEY IDENTITY(1,1),
Username nvarchar(30) NOT NULL,
[Password] nvarchar(26) NOT NULL,
ProfilePicture VARBINARY(900) NULL,
LastLoginTime DATETIME2 NULL,
IsDeleted bit NOT NULL
);

INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES('Ivan', 'ivanpass', NULL, '1999-12-18', 1),
('Stefka', 'stefkapass', NULL, '1944-03-10', 1),
('Pesho', 'pass', NULL, '1991-05-14', 0),
('Dimitar', 'dimitarpass', NULL, '1987-09-13', 1),
('Biser', 'pass', NULL, '1911-11-11', 0);

--9
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07B66D6821;

ALTER TABLE Users
ADD CONSTRAINT PK_ID_USERNAME PRIMARY KEY (Id, Username);

--10
ALTER TABLE Users
ADD CONSTRAINT CHK_Password CHECK (LEN(Password) >= 4);

--11
ALTER TABLE Users
ADD DEFAULT GETDATE() FOR LastLoginTime;

--12
ALTER TABLE Users
DROP CONSTRAINT PK_ID_USERNAME;

ALTER TABLE Users
ADD CONSTRAINT PK_ID PRIMARY KEY(Id);

ALTER TABLE Users
ADD CONSTRAINT Username CHECK (LEN(Password) >= 3);

--13
CREATE DATABASE Movies;
USE Movies;

CREATE TABLE Directors(
Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
DirectorName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(250) NULL
);

CREATE TABLE Genres(
Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
GenreName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(50) NULL
);

CREATE TABLE Categories(
Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
CategoryName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(250) NULL
);

CREATE TABLE Movies(
Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Title NVARCHAR(50) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
CopyrightYear INT NOT NULL,
Lenght INT NOT NULL,
GenreId INT FOREIGN KEY REFERENCES Genres(Id),
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Rating NVARCHAR(10) NULL,
Notes NVARCHAR(250) NULL
);

INSERT INTO Directors(DirectorName, Notes)
VALUES ('Director1', 'Note'),
('Director2', NULL),
('Director3', 'Note'),
('Director4', NULL),
('Director5', 'Note');

INSERT INTO Genres(GenreName, Notes)
VALUES ('Genre1', 'Note'),
('Genre2', NULL),
('Genre3', 'Note'),
('Genre4', NULL),
('Genre5', 'Note');

INSERT INTO Categories(CategoryName, Notes)
VALUES ('Category1', 'Note'),
('Category2', NULL),
('Category3', 'Note'),
('Category4', NULL),
('Category5', 'Note');

INSERT INTO Movies(Title, DirectorId, CopyrightYear, Lenght, GenreId, CategoryId, Rating, Notes)
VALUES('Title1', 1, 2016, 90, 1, 1, 'A+', NULL),
('Title2', 2, 2016, 120, 2, 2, 'B+', NULL),
('Title3', 3, 2012, 110, 3, 3, 'A', NULL),
('Title4', 4, 2014, 100, 4, 4, 'C', NULL),
('Title5', 5, 2016, 88, 5, 5, 'A+', NULL);

--14
CREATE DATABASE CarRental;
USE CarRental;

CREATE TABLE Categories(
Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
CategoryName NVARCHAR(25) NOT NULL,
DailyRate FLOAT(2) NOT NULL,
WeeklyRate FLOAT(2) NOT NULL,
MonthlyRate FLOAT(2) NOT NULL,
WeekendRate FLOAT(2) NOT NULL
);

CREATE TABLE Cars(
Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
PlateNumber VARCHAR(10) NOT NULL,
Manufacturer VARCHAR(10) NOT NULL,
Model VARCHAR(10) NOT NULL,
CarYear INT NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
Doors INT NOT NULL,
Picture VARCHAR(50) NULL,
Condition VARCHAR(50) NOT NULL,
Available bit NOT NULL
);

CREATE TABLE Employees(
Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Title NVARCHAR(50) NOT NULL,
Notes NVARCHAR(250) NULL
);

CREATE TABLE Customers(
Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
DriverLicenceNumber VARCHAR(20) NULL,
FullName NVARCHAR(50) NOT NULL,
[Address] NVARCHAR(50) NOT NULL,
City NVARCHAR(50) NOT NULL,
ZIPCode INT NOT NULL,
Notes NVARCHAR(250) NULL
);

CREATE TABLE RentalOrders(
Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
TankLevel INT NOT NULL,
KilometrageStart INT NOT NULL,
KilometrageEnd INT NOT NULL,
TotalKilometrage INT NOT NULL,
StartDate DATETIME2 NOT NULL,
EndDate DATETIME2 NOT NULL,
TotalDays INT NOT NULL,
RateApplied NVARCHAR(20) NOT NULL,
TaxRate NVARCHAR(20) NOT NULL,
OrderStatus NVARCHAR(20) NOT NULL,
Notes NVARCHAR(250) NULL
);

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES ('Category1', 2.2, 5, 30, 15),
('Category2', 3.2, 6, 40, 20),
('Category3', 4.2, 7, 50, 30);

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES ('X250X', 'Ford', 'Focus', 2030, 1, 5, NULL, 'New', 1),
('X260X', 'Ford', 'Modne', 2000, 1, 5, NULL, 'New', 2),
('X550X', 'Ford', 'Mondeo', 2010, 1, 5, NULL, 'New', 3);

INSERT INTO Employees(FirstName, LastName, Title, Notes)
VALUES ('Frank', 'Franki', 'Mechanic', NULL),
('Ivan', 'D', 'Cleaaner', NULL),
('Kosta', 'Kostov', 'Retail', NULL);

INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes)
VALUES ('X321412T', 'Franki', '1123 Street', 'Varna', 9000, NULL),
('X321412XZ', 'Dani', '1123 Street', 'Varna', 9000, NULL),
('X321412SD', 'Kot', '1123 Street', 'Varna', 9000, NULL);

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES (1, 1, 1, 50, 110000, 110020, 20, '2023-09-14', '2023-09-15', 1, 'Discount', 'A', 'OK', NULL),
(2, 2, 2, 40, 112000, 112030, 30, '2023-09-13', '2023-09-14', 1, 'Discount', 'A', 'OK', NULL),
(3, 3, 3, 75, 111000, 114000, 3000, '2023-09-13', '2023-09-18', 5, 'Super Discount', 'B', 'OK', NULL);

--15
CREATE DATABASE Hotel
USE Hotel;

CREATE TABLE Employees(
Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Title NVARCHAR(50) NOT NULL,
Notes NVARCHAR(250) NULL
);

CREATE TABLE Customers(
Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
AccountNumber VARCHAR(20) NULL,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
PhoneNumber INT NOT NULL,
EmergencyName NVARCHAR(50) NOT NULL,
EmergencyNumber INT NOT NULL,
Notes NVARCHAR(250) NULL
);

CREATE TABLE RoomStatus(
Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
RoomStatus NVARCHAR(20) NOT NULL,
Notes NVARCHAR(250) NULL
);

CREATE TABLE RoomTypes (
Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
RoomTypes NVARCHAR(20) NOT NULL,
Notes NVARCHAR(250) NULL
);

CREATE TABLE BedTypes (
Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
BedTypes NVARCHAR(20) NOT NULL,
Notes NVARCHAR(250) NULL
);

CREATE TABLE Rooms(
RoomNumber INT PRIMARY KEY NOT NULL IDENTITY(1,1),
RoomType INT FOREIGN KEY REFERENCES RoomTypes(Id),
BedType INT FOREIGN KEY REFERENCES BedTypes(Id),
Rate NVARCHAR(10) NULL,
RoomStatus NVARCHAR(10) NOT NULL,
Notes NVARCHAR(250) NULL
);

CREATE TABLE Payments(
Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate DATETIME2 NOT NULL,
AccountNumber INT NOT NULL,
FirstDateOccupied DATETIME2 NOT NULL,
LastDateOccupied DATETIME2 NOT NULL,
TotalDays INT NOT NULL,
AmountCharged FLOAT(2) NOT NULL,
TaxRate NVARCHAR(20) NOT NULL,
TaxAmount FLOAT(2) NOT NULL,
PaymentTotal FLOAT(2) NOT NULL, 
Notes NVARCHAR(250) NULL
);

CREATE TABLE Occupancies(
Id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
DateOccupied DATETIME2 NOT NULL,
AccountNumber INT NOT NULL,
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
RateApplied NVARCHAR(10) NOT NULL, 
PhoneCharge NVARCHAR(10) NOT NULL,
Notes NVARCHAR(250) NULL
);

INSERT INTO Employees(FirstName, LastName, Title, Notes)
VALUES ('Frank', 'Franki', 'Mechanic', NULL),
('Ivan', 'D', 'Cleaaner', NULL),
('Kosta', 'Kostov', 'Retail', NULL);

INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES ('AZ1234', 'Ivan', 'Ivanov', 88932514, 'G', 13122225, NULL),
('AZ1231234', 'PETUR', 'Ivanov', 889213514, 'G', 43112225, NULL),
('AZ1231234', 'HRISTO', 'Ivanov', 8892514, 'G', 4321225, NULL);

INSERT INTO RoomStatus(RoomStatus, Notes)
VALUES('FREE', NULL),
('NOT FREE', NULL),
('IN REMONT', NULL);

INSERT INTO RoomTypes(RoomTypes, Notes)
VALUES('Studio', NULL),
('Apartment', NULL),
('Under the bridge', NULL);

INSERT INTO BedTypes (BedTypes, Notes)
VALUES('Single', NULL),
('Double', NULL),
('Couch', NULL);

INSERT INTO Rooms(RoomType, BedType, Rate, RoomStatus, Notes)
VALUES (1, 1, 'A', 'CLEAN', NULL),
(2, 2, 'B', 'NOT CLEAN', NULL),
(3, 3, 'A', 'CLEAN', NULL);

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES (1, '2023-09-13', 123312312, '2023-09-13', '2023-09-15', 2, 20, 'D', 2, 22, NULL),
(2, '2023-09-13', 123312312, '2023-09-13', '2023-09-15', 2, 20, 'D', 2, 22, NULL),
(3, '2023-09-13', 123312312, '2023-09-13', '2023-09-15', 2, 20, 'D', 2, 22, NULL)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES (1, '2023-09-13', 123312312, 1, 'D', 'YES', NULL),
(1, '2023-09-15', 1234555, 2, 'a', 'NO', NULL),
(1, '2023-09-18', 545312, 3, 'A', 'NO', NULL)

--16
CREATE DATABASE SoftUni
GO
USE SoftUni
GO

CREATE TABLE Towns(
[Id] INT NOT NULL PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
[Id] INT NOT NULL PRIMARY KEY IDENTITY,
[AdressText] NVARCHAR(50) NOT NULL,
[TownId] INT FOREIGN KEY REFERENCES [Towns](Id) UNIQUE
)

CREATE TABLE Departments(
[Id] INT NOT NULL PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
[Id] INT PRIMARY KEY NOT NULL IDENTITY,
[FirstName] NVARCHAR(50) NOT NULL,
[MiddleName] NVARCHAR(50) NOT NULL,
[LastName] NVARCHAR(50) NOT NULL,
[JobTitle] NVARCHAR(50) NOT NULL,
[DepartmentId] INT FOREIGN KEY REFERENCES [Departments](Id),
[HireDate] DATETIME2 NOT NULL,
[Salary] DECIMAL(8,2) NOT NULL,
[AddressId] INT FOREIGN KEY REFERENCES [Addresses](Id)
)

--17
--BACKUP-DELETE-RESTORE

--18
INSERT INTO Towns([Name])
VALUES ('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments([Name])
VALUES ('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary])
VALUES ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 3525.25),
('Georgi', 'Taziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)

--19
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--20
SELECT * FROM Towns ORDER BY [Name] ASC
SELECT * FROM Departments ORDER BY [Name] ASC
SELECT * FROM Employees ORDER BY [Salary] DESC

--21
SELECT [Name] FROM Towns ORDER BY [Name] ASC
SELECT [Name] FROM Departments ORDER BY [Name] ASC
SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM Employees ORDER BY [Salary] DESC

--22
UPDATE Employees
SET [Salary] *= 1.1;

SELECT [Salary] FROM Employees

--23
USE Hotel
UPDATE Payments
SET [TaxRate] *= 0.97;

SELECT [TaxRate] FROM Payments

--24
TRUNCATE TABLE Occupancies