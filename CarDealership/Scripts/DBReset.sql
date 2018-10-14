USE GuildCars;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DbReset')
      DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS
BEGIN

	DELETE FROM Sales;	
	DELETE FROM Vehicles;
	DELETE FROM	Specials;
	DELETE FROM Transmissions;
	DELETE FROM VehicleTypes;
	DELETE FROM BodyStyles;
	DELETE FROM BodyColors;
	DELETE FROM InteriorColors;
	DELETE FROM Financing;
	DELETE FROM Models;
	DELETE FROM Makes;
	DELETE FROM ContactUs;
	DELETE FROM Customers;
	DELETE FROM States;
	DELETE FROM AspNetUsers WHERE Id = '00000000-0000-0000-0000-000000000000';
	DELETE FROM AspNetUsers WHERE Id = '11111111-1111-1111-1111-111111111111';
	DELETE FROM AspNetUsers WHERE Id = '22222222-2222-2222-2222-222222222222';
	DELETE FROM AspNetUsers WHERE Id = '33333333-3333-3333-3333-333333333333';
	DELETE FROM AspNetUserRoles WHERE UserId='00000000-0000-0000-0000-000000000000';
	DELETE FROM AspNetUserRoles WHERE UserId = '11111111-1111-1111-1111-111111111111';
	DELETE FROM AspNetUserRoles WHERE UserId = '22222222-2222-2222-2222-222222222222';
	DELETE FROM AspNetUserRoles WHERE UserId = '33333333-3333-3333-3333-333333333333';

	DBCC CHECKIDENT ('Sales', RESEED, 1);	
	DBCC CHECKIDENT ('Vehicles', RESEED, 1);
	DBCC CHECKIDENT ('Specials', RESEED, 1);
	DBCC CHECKIDENT ('Transmissions', RESEED, 1);
	DBCC CHECKIDENT ('VehicleTypes', RESEED, 1);
	DBCC CHECKIDENT ('BodyStyles', RESEED, 1);
	DBCC CHECKIDENT ('BodyColors', RESEED, 1);
	DBCC CHECKIDENT ('InteriorColors', RESEED, 1);
	DBCC CHECKIDENT ('Financing', RESEED, 1);
	DBCC CHECKIDENT ('Models', RESEED, 1);
	DBCC CHECKIDENT ('Makes', RESEED, 1);
	DBCC CHECKIDENT ('ContactUs', RESEED, 1);
	DBCC CHECKIDENT ('Customers', RESEED, 1);

SET IDENTITY_INSERT Specials ON

	INSERT INTO Specials (SpecialId, SpecialTitle, SpecialDescription)
	VALUES (1, 'First Special', 'Special1 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.'),
	(2, 'Second Special', 'Special2 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.'),
	(3, 'Third Special', 'Special3 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.')

SET IDENTITY_INSERT Specials OFF

SET IDENTITY_INSERT Transmissions ON

	INSERT INTO Transmissions (TransmissionId, TransmissionDescription)
	VALUES (1, 'Automatic'),
	(2, 'Manual')

SET IDENTITY_INSERT Transmissions OFF

SET IDENTITY_INSERT VehicleTypes ON

	INSERT INTO VehicleTypes (VehicleTypeId, VehicleTypeDescription)
	VALUES (1, 'New'),
	(2, 'Used')

SET IDENTITY_INSERT VehicleTypes OFF

SET IDENTITY_INSERT BodyStyles ON

	INSERT INTO BodyStyles (BodyStyleId, BodyStyleDescription)
	VALUES (1, 'Car'),
	(2, 'SUV'),
	(3, 'Truck'),
	(4, 'Van')

SET IDENTITY_INSERT BodyStyles OFF

SET IDENTITY_INSERT BodyColors ON

	INSERT INTO BodyColors (BodyColorId, BodyColorDescription)
	VALUES (1, 'Black'),
	(2, 'Silver'),
	(3, 'Dark Blue'),
	(4, 'Red'),
	(5, 'White')

SET IDENTITY_INSERT BodyColors OFF

SET IDENTITY_INSERT InteriorColors ON

	INSERT INTO InteriorColors (InteriorColorId, InteriorColorDescription)
	VALUES (1, 'Black'),
	(2, 'Dark Gray'),
	(3, 'Red'),
	(4, 'Light Gray'),
	(5, 'Tan')

SET IDENTITY_INSERT InteriorColors OFF

SET IDENTITY_INSERT Financing ON

	INSERT INTO Financing (FinancingId, FinancingDescription)
	VALUES (1, 'Bank Finance'),
	(2, 'Cash'),
	(3, 'Dealer Finance')

SET IDENTITY_INSERT Financing OFF

	INSERT INTO States (StateId, StateName)
	VALUES ('IA', 'Iowa'),
	('IL', 'Illinois'),
	('MO', 'Missouri');

SET IDENTITY_INSERT Makes ON

	INSERT INTO Makes (MakeId, UserId, MakeDescription, MakeDateAdded)
	VALUES (1, '00000000-0000-0000-0000-000000000000', 'Chevrolet', '2018-07-22 00:00:00.0000000'),
	(2, '00000000-0000-0000-0000-000000000000', 'Ford', '2018-07-22 00:00:00.0000000'),
	(3, '00000000-0000-0000-0000-000000000000', 'Lincoln', '2018-07-22 00:00:00.0000000')

SET IDENTITY_INSERT Makes OFF

SET IDENTITY_INSERT ContactUs ON

	INSERT INTO ContactUs (ContactUsId, ContactUsFirstName, ContactUsLastName, ContactUsEmail, ContactUsPhone, ContactUsMessage)
	VALUES (1, 'Jane', 'Doe', 'janedoe@test1.com', '111-111-1111', 'Test1 Lorem ipsum dolor sit amet, consectetur adipiscing elit.'),
	(2, 'John', 'Smith', 'johnsmith@test2.com', '222-222-2222', 'Test2 Lorem ipsum dolor sit amet, consectetur adipiscing elit.')

SET IDENTITY_INSERT ContactUs OFF

SET IDENTITY_INSERT Customers ON

	INSERT INTO Customers (CustomerId, StateId, CustomerFirstName, CustomerLastName, CustomerPhone, CustomerEmail, CustomerStreet1, CustomerStreet2, CustomerCity, CustomerZipCode)
	VALUES (1, 'IL', 'Jill', 'Jones', '111-111-1111', 'jilljones@customertest1.com', 'Test1 Street1', null, 'Test1City', '11111' ),
	(2, 'MO', 'Joe', 'Baker', '222-222-2222', 'joebaker@customertest2.com', 'Test2 Street1', 'Test2 Street2', 'Test2City', '22222' ),
	(3, 'IA', 'Jane', 'Doe', '333-333-3333', 'janedoe@test3.com','Test3 Street1', null, 'Test3City', '33333' ),
	(4, 'MO', 'John', 'Smith', '444-444-4444', 'johnsmith@test4.com', 'Test4 Street1', 'Test4 Street2', 'Test4City', '44444' )

SET IDENTITY_INSERT Customers OFF

SET IDENTITY_INSERT Models ON

	INSERT INTO Models (ModelId, MakeId, UserId, ModelDescription, ModelDateAdded)
	VALUES (1, 1, '00000000-0000-0000-0000-000000000000', 'Cruze', '2018-07-23 00:00:00.0000000'),
	(2, 1, '00000000-0000-0000-0000-000000000000', 'Silverado', '2018-07-23 00:00:00.0000000'),
	(3, 1, '00000000-0000-0000-0000-000000000000', 'Tahoe', '2018-07-23 00:00:00.0000000'),
	(4, 1, '00000000-0000-0000-0000-000000000000', 'Express', '2018-07-23 00:00:00.0000000'),
	(5, 2, '00000000-0000-0000-0000-000000000000', 'Fusion', '2018-07-23 00:00:00.0000000'),
	(6, 2, '00000000-0000-0000-0000-000000000000', 'F-150', '2018-07-23 00:00:00.0000000'),
	(7, 2, '00000000-0000-0000-0000-000000000000', 'Explorer', '2018-07-23 00:00:00.0000000'),
	(8, 2, '00000000-0000-0000-0000-000000000000', 'Transit Connect', '2018-07-23 00:00:00.0000000'),
	(9, 3, '00000000-0000-0000-0000-000000000000', 'Continental', '2018-07-23 00:00:00.0000000'),
	(10, 3, '00000000-0000-0000-0000-000000000000', 'MKZ', '2018-07-23 00:00:00.0000000'),
	(11, 3, '00000000-0000-0000-0000-000000000000', 'Navigator', '2018-07-23 00:00:00.0000000')

SET IDENTITY_INSERT Models OFF

	INSERT INTO AspNetUsers (Id, FirstName, LastName, Email, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled,AccessFailedCount, UserName)
	VALUES ('00000000-0000-0000-0000-000000000000', 'Test', 'Adminuser', 'testadminuser@test.com', 0, 0, 0, 0, 0, 'testadminuser@test.com'),
	('11111111-1111-1111-1111-111111111111', 'Test', 'Salesuser1', 'testsalesuser1@test.com', 0, 0, 0, 0, 0, 'testsalesuser1@test.com'),
	('22222222-2222-2222-2222-222222222222', 'Test', 'Salesuser2', 'testsalesuser2@test.com', 0, 0, 0, 0, 0, 'testsalesuser2@test.com'),
	('33333333-3333-3333-3333-333333333333', 'Test', 'Salesuser3', 'testsalesuser3@test.com', 0, 0, 0, 0, 0, 'testsalesuser3@test.com')

	INSERT INTO AspNetUserRoles (UserId, RoleId)
		SELECT u.Id AS UserId, r.Id AS RoleId
			FROM AspNetUsers AS u
				CROSS JOIN AspNetRoles AS r
			WHERE u.Id = '00000000-0000-0000-0000-000000000000' AND r.Name = 'Admin'

	INSERT INTO AspNetUserRoles (UserId, RoleId)
		SELECT u.Id AS UserId, r.Id AS RoleId
			FROM AspNetUsers AS u
				CROSS JOIN AspNetRoles AS r
			WHERE u.Id = '11111111-1111-1111-1111-111111111111' AND r.Name = 'Sales'

	INSERT INTO AspNetUserRoles (UserId, RoleId)
		SELECT u.Id AS UserId, r.Id AS RoleId
			FROM AspNetUsers AS u
				CROSS JOIN AspNetRoles AS r
			WHERE u.Id = '22222222-2222-2222-2222-222222222222' AND r.Name = 'Sales'

	INSERT INTO AspNetUserRoles (UserId, RoleId)
		SELECT u.Id AS UserId, r.Id AS RoleId
			FROM AspNetUsers AS u
				CROSS JOIN AspNetRoles AS r
			WHERE u.Id = '33333333-3333-3333-3333-333333333333' AND r.Name = 'Sales'

SET IDENTITY_INSERT Vehicles ON

	

	INSERT INTO Vehicles (VehicleId, ModelId, VehicleTypeId, BodyStyleId, BodyColorId, InteriorColorId, TransmissionId, VehicleYear, VehicleMileage, VehicleVIN, VehicleMSRP, VehicleSalesPrice, VehicleDescription, VehiclePicture, VehicleIsFeatured)
	VALUES (1, 7, 1, 2, 2, 4, 1, 2018, 0, '11111111111111111', 35000, 34000, 'Test1 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum magna arcu, congue sit amet mattis quis, molestie a sem.', 'inventory-1.PNG', 0),
	(2, 6, 2, 3, 2, 4, 2, 2016, 50000, '2222222222222222', 14000, 13500, 'Test2 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-2.PNG', 0),
(3, 9, 1, 1, 2, 4, 2, 2018, 200, '3333333333333333', 46000, 44000, 'Test3 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-3.PNG', 1),
(4, 5, 2, 1, 2, 4, 1, 2016, 50000, '44444444444444444', 11500, 10000, 'Test4 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-4.PNG', 0),
(5, 11, 1, 2, 2, 4, 1, 2018, 0, '5555555555555555', 73000, 71000, 'Test5 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-5.PNG', 0),
(6, 4, 2, 4, 2, 4, 1, 2016, 50000, '6666666666666666', 16000, 15000, 'Test6 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-6.PNG', 1),
(7, 3, 2, 2, 2, 4, 1, 2016, 50000, '77777777777777777', 24000, 23000, 'Test7 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-7.PNG', 0),
(8, 1, 1, 1, 2, 4, 1, 2018, 100, '8888888888888888', 17000, 16000, 'Test8 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-8.PNG', 0),
(9, 11, 1, 2, 2, 4, 1, 2018, 0, '9999999999999999', 36500, 35000, 'Test9 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-9.PNG', 1),
(10, 2, 1, 3, 2, 4, 2, 2018, 0, '10111111111111111', 29000, 28000, 'Test10 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-10.PNG', 0),
(11, 10, 2, 1, 2, 4, 1, 2016, 50000, '11000000000000000', 18000, 17000, 'Test11 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-11.PNG', 0),
(12, 8, 2, 4, 2, 4, 2, 2016, 50000, '12111111111111111', 15000, 14500, 'Test12 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-12.PNG', 1),
(13, 8, 2, 4, 2, 4, 2, 2016, 50000, '13111111111111111', 15000, 14500, 'Test13 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-13.PNG', 1),
(14, 11, 1, 2, 2, 4, 1, 2018, 0, '14111111111111111', 36500, 35000, 'Test14 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-14.PNG', 1),
(100000, 1, 1, 1, 2, 4, 1, 2018, 100, '8888888888888888', 17000, 16000, 'Test8 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-1.PNG', 0),
(100001, 1, 1, 1, 2, 4, 1, 2018, 100, '8888888888888888', 17000, 16000, 'Test8 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'placeholder.PNG', 0),
(100002, 1, 1, 1, 2, 4, 1, 2018, 100, '8888888888888888', 17000, 16000, 'Test8 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'placeholder.PNG', 0),
(100003, 1, 1, 1, 2, 4, 1, 2018, 100, '8888888888888888', 17000, 16000, 'Test8 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'placeholder.PNG', 0),
(100004, 1, 1, 1, 2, 4, 1, 2018, 100, '8888888888888888', 17000, 16000, 'Test8 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'placeholder.PNG', 0),
(100005, 1, 1, 1, 2, 4, 1, 2018, 100, '8888888888888888', 17000, 16000, 'Test8 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'placeholder.PNG', 0),
(100006, 1, 1, 1, 2, 4, 1, 2018, 100, '8888888888888888', 17000, 16000, 'Test8 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'placeholder.PNG', 0),
(100007, 1, 1, 1, 2, 4, 1, 2018, 100, '8888888888888888', 17000, 16000, 'Test8 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'placeholder.PNG', 0),
(100008, 1, 1, 1, 2, 4, 1, 2018, 100, '8888888888888888', 17000, 16000, 'Test8 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'placeholder.PNG', 0),
(15, 9, 1, 1, 2, 4, 2, 2017, 200, '15111111111111111', 51000, 50000, 'Test15 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-15.PNG', 0),
(16, 1, 2, 1, 2, 4, 2, 2001, 2000, '16111111111111111', 10000, 9500, 'Test16 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-16.PNG', 0),
(17, 2, 2, 3, 2, 4, 2, 2002, 2000, '17111111111111111', 20000, 19500, 'Test17 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-17.PNG', 0),
(18, 3, 2, 2, 2, 4, 2, 2003, 2000, '18111111111111111', 30000, 29500, 'Test18 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-18.PNG', 0),
(19, 4, 2, 4, 2, 4, 2, 2004, 2000, '19111111111111111', 40000, 39500, 'Test19 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-19.PNG', 0),
(20, 5, 2, 1, 2, 4, 2, 2005, 2000, '20111111111111111', 50000, 49500, 'Test20 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-20.PNG', 0),
(21, 6, 2, 3, 2, 4, 2, 2006, 2000, '21111111111111111', 60000, 59500, 'Test21 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-21.PNG', 0),
(22, 7, 2, 2, 2, 4, 2, 2007, 2000, '22111111111111111', 70000, 69500, 'Test22 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-22.PNG', 0),
(23, 8, 2, 4, 2, 4, 2, 2008, 2000, '23111111111111111', 80000, 79500, 'Test23 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-23.PNG', 0),
(24, 9, 2, 1, 2, 4, 2, 2009, 2000, '24111111111111111', 90000, 89500, 'Test24 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-24.PNG', 0),
(25, 10, 2, 1, 2, 4, 2, 2010, 2000, '25111111111111111',8000, 7500, 'Test25 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-25.PNG', 0),
(26, 11, 2, 2, 2, 4, 2, 2011, 2000, '26111111111111111', 15000, 14500, 'Test26 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-26.PNG', 0),
(27, 1, 2, 1, 2, 4, 2, 2012, 2000, '27111111111111111', 26000, 25500, 'Test27 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-27.PNG', 0),
(28, 2, 2, 3, 2, 4, 2, 2013, 2000, '28111111111111111', 52000, 51500, 'Test28 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-28.PNG', 0),
(29, 3, 2, 2, 2, 4, 2, 2014, 2000, '29111111111111111', 77000, 76500, 'Test29 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-29.PNG', 0),
(30, 4, 2, 4, 2, 4, 2, 2015, 2000, '30111111111111111', 63000, 62500, 'Test30 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-30.PNG', 0),
(31, 5, 2, 1, 2, 4, 2, 2016, 2000, '31111111111111111', 39000, 38500, 'Test31 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-31.PNG', 0),
(32, 6, 2, 3, 2, 4, 2, 2017, 2000, '32111111111111111', 46000, 45500, 'Test32 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-32.PNG', 0),
(33, 7, 2, 2, 2, 4, 2, 2009, 2000, '33111111111111111', 88000, 87500, 'Test33 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-33.PNG', 0),
(34, 8, 2, 4, 2, 4, 2, 2014, 2000, '34111111111111111', 96000, 95500, 'Test34 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-34.PNG', 0),
(35, 9, 2, 1, 2, 4, 2, 2001, 2000, '35111111111111111', 22000, 21500, 'Test35 Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 'inventory-35.PNG', 0)

SET IDENTITY_INSERT Vehicles OFF

SET IDENTITY_INSERT Sales ON

	INSERT INTO Sales (SaleId, CustomerId, VehicleId, FinancingId, UserId, SaleAmount, SaleDate)
	VALUES (1, 1, 4, 1,'11111111-1111-1111-1111-111111111111', 10500, '2018-04-25 00:00:00.0000000'),
	(2, 2, 5, 2, '11111111-1111-1111-1111-111111111111', 72000, '2018-05-25 00:00:00.0000000'),
	(3, 3, 10, 3, '11111111-1111-1111-1111-111111111111', 27500, '2018-06-25 00:00:00.0000000'),
	(4, 4, 11, 2, '11111111-1111-1111-1111-111111111111', 16500, '2018-07-25 00:00:00.0000000'),
	(5, 1, 100000, 1,'22222222-2222-2222-2222-222222222222', 10000, '2018-01-25 00:00:00.0000000'),
	(6, 2, 100001, 2,'22222222-2222-2222-2222-222222222222', 20000, '2018-04-25 00:00:00.0000000'),
	(7, 3, 100002, 3,'22222222-2222-2222-2222-222222222222', 35000, '2018-05-25 00:00:00.0000000'),
	(8, 4, 100003, 2,'22222222-2222-2222-2222-222222222222', 45000, '2018-06-25 00:00:00.0000000'),
	(9, 1, 100004, 1,'33333333-3333-3333-3333-333333333333', 30000, '2017-12-30 00:00:00.0000000'),
	(10, 2, 100005, 2,'33333333-3333-3333-3333-333333333333', 60000, '2018-01-25 00:00:00.0000000'),
	(11, 3, 100006, 3,'33333333-3333-3333-3333-333333333333', 42000, '2018-02-25 00:00:00.0000000'),
	(12, 4, 100007, 2,'33333333-3333-3333-3333-333333333333', 28000, '2018-07-25 00:00:00.0000000'),
	(13, 4, 100008, 2,'33333333-3333-3333-3333-333333333333', 75000, '2018-04-25 00:00:00.0000000')

SET IDENTITY_INSERT Sales OFF

END