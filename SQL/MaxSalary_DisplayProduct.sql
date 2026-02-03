USE Practice4;
--Employees table
CREATE TABLE Employees
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50), 
    Dept NVARCHAR(50),
    Salary DECIMAL(18,2)
);
INSERT INTO Employees (Name, Dept, Salary) VALUES
('Alice Johnson', 'HR', 60000),
('Bob Smith', 'IT', 75000),
('Charlie Brown', 'Finance', 80000),
('Diana Prince', 'IT', 72000),
('Ethan Hunt', 'Operations', 68000);

--Find Employees With Highest Salary per Department
SELECT Dept, Name, Salary
FROM Employees e
WHERE Salary = (
    SELECT MAX(Salary)
    FROM Employees
    WHERE Dept = e.Dept
);


-- Products table
CREATE TABLE Products (
    ProductId INT PRIMARY KEY,
    ProductName VARCHAR(50),
    Price DECIMAL(10,2)
);
INSERT INTO Products (ProductId, ProductName, Price) VALUES
(1, 'Laptop', 65000),
(2, 'Mouse', 1000),
(3, 'Keyboard', 1200),
(4, 'Monitor', 11000),
(5, 'Printer', 8500);


-- Sales table
CREATE TABLE Sales (
    SaleId INT PRIMARY KEY,
    ProductId INT,
    SaleDate DATE,
    Quantity INT,
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

INSERT INTO Sales (SaleId, ProductId, SaleDate, Quantity) VALUES
(101, 1, '2025-01-10', 2),
(102, 2, '2025-01-11', 5),
(103, 4, '2025-01-12', 1);
]
--Display Products that never Sold
SELECT p.ProductId, p.ProductName, p.Price
FROM Products p
LEFT JOIN Sales s
    ON p.ProductId = s.ProductId
WHERE s.ProductId IS NULL;

