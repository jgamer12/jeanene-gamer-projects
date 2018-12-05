USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='DVDLibrary')
DROP DATABASE DVDLibrary
GO

CREATE DATABASE DVDLibrary
GO

USE DVDLibrary
GO

-- Tables
IF EXISTS(SELECT * FROM sys.tables WHERE name='DVDTable')
	DROP TABLE DVDTable
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Rating')
	DROP TABLE Rating
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Director')
	DROP TABLE Director
GO

CREATE TABLE Director (
	DirectorID int identity(1,1) primary key not null,
	DirectorFirstName varchar(50) null,
	DirectorLastName varchar(50) not null
)
GO

CREATE TABLE Rating (
	RatingId int identity(1,1) primary key not null,
	RatingName varchar(10) not null
)
GO

CREATE TABLE DVDTable (
	DvdId int identity(1,1) primary key not null,
	RatingId int foreign key references Rating(RatingId) null,
	DirectorId int foreign key references Director(DirectorId) null,
	Title varchar(50) not null,
	RealeaseYear int null,
	Notes varchar(250) null
)
GO