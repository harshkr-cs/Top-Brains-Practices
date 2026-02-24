USE Practice1;
SELECT * FROM dbo.CollageMaster;

CREATE OR ALTER TRIGGER prevent_update
ON dbo.CollageMaster
FOR UPDATE
AS
BEGIN
     RAISERROR('You can not update in this table',16,1);
     ROLLBACK;
END;

UPDATE dbo.CollageMaster SET Address='Chennai';

--Employees Table Creation
CREATE TABLE Employees(
    EmpID INT PRIMARY KEY IDENTITY(1,1),
    EmpName NVARCHAR(50),
    EmpSal DECIMAL(10,2)
);

INSERT INTO Employees(EmpName,EmpSal) VALUES
('John Doe',50000.00),
('Harsh Kumar',70000.00);

SELECT * FROM Employees;
--CREATE an audit table
CREATE TABLE Employee_Audit(
    EmpId INT,
    EmpName NVARCHAR(100),
    EmpSal DECIMAL(10,2),
    Audit_Action NVARCHAR(100),
    Audit_Timestamp DATETIME
);

--Trigger Creation for Employees Table
create OR ALTER trigger trgAfterInsertEmployee
on Employees
after Insert
as 
begin
set noCount on;

insert into Employee_Audit(EmpId,EmpName,EmpSal,Audit_Action,Audit_Timestamp)
select
i.EmpId,
i.EmpName,
i.EmpSal,
'Inserted Record',
GetDate()
from
inserted as i;
end
Go

SELECT * FROM Employee_Audit;
--Create Audit Table (One time)
CREATE TABLE AuditLog
(
    AuditID INT IDENTITY PRIMARY KEY,
    TableName SYSNAME,
    Operation VARCHAR(10),
    ChangedDate DATETIME DEFAULT GETDATE()
);
CREATE OR ALTER TRIGGER trg_Audit_YourTable
ON AuditLog
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Operation VARCHAR(10);

    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @Operation = 'UPDATE';
    ELSE IF EXISTS (SELECT * FROM inserted)
        SET @Operation = 'INSERT';
    ELSE
        SET @Operation = 'DELETE';

    INSERT INTO AuditLog (TableName, Operation)
    VALUES ('AuditLog', @Operation);
END;

SELECT * FROM AuditLog;

