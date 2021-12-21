drop table StoreOrderItem
drop table Inventory
drop table Product
drop table StoreOrder
drop table Customer
drop table StoreLocation
drop procedure UpdateInventory
go
drop view vStoreOrderItem
go
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
	orderTime datetime2 default getdate(),
	LocationId int CONSTRAINT FK_StoreOrder_LocationId Foreign key references StoreLocation(LocationId),
	IsApproved bit default(0),
	Total Float
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
	OrderID int CONSTRAINT FK_StoreOrderItem_OrderID Foreign key references StoreOrder (OrderID) ON DELETE CASCADE,
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

go
create view vStoreOrderItem
as
select OrderID,ProductID,sum(Quantity) as Quantity from StoreOrderItem group by OrderID,ProductID
go
create Procedure UpdateInventory(@OrderID INT,@ret nvarchar(100) out)
as
begin	  
	set @ret ='not sufficient inventory '
	select  @ret='in Product:' +Product.ProductName  from Inventory inner join StoreOrder on Inventory.LocationId = StoreOrder.LocationId 
							inner join vStoreOrderItem on Inventory.ProductID=vStoreOrderItem.ProductID
							inner join Product on Product.ProductID=vStoreOrderItem.ProductID
							where StoreOrder.OrderID=@OrderID and Inventory.Quantity -vStoreOrderItem.Quantity<0
	--if exists(select )
	BEGIN TRAN
	update Inventory set Quantity=Inventory.Quantity -vStoreOrderItem.Quantity from Inventory inner join StoreOrder on Inventory.LocationId = StoreOrder.LocationId 
							inner join vStoreOrderItem on Inventory.ProductID=vStoreOrderItem.ProductID
							where StoreOrder.OrderID=@OrderID 
									
	update StoreOrder set IsApproved=1 where OrderID=@OrderID 
	COMMIT TRAN 
	set @ret= '1'
end
go
insert into StoreLocation (LocationName) Values
		('North Grocery'),
		('Center Grocery'),
		('South Grocery')

insert into Product (ProductName,DefaultPrice) values
	('Bread',4),
	('Milk',3),
	('Cheeze',6),
	('Candy',5),
	('Cola Can',2)

delete Inventory

insert Inventory (ProductID,LocationId,Quantity)
select ProductID,(select LocationId from StoreLocation where StoreLocation.LocationName='North Grocery'),200 from Product

insert Inventory (ProductID,LocationId,Quantity)
select ProductID,(select LocationId from StoreLocation where StoreLocation.LocationName='Center Grocery'),300 from Product

insert Inventory (ProductID,LocationId,Quantity)
select ProductID,(select LocationId from StoreLocation where StoreLocation.LocationName='South Grocery'),10 from Product





SELECT StoreOrder.*,StoreOrderItem.*,StoreLocation.*,Product.ProductName
                  FROM dbo.StoreOrder inner join dbo.StoreOrderItem on StoreOrder.OrderID=StoreOrderItem.OrderID
                                 inner join dbo.StoreLocation on StoreLocation.LocationId=StoreOrder.LocationId
                                 inner join dbo.Product on Product.ProductID=StoreOrderItem.ProductID
                  
				  WHERE StoreOrder.OrderId =4

delete storeorder
select * from customer
