
drop table StoreOrderItem
drop table Inventory
drop table Product
drop table StoreOrder
drop table Customer
drop table StoreLocation
drop procedure UpdateInventory

CREATE TABLE Customer
(
	CustomerID int Identity (1,1) Primary key,
	FirstName Varchar(50) Not Null,
	LastName VARCHAR(50) Not Null,
	unique (FirstName,LastName)
)

CREATE TABLE StoreLocation
(
	LocationId int Identity (1,1) Primary key,
	LocationName NVARCHAR(50)
)

CREATE TABLE StoreOrder
(
	OrderID int Identity (1,1) CONSTRAINT PK_StoreOrder_OrderID Primary key,
	CustomerID int CONSTRAINT FK_StoreOrder_CustomerID Foreign key references Customer (CustomerID),
	ordertime datetime2 default getdate(),
	LocationId int CONSTRAINT FK_StoreOrder_LocationId Foreign key references StoreLocation(LocationId),
	IsApproved bit default(0)
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
	OrderID int CONSTRAINT FK_StoreOrderItem_OrderID Foreign key references StoreOrder (OrderID),
	ProductID int CONSTRAINT FK_ProductID_ProductID Foreign key references Product (ProductID),
	Quantity int not Null Default(1),
	Price float not Null,
	TotalLine as Quantity*Price
)

CREATE TABLE Inventory
(
	ProductID int CONSTRAINT FK_Inventory_ProductID Foreign key references Product (ProductID),
	LocationId int CONSTRAINT FK_Inventory_LocationId Foreign key references StoreLocation(LocationId),
	Quantity int not Null Default(0),
	Primary key (ProductID,LocationId),
	CONSTRAINT CK_Quantity_NOT_NEGETIVE Check (Quantity>=0)	
)


create Procedure UpdateInventory(@OrderID INT)
as
begin	  
	BEGIN TRAN
	update Inventory set Quantity=Inventory.Quantity -StoreOrderItem.Quantity from Inventory inner join StoreOrder on Inventory.LocationId = StoreOrder.LocationId 
							inner join StoreOrderItem on Inventory.ProductID=StoreOrderItem.ProductID
							where StoreOrder.OrderID=@OrderID 
									
	update StoreOrder set IsApproved=1 where OrderID=@OrderID 
	COMMIT TRAN 
	return 1
end

--insert Customer (FirstName,LastName) Values
--		('Shaul','Stavi'),
--		('Orit','Stavi')

select * from Customer where firstname='shaul'
