USE master
GO

CREATE LOGIN DvdLibraryApp WITH PASSWORD='testing123'
GO

USE DVDLibrary
GO

CREATE USER DvdLibraryApp FOR LOGIN DvdLibraryApp
GO

GRANT EXECUTE ON DvdLibrarySelectAll TO DvdLibraryApp
GRANT EXECUTE ON DvdLibrarySelectById TO DvdLibraryApp
GRANT EXECUTE ON DvdLibrarySearch TO DvdLibraryApp
GRANT EXECUTE ON DvdLibraryAddDVD TO DvdLibraryApp
GRANT EXECUTE ON DvdLibraryEditDVD TO DvdLibraryApp
GRANT EXECUTE ON DvdLibraryFindDirector TO DvdLibraryApp
GRANT EXECUTE ON DvdLibraryAddDirector TO DvdLibraryApp
GRANT EXECUTE ON DvdLibraryDeleteDVDById TO DvdLibraryApp
GRANT EXECUTE ON DvdLibraryDeleteDirectorById TO DvdLibraryApp
GRANT EXECUTE ON DvdLibraryNumberOfDirectorRecords TO DvdLibraryApp
GO

GRANT SELECT ON DVDTable TO DvdLibraryApp
GRANT INSERT ON DVDTable TO DvdLibraryApp
GRANT UPDATE ON DVDTable TO DvdLibraryApp
GRANT DELETE ON DVDTable TO DvdLibraryApp

GRANT SELECT ON Director TO DvdLibraryApp
GRANT INSERT ON Director TO DvdLibraryApp
GRANT UPDATE ON Director TO DvdLibraryApp
GRANT DELETE ON Director TO DvdLibraryApp

GRANT SELECT ON Rating TO DvdLibraryApp
GRANT INSERT ON Rating TO DvdLibraryApp
GRANT UPDATE ON Rating TO DvdLibraryApp
GRANT DELETE ON Rating TO DvdLibraryApp
GO

