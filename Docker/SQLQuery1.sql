------------------------------------------------------------------------------
IF NOT EXISTS(select * from sys.databases where name = 'Ewidencja3')
	CREATE DATABASE Ewidencja
	GO
USE Ewidencja
GO

IF NOT EXISTS(select * from sysobjects where name = 'Pracownik')
	CREATE TABLE Pracownik (
		IDPracownika INT PRIMARY KEY IDENTITY(1,1),
		Imie VARCHAR(20) NOT NULL,
		Nazwisko VARCHAR(20) NOT NULL,
		Stanowisko VARCHAR(40) NOT NULL,
		Uprawnienia VARCHAR(20) NOT NULL,
		Telefon INT 
	)
	GO

IF NOT EXISTS(select * from sysobjects where name = 'Projekt')
	CREATE TABLE Projekt (
		IDProjektu INT PRIMARY KEY IDENTITY(1,1),
		NazwaProjektu VARCHAR(255) NOT NULL,
		IDPracownika INT FOREIGN KEY REFERENCES Pracownik(IDPracownika) 
	)
	GO

IF NOT EXISTS(select * from sysobjects where name = 'Zadanie')
	CREATE TABLE Zadanie (
		IDZadania INT PRIMARY KEY IDENTITY(1,1),
		NazwaZadania VARCHAR(255) NOT NULL,
		IDProjektu INT FOREIGN KEY REFERENCES Projekt(IDProjektu)
	)
	GO

IF NOT EXISTS(select * from sysobjects where name = 'Wykonanie')
	CREATE TABLE Wykonanie (
		PoczZadania DATETIME2 NOT NULL,
		ZakZadania DATETIME2 NOT NULL,
		SumaGodzin INT,
		IDPracownika INT FOREIGN KEY REFERENCES Pracownik(IDPracownika), 
		IDZadania INT FOREIGN KEY REFERENCES Zadanie(IDZadania)
	)
	GO

----------------------TRIGGERS------------------------

CREATE OR ALTER TRIGGER TriggerImie ON Pracownik
FOR INSERT
AS
DECLARE @Imie VARCHAR(20)
	SELECT @Imie = Imie FROM inserted
IF (@Imie is null) 
	BEGIN
		
		RAISERROR('Pole Imie nie moze byc puste!',1,2)
		ROLLBACK
	END
GO

CREATE OR ALTER TRIGGER TriggerNazwisko ON Pracownik
FOR INSERT
AS
DECLARE @_Nazwisko VARCHAR(20)
	SELECT @_Nazwisko = Nazwisko FROM Pracownik
IF @_Nazwisko = null 
	BEGIN
		ROLLBACK
		RAISERROR('Pole Nazwisko nie moze byc puste!',1,2)
	END
GO

CREATE OR ALTER TRIGGER TriggerNazwaZadania ON Zadanie
FOR INSERT
AS
DECLARE @_Zadanie VARCHAR(255)
	SELECT @_Zadanie = NazwaZadania FROM Zadanie
IF @_Zadanie = null 
	BEGIN
		ROLLBACK
		RAISERROR('Pole Nazwa Zadania nie moze byc puste!',1,2)
	END
GO

CREATE OR ALTER TRIGGER TriggerNazwaProjektu ON Projekt
FOR INSERT
AS
DECLARE @_Projekt VARCHAR(255)
	SELECT @_Projekt = NazwaProjektu FROM Projekt
IF @_Projekt = null 
	BEGIN
		ROLLBACK
		RAISERROR('Pole Nazwa Projektu nie moze byc puste!',1,2)
	END
GO

-------------------------------PROCEDURES--------------------------------------
CREATE OR ALTER PROCEDURE ProcNowyUser 
	@imie VARCHAR(25), 
	@nazwisko VARCHAR(25), 
	@stanowisko VARCHAR(25), 
	@telefon INT 
AS
BEGIN
INSERT INTO Pracownik(Imie, Nazwisko, Stanowisko, Telefon)
VALUES(
	@imie,
	@nazwisko, 
	@stanowisko,
	@telefon)
END
GO

CREATE OR ALTER PROCEDURE ProcNowyProjekt
	@VarNazwaProjektu varchar(255)
AS
BEGIN
INSERT INTO Projekt(NazwaProjektu)
VALUES(
	@VarNazwaProjektu
	)
END
GO

--select * from Pracownik
--CREATE OR ALTER PROCEDURE ProcNoweZadanie @

--Exec ProcNowyUser 'ela1','Koteluk','kuchta', 2342
--GO
--
--	IDPracownika INT PRIMARY KEY IDENTITY(1,1),
--		Imie VARCHAR(20) NOT NULL,
--		Nazwisko VARCHAR(20) NOT NULL,
--		Stanowisko VARCHAR(40) NULL,
--		Telefon INT 
--		*/