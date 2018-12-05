USE DVDLibrary;
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DbReset')
      DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS
BEGIN
	DELETE FROM	DVDTable;
	DELETE FROM Director;
	DELETE FROM Rating;

	DBCC CHECKIDENT ('DVDTable', RESEED, 1);
	DBCC CHECKIDENT ('Director', RESEED, 1);
	DBCC CHECKIDENT ('Rating', RESEED, 1);

SET IDENTITY_INSERT Director ON

	INSERT INTO Director (DirectorId, DirectorFirstName, DirectorLastName)
VALUES (1, 'Sam', 'Jones'),
	(2, 'Joe', 'Smith'),
	(3, 'Joe', 'Baker')

SET IDENTITY_INSERT Director OFF

SET IDENTITY_INSERT Rating ON

INSERT INTO Rating (RatingId, RatingName)
VALUES (1, 'G'),
	(2, 'PG'),
	(3, 'PG-13'),
	(4, 'R'),
	(5, 'NC-17')

SET IDENTITY_INSERT Rating OFF

SET IDENTITY_INSERT DVDTable ON

INSERT INTO DVDTable(DvdId, RatingId, DirectorId, Title, RealeaseYear, Notes)
VALUES (1, 2, 1, 'A Great Tale', 2015, 'This really is a great tale!'),
	(2, 3, 2, 'A Good Tale', 2012, 'This is a good tale!'),
	(3, 2, 1, 'A Super Tale', 2015, 'A great remake!'),
	(4, 2, 2, 'A Super Tale', 1985, 'The original!'),
	(5, 3, 2, 'A Wonderful Tale', 2015, 'Wonderful, just wonderful!'),
	(6, 2, 3, 'Just A Tale', 2015, 'This is a tale!'), 
	(7, null, null, 'To be edited', null, null)

SET IDENTITY_INSERT DVDTable OFF
END