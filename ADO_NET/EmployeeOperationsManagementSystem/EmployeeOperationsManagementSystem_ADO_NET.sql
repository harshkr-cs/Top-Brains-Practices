USE ADO_NET;
--Create Employees table
CREATE TABLE Employees
(
    EmpId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Department NVARCHAR(50) NOT NULL,
    Phone NVARCHAR(15),
    Email NVARCHAR(100)
);

INSERT INTO Employees (Name, Department, Phone, Email) VALUES
('Ravi Kumar', 'IT', '9876543210', 'ravi@company.com'),
('Amit Sharma', 'Sales', '9876543211', 'amit@company.com'),
('Priya Singh', 'HR', '9876543212', 'priya@company.com'),
('Karan Mehta', 'Sales', '9876543213', 'karan@company.com'),
('Neha Verma', 'IT', '9876543214', 'neha@company.com'),
('Simran Kaur', 'Sales', '9876543215', 'simran@company.com'),
('Rahul Das', 'IT', '9876543216', 'rahul@company.com'),
('Duplicate Phone', 'HR', '9876543212', 'dup1@company.com'),
('Duplicate Email', 'Sales', '9999999999', 'amit@company.com');

SELECT * FROM Employees;
--Create Orders table with foreign key reference to Employees
CREATE TABLE Orders
(
    OrderId INT PRIMARY KEY IDENTITY(1001,1),
    EmpId INT,
    OrderAmount DECIMAL(10,2),
    OrderDate DATE,
    FOREIGN KEY (EmpId) REFERENCES Employees(EmpId)
);
INSERT INTO Orders (EmpId, OrderAmount, OrderDate) VALUES
(2, 25000.00, '2024-01-10'),
(2, 18000.00, '2024-02-15'),
(4, 32000.00, '2024-03-05'),
(6, 15000.00, '2024-03-12'),
(1, 22000.00, '2024-04-01'),
(5, 27000.00, '2024-04-10'),
(7, 30000.00, '2024-05-01');
SELECT * FROM Orders;

CREATE PROCEDURE sp_GetEmployeesByDepartment
    @Department NVARCHAR(50)
AS
BEGIN
    SELECT EmpId, Name, Department, Phone, Email
    FROM Employees
    WHERE Department = @Department
END


CREATE OR ALTER PROCEDURE sp_GetDepartmentEmployeeCount
    @Department NVARCHAR(50),
    @TotalEmployees INT OUTPUT
AS
BEGIN
    SELECT @TotalEmployees = COUNT(*)
    FROM Employees
    WHERE Department = @Department
END

CREATE OR ALTER PROCEDURE sp_GetEmployeeOrders
AS
BEGIN
    SELECT 
        E.Name,
        E.Department,
        O.OrderId,
        O.OrderAmount,
        O.OrderDate
    FROM Employees E
    INNER JOIN Orders O
        ON E.EmpId = O.EmpId
END

SELECT Phone, COUNT(*) AS DuplicateCount
FROM Employees
GROUP BY Phone
HAVING COUNT(*) > 1;

SELECT *
FROM Employees
WHERE Phone IN (
    SELECT Phone
    FROM Employees
    GROUP BY Phone
    HAVING COUNT(*) > 1
)

CREATE OR ALTER PROCEDURE sp_GetDuplicateEmployees
AS
BEGIN
    SELECT *
    FROM Employees
    WHERE Phone IN (
        SELECT Phone
        FROM Employees
        GROUP BY Phone
        HAVING COUNT(*) > 1
    )
    OR Email IN (
        SELECT Email
        FROM Employees
        GROUP BY Email
        HAVING COUNT(*) > 1
    )
END