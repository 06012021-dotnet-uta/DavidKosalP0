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

Create table StoreOrder(
	OrderID int Primary Key Identity,
	OrderTime datetime,
	CustomerID int Foreign Key References Customer(CustomerID),
	LocationID int Foreign Key References Location(LocationID),
	ProductID int Foreign Key References Product(ProductID),
	Quantity int
);

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


