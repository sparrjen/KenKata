Create Table Customers (
	CustomerId int Identity (1,1) primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	PhoneNr varchar(20) not null,
	Email varchar(50) not null,
	Country nvarchar(30) not null,
	Adress nvarchar(50) not null,
	City nvarchar(50) not null,
	ZipCode varchar(10) not null,
	[State] nvarchar(20) not null,
)
GO

CREATE TABLE Categories (
	CategoryId int Identity (1,1) primary key,
	CategoryName nvarchar(50) not null
)
GO

CREATE TABLE Brands (
	BrandId int Identity (1,1) primary key,
	BrandName nvarchar(50) not null,
)
GO

CREATE TABLE Products (
	ProductId int Identity (1,1) primary key,
	ProductName nvarchar(50) not null,
	CategoryId int not null,
	BrandId int not null,
	ShortDescription nvarchar(150) not null,
	LongDescription nvarchar(max) not null,
	Price money not null,
	InStock bit not null,
	Picture varbinary(max)

	FOREIGN KEY (CategoryId)
	REFERENCES Categories (CategoryId),

	FOREIGN KEY (BrandId)
	REFERENCES Brands (BrandId)
)
GO

CREATE TABLE Orders (
	Order_Id int Identity (1,1) primary key,
	CustomerId int not null,
	
	FOREIGN KEY (CustomerId)
	REFERENCES Customers (CustomerId)
)
GO

CREATE TABLE Order_Product (
	Order_Id int,
	ItemId int,
	ProductId int not null,

	PRIMARY KEY (Order_Id, ItemId),

	FOREIGN KEY (Order_Id)
	REFERENCES Orders (Order_Id),

	FOREIGN KEY (ProductId)
	REFERENCES Products (ProductId)	
)