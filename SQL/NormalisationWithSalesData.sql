--Normalize the table and sales information retrieval
USE Practice3;
--Q1:
CREATE TABLE CustomersMaster
(
    CustId INT IDENTITY(1,1) PRIMARY KEY,
    CustName NVARCHAR(50),
    CustPhone VARCHAR(10),
    CustCity NVARCHAR(50),

    CONSTRAINT CK_CustomersMaster_Phone
    CHECK (LEN(CustPhone) = 10 AND CustPhone NOT LIKE '%[^0-9]%')
);


INSERT INTO CustomersMaster(CustName,CustPhone,CustCity) 
VALUES('Mariya','9857632101','Tamil Nadu'),
('Harsh Kumar','7979912032','Bihar'),
('Prince Kumar','7979765840','Bangluru'),
('Raman','8754432190','Kerla');

SELECT * FROM CustomersMaster;


CREATE TABLE ProductMaster
(
      ProdId INT PRIMARY KEY IDENTITY(1,1),
      ProdName NVARCHAR(50),
      PriceUnit DECIMAL(10,2)
);

INSERT INTO ProductMaster(ProdName,PriceUnit)
VALUES('Mobile Phone',10000),
('EarBird',3000),
('Charger',1500),
('Shoes',1200);

SELECT * FROM ProductMaster;

CREATE TABLE SalesMaster(
SalesId INT PRIMARY KEY IDENTITY(1,1),
SalesPerson NVARCHAR(50)
);
INSERT INTO SalesMaster(SalesPerson)
VALUES('X'),
('Y'),
('Z');

SELECT * FROM SalesMaster;


CREATE TABLE OrderMaster(
  OrderId INT PRIMARY KEY IDENTITY(1,1),
  OrderDate DATE,
  CustId INT,
  SalesId INT
  FOREIGN KEY(CustId) REFERENCES CustomersMaster(CustId),
  FOREIGN KEY(SalesId) REFERENCES SalesMaster(SalesId)
);

INSERT INTO OrderMaster(OrderDate,CustId,SalesId)
VALUES('2026-05-12',1,2),
('2026-08-22',2,3),
('2026-11-27',3,2),
('2026-10-20',4,2);

SELECT * FROM OrderMaster;



CREATE TABLE OrderDetails(
OrderDetailsId INT PRIMARY KEY IDENTITY(1,1),
OrderId INT,
ProductId INT,
Quantity INT
FOREIGN KEY(OrderId) REFERENCES CustomersMaster(CustId),
FOREIGN KEY(ProductId) REFERENCES ProductMaster(ProdId)
);

INSERT INTO OrderDetails(OrderId,ProductId,Quantity)
VALUES(1,2,3),
(2,1,2),
(3,2,1);

SELECT * FROM OrderDetails;
