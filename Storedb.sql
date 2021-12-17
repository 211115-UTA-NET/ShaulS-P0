CREATE TABLE Customer
(
	CustomerID int Identity (1,1) Primary key,
	FirstName Varchar(50) Not Null,
	LastName VARCHAR(50) Not Null
)

CREATE TABLE StoreLocation
(
	LocationId int Identity (1,1) Primary key,
	LocationName NVARCHAR(50)
)

CREATE TABLE StoreOrder
(
	OrderID int Identity (1,1) Primary key,
	CustomerID int Foreign key references Customer (CustomerID),
	ordertime datetime,
	LocationId int Foreign key references StoreLocation(LocationId)
)

CREATE TABLE Product
(
	ProductID int identity (1,1) Primary Key,
	ProductName NVARCHAR(100) NOT NULL,
	DefaultPrice Float
)

CREATE TABLE StoreOrderItem
(
	ID int Identity (1,1) Primary key,
	OrderID int Foreign key references StoreOrder (OrderID),
	ProductID int Foreign key references Product (ProductID),
	Quantity int not Null Default(1),
	Price float not Null,
	TotalLine as Quantity*Price
)

CREATE TABLE Inventory
(
	ProductID int Foreign key references Product (ProductID),
	LocationId int Foreign key references StoreLocation(LocationId),
	Quantity int not Null Default(0),
	Primary key (ProductID,LocationId)
)
insert Customer (FirstName,LastName) Values
		('Shaul','Stavi'),
		('Orit','Stavi')