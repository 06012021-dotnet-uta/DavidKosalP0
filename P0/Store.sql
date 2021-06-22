Create table Customer(
	CustomerID int Primary Key Identity,
	FirstName varchar(20) Not Null,
	LastName varchar(20) Not Null,
);

Create table Location(
	LocationID int Primary Key Identity,
	LocationName varchar(20),
);

Create table Product(
	ProductID int Primary Key Identity,
	ProductName varchar(50) Not Null,
	ProductPrice int Not Null,
	ProductDescription varchar(50) Not Null,
);

CREATE TABLE Inventory
(
 ProductId      int NOT NULL ,
 LocationId     int NOT NULL ,
 NumberProducts int NOT NULL ,

 CONSTRAINT PK_inventory PRIMARY KEY CLUSTERED (ProductId, LocationId),
 CONSTRAINT FK_42 FOREIGN KEY (ProductId)  REFERENCES Product(ProductId),
 CONSTRAINT FK_45 FOREIGN KEY (LocationId)  REFERENCES Location(LocationId)
);
GO


CREATE NONCLUSTERED INDEX fkIdx_43 ON Inventory 
 (
  ProductId ASC
 )

GO

CREATE NONCLUSTERED INDEX fkIdx_46 ON Inventory 
 (
  LocationId ASC
 )

GO

Create table StoreOrder(
	OrderID int Primary Key Identity,
	OrderTime datetime,
	CustomerID int Foreign Key References Customer(CustomerID),
	LocationID int Foreign Key References Location(LocationID),
	ProductID int Foreign Key References Product(ProductID),
	Quantity int
);

Create table OrderDetails(
	ProductID int Not null,
	OrderID int Not Null,
	Quantity int
CONSTRAINT PK_orderDetails PRIMARY KEY CLUSTERED (ProductId, OrderId),
 CONSTRAINT FK_1 FOREIGN KEY (ProductId)  REFERENCES Product(ProductId),
 CONSTRAINT FK_2 FOREIGN KEY (OrderId)  REFERENCES StoreOrder(OrderId)
);
GO


CREATE NONCLUSTERED INDEX fkIdx_55 ON Inventory 
 (
  ProductId ASC
 )

GO

CREATE NONCLUSTERED INDEX fkIdx_60 ON Inventory 
 (
  LocationId ASC
 )
GO

Alter table Customer
Add Username varchar(50), Password varchar(50);

Alter table StoreOrder
Drop constraint FK__StoreOrde__Produ__2C3393D0

Drop table OrderDetails;



Insert into Customer(FirstName, LastName)
Values ('John','Smith');
Insert into Customer(FirstName, LastName)
Values ('Mary','Johnson');
Insert into Customer(FirstName, LastName)
Values ('Billy','Bob');
Insert into Customer(FirstName, LastName)
Values ('Joe','Junior');
Insert into Customer(FirstName, LastName)
Values ('Samuel','McOneil');

Insert into Location(LocationName)
Values ('Minneapolis');
Insert into Location(LocationName)
Values ('St. Paul');
Insert into Location(LocationName)
Values ('Bloomington');
Insert into Location(LocationName)
Values ('Richfield');
Insert into Location(LocationName)
Values ('St. Louis Park');

Insert into Product(ProductName, ProductPrice, ProductDescription)
Values ('Iphone', 1000, '256GB Iphone 12 Max Pro');
Insert into Product(ProductName, ProductPrice, ProductDescription)
Values ('Monitor', 500, '32" 1440p 120GHz Asus Monitor');
Insert into Product(ProductName, ProductPrice, ProductDescription)
Values ('Smart Speaker', 20, 'Google Mini Smart Speaker');
Insert into Product(ProductName, ProductPrice, ProductDescription)
Values ('Keyboard', 50, 'Razer Mechanical');
Insert into Product(ProductName, ProductPrice, ProductDescription)
Values ('Mouse', 40, 'Logitech Mouse');

Insert into Inventory(PoductID, LocationID, Quantity)
Values (1,1,10);

SELECT TOP (1000) [InventoryID]
      ,[PoductID]
      ,[LocationID]
      ,[Quantity]
  FROM [Store].[dbo].[Inventory]

  Update Inventory
  Set PoductID = 1, LocationID = 1, Quantity = 10
  Where InventoryID = 1;
