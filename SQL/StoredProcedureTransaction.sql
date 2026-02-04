Use Practice2;
SELECT * FROM CollageMaster1;

CREATE TABLE Hostel (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	HId INT,
	RoomNo INT,
	FOREIGN KEY (HId) REFERENCES CollageMaster2(Id)
);
INSERT INTO Hostel (HId, RoomNo) VALUES 
(1, 101),
(2,102),
(3,103),
(4,102),
(5,103);
SELECT * FROM Hostel;

--UNION is used to combine unique record from two or more table
SELECT * FROM CollageMaster1 WHERE Id BETWEEN 1 AND 5
UNION
SELECT * FROM CollageMaster1 WHERE Id BETWEEN 1 AND 5

--UNION ALL is use d to combine record from twomor moew table with duplicate
SELECT * FROM CollageMaster1 WHERE Id BETWEEN 1 AND 5
UNION ALL
SELECT * FROM CollageMaster1 WHERE Id BETWEEN 1 AND 5

CREATE TABLE BSports(
Id INT IDENTITY(1,1) PRIMARY KEY,
Name NVARCHAR(50) NOT NULL,
SportName NVARCHAR(50) NULL
);

INSERT INTO BSports(Name,SportName) VALUES
('Mariya','Cricket'),
('MariyaA','Cricket'),
('MariyaB','BasketBall');

SELECT * FROM BSports;
DELETE BSports WHERE Id=4 OR Id=5 OR Id=6;

CREATE TABLE UPSports(
Id INT IDENTITY(1,1) PRIMARY KEY,
Name NVARCHAR(50) NOT NULL,
SportName NVARCHAR(50) NULL
);

INSERT INTO UPSports(Name,SportName) VALUES
('Mariya','Cricket'),
('MariyaX','Football'),
('Mariyay','Cricket');

SELECT * FROM UPSports;

SELECT * FROM BSports WHERE SportName='Cricket'
UNION
SELECT * FROM UPSports WHERE SportName='Cricket'

SELECT * FROM BSports WHERE SportName='Cricket'
UNION ALL
SELECT * FROM UPSports WHERE SportName='Cricket'
--Stored Procedured + Transaction EX
create or alter proc dbo.uspAddNewStudentWithHostel
as
begin
begin try
       begin transaction transaction_one;

        declare @NewStudentId int;
        insert into dbo.CollageMaster1
        (
             Name,CourseId
        )
        values
        ('Mr X',2);
        SET @NewStudentId = SCOPE_IDENTITY();
        insert into dbo.Hostel (RoomNo, HId)
        values (@NewStudentId, 4);
        commit transaction transaction_one;
 end try
 begin catch;
         rollback transaction transaction_one;
 throw;
 end catch
end;


exec uspAddNewStudentWithHostel;
select * from CollageMaster1;
select * from Hostel;

CREATE TABLE Student(
Id INT IDENTITY(1,1) PRIMARY KEY,
Name NVARCHAR(50) NOT NULL
);
INSERT INTO Student(Name) VALUES
('Mariya'),
('Arjun'),
('Harsh Kumar'),
('Vibhav'),
('Rahul'),
('sonu');

SELECT * FROM Student;

--String concept
--Printing concetenation of ID and first 3 characters of Name
SELECT Id,CONCAT(Id,substring(Name,0,4) ) as NewName from Student;

--Printing position of character 'r' in Name column
SELECT SUBSTRING(Name,1, charindex('r',Name)) as CharPosition from Student

--Printing substring after character 'r' in Name column
select SUBSTRING(Name,charIndex('r',Name)+1,Len(Name)) as afterR from Student;

--view concept(CREATE VIEW view_Name AS SELECT Statement)
CREATE VIEW V1 AS SELECT Id,Name FROM Student WHERE Id BETWEEN 1 AND 3;

SELECT * FROM V1;

DROP VIEW V1;