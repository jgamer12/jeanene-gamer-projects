USE GuildCars
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialsSelectAll')
      DROP PROCEDURE SpecialsSelectAll
GO

CREATE PROCEDURE SpecialsSelectAll AS
BEGIN
	SELECT SpecialId, SpecialTitle, SpecialDescription
	FROM Specials 
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddSpecial')
      DROP PROCEDURE AddSpecial
GO

CREATE PROCEDURE AddSpecial (
	@SpecialId int output,
	@SpecialTitle nvarchar(50),
	@SpecialDescription nvarchar(500)
)   AS
BEGIN
	INSERT INTO Specials (SpecialTitle, SpecialDescription)
	VALUES (@SpecialTitle, @SpecialDescription);
		SET @SpecialId = SCOPE_IDENTITY();
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DeleteSpecialById')
      DROP PROCEDURE DeleteSpecialById
GO

CREATE PROCEDURE DeleteSpecialById (
	@SpecialId int
)   AS
BEGIN
	DELETE Specials WHERE SpecialId = @SpecialId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetSpecial')
      DROP PROCEDURE GetSpecial
GO

CREATE PROCEDURE GetSpecial (
	@SpecialId int
) AS
BEGIN
	SELECT SpecialId, SpecialTitle, SpecialDescription
	FROM Specials 
	WHERE SpecialId = @SpecialId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'TransmissionsSelectAll')
      DROP PROCEDURE TransmissionsSelectAll
GO

CREATE PROCEDURE TransmissionsSelectAll AS
BEGIN
	SELECT TransmissionId, TransmissionDescription
	FROM Transmissions
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleTypesSelectAll')
      DROP PROCEDURE VehicleTypesSelectAll
GO

CREATE PROCEDURE VehicleTypesSelectAll AS
BEGIN
	SELECT VehicleTypeId, VehicleTypeDescription
	FROM VehicleTypes
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'BodyStylesSelectAll')
      DROP PROCEDURE BodyStylesSelectAll
GO

CREATE PROCEDURE BodyStylesSelectAll AS
BEGIN
	SELECT BodyStyleId, BodyStyleDescription
	FROM BodyStyles
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'BodyColorsSelectAll')
      DROP PROCEDURE BodyColorsSelectAll
GO

CREATE PROCEDURE BodyColorsSelectAll AS
BEGIN
	SELECT BodyColorId, BodyColorDescription
	FROM BodyColors
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InteriorColorsSelectAll')
      DROP PROCEDURE InteriorColorsSelectAll
GO

CREATE PROCEDURE InteriorColorsSelectAll AS
BEGIN
	SELECT InteriorColorId, InteriorColorDescription
	FROM InteriorColors
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'FinancingSelectAll')
      DROP PROCEDURE FinancingSelectAll
GO

CREATE PROCEDURE FinancingSelectAll AS
BEGIN
	SELECT FinancingId, FinancingDescription
	FROM Financing
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'StatesSelectAll')
      DROP PROCEDURE StatesSelectAll
GO

CREATE PROCEDURE StatesSelectAll AS
BEGIN
	SELECT StateId, StateName
	FROM States
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactUsSelectAll')
      DROP PROCEDURE ContactUsSelectAll
GO

CREATE PROCEDURE ContactUsSelectAll AS
BEGIN
	SELECT ContactUsId, ContactUsFirstName, ContactUsLastName, ContactUsEmail, ContactUsPhone, ContactUsMessage
	FROM ContactUs
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddContact')
      DROP PROCEDURE AddContact
GO

CREATE PROCEDURE AddContact (
	@ContactUsId int output,
	@ContactUsFirstName nvarchar(25),
	@ContactUsLastName nvarchar(25),
	@ContactUsEmail nvarchar(75),
	@ContactUsPhone nvarchar(25),
	@ContactUsMessage nvarchar(500)

)   AS
BEGIN
	INSERT INTO ContactUs (ContactUsFirstName, ContactUsLastName, ContactUsEmail, ContactUsPhone, ContactUsMessage)
	VALUES (@ContactUsFirstName, @ContactUsLastName, @ContactUsEmail, @ContactUsPhone, @ContactUsMessage);
		SET @ContactUsId = SCOPE_IDENTITY();
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakesSelectAll')
      DROP PROCEDURE MakesSelectAll
GO

CREATE PROCEDURE MakesSelectAll AS
BEGIN
	SELECT MakeId, UserName, MakeDescription, MakeDateAdded
	FROM Makes 
		INNER JOIN [AspNetUsers]  ON
			Makes.UserId = AspNetUsers.Id 
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetMakeForModel')
      DROP PROCEDURE GetMakeForModel
GO

CREATE PROCEDURE GetMakeForModel (
	@ModelId int
)AS
BEGIN
	SELECT Makes.MakeId, Makes.UserId, MakeDescription, MakeDateAdded
	FROM Makes 
		INNER JOIN Models ON Models.MakeId = Makes.MakeId
	WHERE Models.ModelId = @ModelId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddMake')
      DROP PROCEDURE AddMake
GO

CREATE PROCEDURE AddMake (
	@MakeId int output,
	@UserId nvarchar(128),
	@MakeDescription nvarchar(25),
	@MakeDateAdded datetime2(7)
)   AS
BEGIN
	INSERT INTO Makes (UserId, MakeDescription, MakeDateAdded)
	VALUES (@UserId, @MakeDescription, @MakeDateAdded);
		SET @MakeId = SCOPE_IDENTITY();
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'CustomersSelectAll')
      DROP PROCEDURE CustomersSelectAll
GO

CREATE PROCEDURE CustomersSelectAll AS
BEGIN
	SELECT CustomerId, StateId, CustomerFirstName, CustomerLastName, CustomerPhone, CustomerEmail, CustomerStreet1, CustomerStreet2, CustomerCity, CustomerZipCode
	FROM Customers
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddCustomer')
      DROP PROCEDURE AddCustomer
GO

CREATE PROCEDURE AddCustomer (
	@CustomerId int output,
	@StateId char(2),
	@CustomerFirstName nvarchar(25),
	@CustomerLastName nvarchar(25),
	@CustomerPhone nvarchar(25),
	@CustomerEmail nvarchar(75),
	@CustomerStreet1 nvarchar(60),
	@CustomerStreet2 nvarchar(60),
	@CustomerCity nvarchar(20),
	@CustomerZipCode nvarchar(10)

)   AS
BEGIN
	INSERT INTO Customers (StateId, CustomerFirstName, CustomerLastName, CustomerPhone, CustomerEmail, CustomerStreet1, CustomerStreet2, CustomerCity, CustomerZipCode)
	VALUES (@StateId, @CustomerFirstName, @CustomerLastName, @CustomerPhone, @CustomerEmail, @CustomerStreet1, @CustomerStreet2, @CustomerCity, @CustomerZipCode)
		SET @CustomerId = SCOPE_IDENTITY();
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ModelsSelectAll')
      DROP PROCEDURE ModelsSelectAll
GO

CREATE PROCEDURE ModelsSelectAll AS
BEGIN
	SELECT Models.MakeId, MakeDescription, ModelId, u.UserName, ModelDescription, ModelDateAdded
	FROM Models 
		INNER JOIN Makes
			ON Makes.MakeId = Models.MakeId
		INNER JOIN AspNetUsers u
			ON u.Id = Models.UserId
	ORDER BY ModelId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddModel')
      DROP PROCEDURE AddModel
GO

CREATE PROCEDURE AddModel (
	@ModelId int output,
	@MakeId int,
	@UserId nvarchar(128),
	@ModelDescription nvarchar(25),
	@ModelDateAdded datetime2(7)
)   AS
BEGIN
	INSERT INTO Models (MakeId, UserId, ModelDescription, ModelDateAdded)
	VALUES (@MakeId, @UserId, @ModelDescription, @ModelDateAdded);
		SET @ModelId = SCOPE_IDENTITY();
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ModelsGetByMake')
      DROP PROCEDURE ModelsGetByMake
GO

CREATE PROCEDURE ModelsGetByMake (
	@MakeId int
)
AS
BEGIN
	SELECT Models.MakeId, MakeDescription, ModelId, ModelDescription, u.UserName, ModelDescription, ModelDateAdded
	FROM Models 
		INNER JOIN Makes
			ON Makes.MakeId = Models.MakeId
		INNER JOIN AspNetUsers u
			ON u.Id = Models.UserId
	WHERE Models.MakeId = @MakeId
	ORDER BY ModelId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectVehicle')
      DROP PROCEDURE SelectVehicle
GO

CREATE PROCEDURE SelectVehicle (
	@VehicleId int
) AS
BEGIN
	SELECT VehicleId, ModelId, VehicleTypeId, BodyStyleId, BodyColorId, InteriorColorId, TransmissionId, VehicleYear,
		VehicleMileage, VehicleVIN, VehicleMSRP, VehicleSalesPrice, VehicleDescription, VehiclePicture, VehicleIsFeatured
	FROM Vehicles 
	WHERE VehicleId = @VehicleId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddVehicle')
      DROP PROCEDURE AddVehicle
GO

CREATE PROCEDURE AddVehicle (
	@VehicleId int output,
	@ModelId int,
	@VehicleTypeId int,
	@BodyStyleId int,
	@BodyColorId int,
	@InteriorColorId int,
	@TransmissionId int,
	@VehicleYear int, 
	@VehicleMileage int,
	@VehicleVIN nvarchar(17),
	@VehicleMSRP decimal (8,2),
	@VehicleSalesPrice decimal (8,2),
	@VehicleDescription nvarchar(500),
	@VehiclePicture nvarchar(60),
	@VehicleIsFeatured bit
)   AS
BEGIN
	INSERT INTO Vehicles (ModelId, VehicleTypeId, BodyStyleId, BodyColorId, InteriorColorId, TransmissionId, VehicleYear,
		VehicleMileage, VehicleVIN, VehicleMSRP, VehicleSalesPrice, VehicleDescription, VehiclePicture, VehicleIsFeatured)
	VALUES (@ModelId, @VehicleTypeId, @BodyStyleId, @BodyColorId, @InteriorColorId, @TransmissionId,  @VehicleYear, 
		@VehicleMileage, @VehicleVIN, @VehicleMSRP,@VehicleSalesPrice, @VehicleDescription, @VehiclePicture, @VehicleIsFeatured);
		SET @VehicleId = SCOPE_IDENTITY();
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'UpdateVehicle')
      DROP PROCEDURE UpdateVehicle
GO

CREATE PROCEDURE UpdateVehicle (
	@VehicleId int,
	@ModelId int,
	@VehicleTypeId int,
	@BodyStyleId int,
	@BodyColorId int,
	@InteriorColorId int,
	@TransmissionId int,
	@VehicleYear int, 
	@VehicleMileage int,
	@VehicleVIN nvarchar(17),
	@VehicleMSRP decimal (8,2),
	@VehicleSalesPrice decimal (8,2),
	@VehicleDescription nvarchar(500),
	@VehiclePicture nvarchar(60),
	@VehicleIsFeatured bit
)   AS
BEGIN
	UPDATE Vehicles SET
		ModelId = @ModelId, 
		VehicleTypeId = @VehicleTypeId, 
		BodyStyleId = @BodyStyleId, 
		BodyColorId= @BodyColorId, 
		InteriorColorId = @InteriorColorId, 
		TransmissionId = @TransmissionId, 
		VehicleYear = @VehicleYear,
		VehicleMileage = @VehicleMileage,
		VehicleVIN = @VehicleVIN, 
		VehicleMSRP = @VehicleMSRP,
		VehicleSalesPrice = @VehicleSalesPrice,
		VehicleDescription = @VehicleDescription, 
		VehiclePicture = @VehiclePicture, 
		VehicleIsFeatured = @VehicleIsFeatured
	WHERE VehicleId = @VehicleId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DeleteVehicle')
      DROP PROCEDURE DeleteVehicle
GO

CREATE PROCEDURE DeleteVehicle (
	@VehicleId int
)   AS
BEGIN
	DELETE FROM Vehicles WHERE VehicleId = @VehicleId;
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetFeaturedVehicles')
      DROP PROCEDURE GetFeaturedVehicles
GO

CREATE PROCEDURE GetFeaturedVehicles AS
BEGIN
	SELECT VehicleId, VehicleYear, Makes.MakeDescription, Models.ModelDescription, VehicleSalesPrice, VehiclePicture
	FROM Vehicles 
		INNER JOIN [Models] ON
			Vehicles.ModelId = Models.ModelId
		INNER JOIN [Makes] ON
			Makes.MakeId = Models.MakeId
	WHERE Vehicles.VehicleIsFeatured = 1
	ORDER BY VehicleTypeId, VehicleSalesPrice DESC
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetVehicleDetails')
      DROP PROCEDURE GetVehicleDetails
GO

CREATE PROCEDURE GetVehicleDetails (
	@VehicleId int
) AS
BEGIN
	SELECT VehicleId, VehicleYear, MakeDescription,  ModelDescription, BodyStyleDescription, 
	InteriorColorDescription, TransmissionDescription, VehicleMileage, BodyColorDescription, 
	VehicleVIN, VehicleSalesPrice, VehicleMSRP, VehiclePicture, VehicleDescription
	FROM Vehicles 
		INNER JOIN BodyStyles ON
			Vehicles.BodyStyleId = BodyStyles.BodyStyleId
		INNER JOIN InteriorColors ON
			Vehicles.InteriorColorId = InteriorColors.InteriorColorId
		INNER JOIN Transmissions ON
			Vehicles.TransmissionId = Transmissions.TransmissionId
		INNER JOIN BodyColors ON
			Vehicles.BodyColorId = BodyColors.BodyColorId
		INNER JOIN Models ON
			Vehicles.ModelId = Models.ModelId
		INNER JOIN Makes ON
			Makes.MakeId = Models.MakeId
	WHERE VehicleId = @VehicleId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InventoryReportNew')
      DROP PROCEDURE InventoryReportNew
GO

CREATE PROCEDURE InventoryReportNew
AS
BEGIN
	SELECT		VehicleYear, MakeDescription, ModelDescription, COUNT(Vehicles.ModelId) AS "Count", SUM(VehicleMSRP) AS "StockValue" 
	FROM Vehicles
		LEFT JOIN Sales ON Vehicles.VehicleId = Sales.VehicleId 
		INNER JOIN Models ON Vehicles.ModelId = Models.ModelId 
		INNER JOIN Makes ON Makes.MakeId = Models.MakeId 
		WHERE SaleId IS NULL AND VehicleTypeId=1
		GROUP BY VehicleYear, Makes.MakeDescription, Models.ModelDescription
		ORDER BY VehicleYear, MakeDescription, ModelDescription;
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InventoryReportUsed')
      DROP PROCEDURE InventoryReportUsed
GO

CREATE PROCEDURE InventoryReportUsed
AS
BEGIN
	SELECT		VehicleYear, MakeDescription, ModelDescription, COUNT(Vehicles.ModelId) AS "Count", SUM(VehicleMSRP) AS "StockValue" 
	FROM Vehicles
		LEFT JOIN Sales ON Vehicles.VehicleId = Sales.VehicleId 
		INNER JOIN Models ON Vehicles.ModelId = Models.ModelId 
		INNER JOIN Makes ON Makes.MakeId = Models.MakeId 
		WHERE SaleId IS NULL AND VehicleTypeId=2
		GROUP BY VehicleYear, Makes.MakeDescription, Models.ModelDescription
		ORDER BY VehicleYear, MakeDescription, ModelDescription;
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'UsersSelectAll')
      DROP PROCEDURE UsersSelectAll
GO

CREATE PROCEDURE UsersSelectAll AS
BEGIN
	SELECT u.Id AS UserId, FirstName, LastName, Email, Name AS Role, ur.RoleId AS RoleId
	FROM AspNetUserRoles ur
		INNER JOIN AspNetRoles r ON ur.RoleId = r.Id 
		INNER JOIN AspNetUsers u ON U.Id = ur.UserId;
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SalesUserIdAndName')
      DROP PROCEDURE SalesUserIdAndName
GO

CREATE PROCEDURE SalesUserIdAndName AS
BEGIN


	SELECT u.Id AS UserId, FirstName + ' ' + LastName AS UserName
	FROM AspNetUserRoles ur
		INNER JOIN AspNetRoles r ON ur.RoleId = r.Id 
		INNER JOIN AspNetUsers u ON u.Id = ur.UserId
	WHERE r.Name = 'Sales' OR r.name = 'Disabled';
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetNextVehicleId')
      DROP PROCEDURE GetNextVehicleId
GO

CREATE PROCEDURE GetNextVehicleId AS
BEGIN
	SELECT IDENT_CURRENT('Vehicles')+1;
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'IsSold')
      DROP PROCEDURE IsSold
GO

CREATE PROCEDURE IsSold (
	@VehicleId int
) AS
BEGIN
	SELECT SaleId
	FROM Sales s
		INNER JOIN Vehicles v ON s.VehicleId = v.VehicleId
	WHERE s.VehicleId = @VehicleId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddSale')
      DROP PROCEDURE AddSale
GO

CREATE PROCEDURE AddSale (
	@SaleId int output,
	@CustomerId int,
	@VehicleId int,
	@FinancingId int,
	@UserId nvarchar(128),
	@SaleAmount money,
	@SaleDate datetime2(7)
)   AS
BEGIN
	INSERT INTO Sales (CustomerId, VehicleId, FinancingId, UserId, SaleAmount, SaleDate)
	VALUES (@CustomerId, @VehicleId, @FinancingId, @UserId, @SaleAmount, @SaleDate)
		SET @SaleId = SCOPE_IDENTITY();
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SalesSelectAll')
      DROP PROCEDURE SalesSelectAll
GO

CREATE PROCEDURE SalesSelectAll AS
BEGIN
	SELECT SaleId, CustomerId, VehicleId, FinancingId, UserId, SaleAmount, SaleDate
	FROM Sales 
	ORDER BY SaleId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SelectAllRoles')
      DROP PROCEDURE SelectAllRoles
GO

CREATE PROCEDURE SelectAllRoles AS
BEGIN
	SELECT Id, Name, Discriminator
	FROM AspNetRoles 
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetRoleNameForId')
      DROP PROCEDURE GetRoleNameForId
GO

CREATE PROCEDURE GetRoleNameForId (
	@RoleId nvarchar(128)
) AS
BEGIN
	SELECT Id, Name, Discriminator
	FROM AspNetRoles
	WHERE aspNetRoles.Id = @RoleId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetUserById')
      DROP PROCEDURE GetUserById
GO

CREATE PROCEDURE GetUserById (
	@Id nvarchar(128)
) AS
BEGIN
	SELECT u.Id AS UserId, FirstName, LastName, Email, Name AS Role, ur.RoleId
	FROM AspNetUserRoles ur
		INNER JOIN AspNetRoles r ON ur.RoleId = r.Id 
		INNER JOIN AspNetUsers u ON U.Id = ur.UserId
		WHERE u.Id = @Id;
END
GO



