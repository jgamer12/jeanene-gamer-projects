USE DVDLibrary
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DVDLibrarySelectAll')
      DROP PROCEDURE DVDLibrarySelectAll
GO

CREATE PROCEDURE DVDLibrarySelectAll
AS
	SELECT t.DvdId, t.Title, t.RealeaseYear, d.DirectorFirstName + ' ' + d.DirectorLastName AS Director, r.RatingName AS Rating, t.Notes
	FROM DVDTable t
		LEFT JOIN Director d ON t.DirectorId = d.DirectorID
		LEFT JOIN Rating r ON t.RatingId = r.RatingId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DVDLibrarySelectById')
      DROP PROCEDURE DVDLibrarySelectById
GO

CREATE PROCEDURE DVDLibrarySelectById (
	@DvdId int
)   AS
BEGIN
	SELECT t.DvdId, t.Title, t.RealeaseYear, d.DirectorFirstName + ' ' + d.DirectorLastName AS Director, r.RatingName AS Rating, t.Notes
	FROM DVDTable t
		LEFT JOIN Director d ON t.DirectorId = d.DirectorID
		LEFT JOIN Rating r ON t.RatingId = r.RatingId
	WHERE DvdId = @DvdId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DVDLibrarySearch')
      DROP PROCEDURE DVDLibrarySearch
GO

CREATE PROCEDURE DVDLibrarySearch (
	@SearchCategory varchar(15), @SearchTerm varchar(50)
)   AS
BEGIN
	IF @SearchCategory='title'
	BEGIN
		SELECT t.DvdId, t.Title, t.RealeaseYear, d.DirectorFirstName + ' ' + d.DirectorLastName AS Director, r.RatingName AS Rating, t.Notes
		FROM DVDTable t
			LEFT JOIN Director d ON t.DirectorId = d.DirectorID
			LEFT JOIN Rating r ON t.RatingId = r.RatingId
		WHERE t.Title LIKE @SearchTerm
	END

	IF @SearchCategory='year'
	BEGIN
		SELECT t.DvdId, t.Title, t.RealeaseYear, d.DirectorFirstName + ' ' + d.DirectorLastName AS Director, r.RatingName AS Rating, t.Notes
		FROM DVDTable t
			LEFT JOIN Director d ON t.DirectorId = d.DirectorID
			LEFT JOIN Rating r ON t.RatingId = r.RatingId
		WHERE t.RealeaseYear LIKE @SearchTerm
	END

	IF @SearchCategory='rating'
	BEGIN
		SELECT t.DvdId, t.Title, t.RealeaseYear, d.DirectorFirstName + ' ' + d.DirectorLastName AS Director, r.RatingName AS Rating, t.Notes
		FROM DVDTable t
			LEFT JOIN Director d ON t.DirectorId = d.DirectorID
			LEFT JOIN Rating r ON t.RatingId = r.RatingId
		WHERE r.RatingName LIKE @SearchTerm
	END

		IF @SearchCategory='director'
	BEGIN
		SELECT t.DvdId, t.Title, t.RealeaseYear, d.DirectorFirstName + ' ' + d.DirectorLastName AS Director, r.RatingName AS Rating, t.Notes
		FROM DVDTable t
			LEFT JOIN Director d ON t.DirectorId = d.DirectorID
			LEFT JOIN Rating r ON t.RatingId = r.RatingId
		WHERE d.DirectorFirstName + ' ' + d.DirectorLastName LIKE @SearchTerm
	END
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DVDLibraryAddDVD')
      DROP PROCEDURE DVDLibraryAddDVD
GO

CREATE PROCEDURE DVDLibraryAddDVD (
	@DvdId int output,
	@RatingId int,
	@DirectorId int,
	@Title varchar(50),
	@RealeaseYear int,
	@Notes varchar(250)
)
AS
BEGIN
	INSERT INTO DVDTable (RatingId, DirectorId, Title, RealeaseYear, Notes)
	VALUES (@RatingId, @DirectorId, @Title, @RealeaseYear, @Notes);
		SET @DvdId = SCOPE_IDENTITY();
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DVDLibraryEditDVD')
      DROP PROCEDURE DVDLibraryEditDVD
GO

CREATE PROCEDURE DVDLibraryEditDVD (
	@DvdId int,
	@RatingId int,
	@DirectorId int,
	@Title varchar(50),
	@RealeaseYear int,
	@Notes varchar(250)
)
AS
BEGIN
	UPDATE DvdTable SET
	RatingId = @RatingId, 
	DirectorId = @DirectorId, 
	Title = @Title, 
	RealeaseYear = @RealeaseYear, 
	Notes = @Notes
	WHERE DvdId = @DvdId;
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DVDLibraryFindDirector')
      DROP PROCEDURE DVDLibraryFindDirector
GO

CREATE PROCEDURE DVDLibraryFindDirector (
	@FirstName varchar(50),
	@LastName varchar(50)
)   AS
BEGIN
	SELECT d.DirectorID
	FROM Director d
	WHERE d.DirectorFirstName = @FirstName AND d.DirectorLastName = @LastName;
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DVDLibraryAddDirector')
      DROP PROCEDURE DVDLibraryAddDirector
GO

CREATE PROCEDURE DVDLibraryAddDirector (
	@DirectorID int output,
	@FirstName varchar(50),
	@LastName varchar(50)
)   AS
BEGIN
	INSERT INTO Director (DirectorFirstName, DirectorLastName)
	VALUES (@FirstName, @LastName);
		SET @DirectorID = SCOPE_IDENTITY();
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DVDLibraryDeleteDVDById')
      DROP PROCEDURE DVDLibraryDeleteDVDById
GO

CREATE PROCEDURE DVDLibraryDeleteDVDById (
	@DvdId int
)   AS
BEGIN
	DELETE DVDTable WHERE DvdId = @DvdId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DVDLibraryDeleteDirectorById')
      DROP PROCEDURE DVDLibraryDeleteDirectorById
GO

CREATE PROCEDURE DVDLibraryDeleteDirectorById (
	@DirectorId int
)   AS
BEGIN
	DELETE Director WHERE DirectorId = @DirectorId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DVDLibraryNumberOfDirectorRecords')
      DROP PROCEDURE DVDLibraryNumberOfDirectorRecords
GO

CREATE PROCEDURE DVDLibraryNumberOfDirectorRecords (
	@NumberOfRecords int output,
	@DirectorId int
)   AS
BEGIN
	SELECT DirectorId, COUNT(*) AS numrecords
	FROM DVDTable
	WHERE DirectorId = @DirectorId
	GROUP BY DirectorId;
END
GO





