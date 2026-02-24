USE ADO_NET;

SELECT * from Students;

CREATE TABLE Students1
(
    Id INT PRIMARY KEY,
    Name NVARCHAR(100),
    Marks INT
);
SELECT * from Students1;

--Create product table
CREATE TABLE Products
(
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100),
    Price DECIMAL(10,2),
    Stock INT
);
INSERT INTO Products (ProductName, Price, Stock) VALUES
('Laptop', 75000, 10),
('Mouse', 500, 50),
('Keyboard', 1500, 30);
SELECT * FROM Products;
