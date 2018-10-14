USE GuildCars
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Sales')
	DROP TABLE Sales
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Vehicles')
	DROP TABLE Vehicles
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Customers')
	DROP TABLE Customers
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Models')
	DROP TABLE Models
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Makes')
	DROP TABLE Makes
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Transmissions')
	DROP TABLE Transmissions
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Financing')
	DROP TABLE Financing
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='VehicleTypes')
	DROP TABLE VehicleTypes
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='BodyStyles')
	DROP TABLE BodyStyles
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='BodyColors')
	DROP TABLE BodyColors
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='InteriorColors')
	DROP TABLE InteriorColors
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='States')
	DROP TABLE States
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='ContactUs')
	DROP TABLE ContactUs
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Specials')
	DROP TABLE Specials
GO

CREATE TABLE Specials (
	SpecialId int identity (1,1) not null primary key,
	SpecialTitle nvarchar(50) not null,
	SpecialDescription nvarchar(500) not null
)

CREATE TABLE ContactUs (
	ContactUsId int identity (1,1) not null primary key,
	ContactUsFirstName nvarchar(25) not null,
	ContactUsLastName nvarchar(25) not null,
	ContactUsEmail nvarchar(75) null,
	ContactUsPhone nvarchar(25) null,
	ContactUsMessage nvarchar(500) not null
)

CREATE TABLE States (
	StateId char(2) not null primary key,
	StateName varchar(15) not null
)

CREATE TABLE InteriorColors (
	InteriorColorId int identity (1,1) not null primary key,
	InteriorColorDescription varchar(25) not null
)

CREATE TABLE BodyColors (
	BodyColorId int identity (1,1) not null primary key,
	BodyColorDescription varchar(25) not null
)

CREATE TABLE BodyStyles (
	BodyStyleId int identity (1,1) not null primary key,
	BodyStyleDescription varchar(20) not null
)

CREATE TABLE VehicleTypes (
	VehicleTypeId int identity (1,1) not null primary key,
	VehicleTypeDescription varchar(10) not null
)

CREATE TABLE Financing (
	FinancingId int identity (1,1) not null primary key,
	FinancingDescription varchar(20) not null
)

CREATE TABLE Transmissions (
	TransmissionId int identity (1,1) not null primary key,
	TransmissionDescription varchar(20) not null
)

CREATE TABLE Makes (
	MakeId int identity (1,1) not null primary key,
	UserId nvarchar(128) not null,
	MakeDescription nvarchar(25) not null,
	MakeDateAdded datetime2 not null default(getdate())
)

CREATE TABLE Models (
	ModelId int identity (1,1) not null primary key,
	MakeId int not null foreign key references Makes(MakeId),
	UserId nvarchar(128) not null,
	ModelDescription nvarchar(25) not null,
	ModelDateAdded datetime2 not null default(getdate())
)

CREATE TABLE Customers (
	CustomerId int identity (1,1) not null primary key,
	StateId char(2) not null foreign key references States(StateId),
	CustomerFirstName nvarchar(25) not null,
	CustomerLastName nvarchar(25) not null,
	CustomerPhone nvarchar(25) null,
	CustomerEmail nvarchar(75) null,
	CustomerStreet1 nvarchar(60) not null,
	CustomerStreet2 nvarchar(60) null,
	CustomerCity nvarchar(20) not null,
	CustomerZipCode nvarchar(10) not null
)

CREATE TABLE Vehicles (
	VehicleId int identity (1,1) not null primary key,
	ModelId int not null foreign key references Models(ModelId),
	VehicleTypeId int not null foreign key references VehicleTypes(VehicleTypeId),
	BodyStyleId int not null foreign key references BodyStyles(BodyStyleId),
	BodyColorId int not null foreign key references BodyColors(BodyColorId),
	InteriorColorId int not null foreign key references InteriorColors(InteriorColorId),
	TransmissionId int not null foreign key references Transmissions(TransmissionId),
	VehicleYear int not null,
	VehicleMileage int not null,
	VehicleVIN nvarchar(17) not null,
	VehicleMSRP decimal (8,2) not null,
	VehicleSalesPrice decimal (8,2) not null,
	VehicleDescription nvarchar(500) not null,
	VehiclePicture nvarchar(60) not null,
	VehicleIsFeatured bit null
)

CREATE TABLE Sales (
	SaleId int identity (1,1) not null primary key,
	CustomerId int not null foreign key references Customers(CustomerId),
	VehicleId int not null foreign key references Vehicles(VehicleId),
	FinancingId int not null foreign key references Financing(FinancingId),
	UserId nvarchar(128) not null,
	SaleAmount money not null,
	SaleDate datetime2 not null default(getdate())
)