--1
CREATE DATABASE [TableRelations]
USE [TableRelations]

CREATE TABLE [Passports](
[PassportID] INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
[PassportNumber] VARCHAR(20) NOT NULL
)

CREATE TABLE [Persons](
[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[FirstName] NVARCHAR(50) NOT NULL,
[Salary] DECIMAL(8,2) NOT NULL,
[PassportID] INT FOREIGN KEY REFERENCES [Passports](PassportID) NOT NULL UNIQUE
)

INSERT INTO [Passports](PassportNumber)
VALUES ('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

INSERT INTO [Persons](FirstName, Salary, PassportID)
VALUES ('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)

--2
CREATE TABLE [Manufacturers](
[ManufacturerID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] VARCHAR(20) NOT NULL,
[EstablisedOn] DATETIME2 NOT NULL
)

CREATE TABLE [Models](
[ModelID] INT PRIMARY KEY IDENTITY(100,1) NOT NULL,
[Name] VARCHAR(20) NOT NULL,
[ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers](ManufacturerID)
)

INSERT INTO [Manufacturers]([Name], [EstablisedOn])
VALUES ('BMW', '1916-03-07'),
('Tesla', '2003-01-01'),
('Lada', '1966-05-01')

INSERT INTO [Models]([Name], [ManufacturerID])
VALUES ('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3)

--3
CREATE TABLE [Students](
[StudentID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] VARCHAR(20) NOT NULL
)

CREATE TABLE [Exams](
[ExamID] INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
[Name] VARCHAR(20) NOT NULL
)

CREATE TABLE [StudentsExams](
[StudentID] INT FOREIGN KEY REFERENCES [Students](StudentId),
[ExamID] INT FOREIGN KEY REFERENCES [Exams](ExamID),
CONSTRAINT PK_StudentExams PRIMARY KEY(StudentID, ExamID)
)

INSERT INTO [Students]([Name])
VALUES('Mila'),
('Toni'),
('Ron')

INSERT INTO [Exams]([Name])
VALUES('SpringMVC'),
('Neo4j'),
('Oracle 11g')

INSERT INTO [StudentsExams]([StudentID], [ExamID])
VALUES(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

--4
CREATE TABLE [Teachers](
[TeacherID] INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
[Name] VARCHAR(20) NOT NULL,
[ManagerID] INT FOREIGN KEY REFERENCES [Teachers](TeacherID) NULL
)

INSERT INTO [Teachers]([Name], [ManagerID])
VALUES ('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

--5
CREATE TABLE [Cities](
[CityID] INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE [Customers](
[CustomerID] INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(30) NOT NULL,
[Birthday] DATE NOT NULL,
[CityID] INT NOT NULL FOREIGN KEY REFERENCES [Cities](CityID)
)

CREATE TABLE [Orders](
[OrderID] INT PRIMARY KEY IDENTITY NOT NULL,
[CustomerID] INT NOT NULL FOREIGN KEY REFERENCES [Customers](CustomerID)
)

CREATE TABLE [ItemTypes](
[ItemTypeID] INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE [Items](
[ItemID] INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(30) NOT NULL,
[ItemTypeId] INT FOREIGN KEY REFERENCES [ItemTypes](ItemTypeID)
)

CREATE TABLE [OrderItems](
[OrderID] INT NOT NULL FOREIGN KEY REFERENCES [Orders](OrderID),
[ItemID] INT NOT NULL FOREIGN KEY REFERENCES [Items](ItemID),
CONSTRAINT PK_OrderIDItemID PRIMARY KEY(OrderID, ItemID)
)

--6
CREATE TABLE [Subjects](
[SubjectID] INT NOT NULL PRIMARY KEY IDENTITY,
[SubjectName] VARCHAR(50) NOT NULL
)

CREATE TABLE [Majors](
[MajorID] INT NOT NULL PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Students](
[StudentID] INT NOT NULL PRIMARY KEY IDENTITY,
[StudentNumber] INT NOT NULL,
[StudentName] VARCHAR(50),
[MajorID] INT NOT NULL FOREIGN KEY REFERENCES [Majors](MajorID)
)

CREATE TABLE [Agenda](
[StudentID] INT NOT NULL FOREIGN KEY REFERENCES [Students](StudentID),
[SubjectID] INT NOT NULL FOREIGN KEY REFERENCES [Subjects](SubjectID),
CONSTRAINT PK_StudentSubjectID PRIMARY KEY(StudentID, SubjectID)
)

CREATE TABLE [Payments](
[PaymentID] INT NOT NULL PRIMARY KEY IDENTITY,
[PaymentDate] DATETIME2 NOT NULL,
[PaymentAmount] DECIMAL(8,2) NOT NULL,
[StudentID] INT NOT NULL FOREIGN KEY REFERENCES [Students](StudentID)
)

USE Geography
SELECT m.MountainRange, p.PeakName, p.Elevation FROM [Peaks] AS p JOIN [Mountains] AS m ON p.MountainId = m.Id WHERE m.MountainRange = 'Rila' ORDER BY p.Elevation DESC