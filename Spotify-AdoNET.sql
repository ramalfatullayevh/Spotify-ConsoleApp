CREATE DATABASE SpotifyAdonet
USE SpotifyAdonet


CREATE TABLE Users
(
	Id int identity	PRIMARY KEY,
	Name nvarchar(15) Not Null CHECK(LEN(Name)>2),
	Surname nvarchar(25) Not Null CHECK(LEN(Surname)>=5),
	Username nvarchar(50) Not Null CHECK(LEN(Username)>=6) UNIQUE,
	Password nvarchar(20) Not Null CHECK(LEN(Password)>=8),
	Gender nvarchar(10) Not Null CHECK(LEN(Gender)>3),
	RoleId int REFERENCES Roles(Id)
)

CREATE TABLE Roles
(
	Id int identity	PRIMARY KEY,
	Type nvarchar(20) Not Null CHECK(LEN(Type)>3)
)

CREATE TABLE Artists
(
	Id int identity PRIMARY KEY,
	Name nvarchar(15) Not Null CHECK(LEN(Name)>2),
	Surname nvarchar(25) Not Null CHECK(LEN(Surname)>=5),
	Birthday datetime Not Null,
	Gender nvarchar(10) Not Null CHECK(LEN(Gender)>3)
)

CREATE TABLE Categories
(
	Id int identity PRIMARY KEY,
	Name nvarchar(100) Not Null unique CHECK(LEN(Name)>2),
)

CREATE TABLE Musics
(
	Id int identity PRIMARY KEY,
	Name nvarchar(150) Not Null CHECK(LEN(Name)>0),
	Duration int Not Null CHECK(Duration>0 and Duration<1000),
	CategoryId int REFERENCES Categories(Id)
)

CREATE TABLE MusicArtists
(
	Id int identity PRIMARY KEY,
	ArtistId int REFERENCES Artists(Id),
	MusicId int REFERENCES Musics(Id)
)

ALTER TABLE Musics
ADD DeletedTime datetime

CREATE TRIGGER DeleteMusic
ON Musics
INSTEAD OF DELETE
AS
BEGIN 
	DECLARE @Id int , @DeletedDate datetime
	SELECT @Id =Id , @DeletedDate = DeletedTime FROM deleted
		DELETE MusicArtists WHERE MusicId = @Id
		IF(@DeletedDate IS NULL)
		UPDATE Musics
		SET DeletedTime = GETUTCDATE()
		WHERE Id = @Id
		ELSE
		DELETE Musics WHERE Id = @Id
END

----------------------------------------
ALTER TABLE Artists
ADD DeletedTime datetime

CREATE TRIGGER DeleteArtist
ON Artists
INSTEAD OF DELETE
AS
BEGIN 
	DECLARE @Id int , @DeletedDate datetime
	SELECT @Id =Id , @DeletedDate = DeletedTime FROM deleted
		DELETE MusicArtists WHERE ArtistId = @Id
		IF(@DeletedDate IS NULL)
		UPDATE Artists
		SET DeletedTime = GETUTCDATE()
		WHERE Id = @Id
		ELSE
		DELETE Artists WHERE Id = @Id
END


