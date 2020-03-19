USE master;
DROP DATABASE IF EXISTS "Sydvest-Bo";

print char(13) + char(10) + '             *************************************************'
print '             **  Databasen ''Sydvest-Bo'' oprettes på ny    **'
create database "Sydvest-Bo";
go
print '             **                                             **'
use "Sydvest-Bo";
go
print '             **  og er taget i bruge..                      **'
print '             *************************************************' + char(13) + char(10)
go

CREATE TABLE Adresse
(
  "Adresseid"     int           NOT NULL IDENTITY(1,1),
  "Postnr"        int           NOT NULL,
  "Adressestring" nvarchar(127) NOT NULL DEFAULT '',
  CONSTRAINT PK_Adresse PRIMARY KEY (Adresseid)
)
GO

CREATE TABLE Distrikt
(
  "Distriktid" int           NOT NULL IDENTITY(1,1),
  "Omraade"    nvarchar(200) NOT NULL,
  CONSTRAINT PK_Distrikt PRIMARY KEY (Distriktid)
)
GO

CREATE TABLE Ejer
(
  "Ejerid"   int          NOT NULL IDENTITY(1,1),
  "Ejertype" nvarchar(25) NOT NULL DEFAULT 'Sommerhusejer',
  "Noter"    nvarchar     NOT NULL DEFAULT 'Noter',
  "Personid" int          NOT NULL,
  CONSTRAINT PK_Ejer PRIMARY KEY (Ejerid)
)
GO

CREATE TABLE Feriebolig
(
  "Ferieboligid"  int          NOT NULL IDENTITY(1,1),
  "Distriktid"    int          NOT NULL,
  "Adresseid"     int          NOT NULL,
  "Ejerid"        int          NOT NULL,
  "Opsynsmandid"  int          NOT NULL,
  "Stoerrelse"    int          NOT NULL DEFAULT 0,
  "Rum"           int          NOT NULL DEFAULT 0,
  "Senge"         int          NOT NULL DEFAULT 0,
  "Kvalitet"      nvarchar(47) NOT NULL DEFAULT '',
  "Pris"          money        NOT NULL DEFAULT 0.0,
  "FeriboligType" nvarchar(31) NOT NULL DEFAULT 'Sommerhus',
  "Noter"         nvarchar     NOT NULL DEFAULT 'Noter',
  CONSTRAINT PK_Feriebolig PRIMARY KEY (Ferieboligid)
)
GO

CREATE TABLE Kunde
(
  "Kundeid"  int      NOT NULL IDENTITY(1,1),
  "Personid" int      NOT NULL,
  "noter"    nvarchar NOT NULL DEFAULT 'Noter',
  CONSTRAINT PK_Kunde PRIMARY KEY (Kundeid)
)
GO

CREATE TABLE Kundekonsulent
(
  "Kundekonsulentid" int      NOT NULL IDENTITY(1,1),
  "Personid"         int      NOT NULL,
  "Noter"            nvarchar NOT NULL DEFAULT 'Noter',
  CONSTRAINT PK_Kundekonsulent PRIMARY KEY (Kundekonsulentid)
)
GO

CREATE TABLE Lejekontrakt
(
  "Lejekontrakid"           int      NOT NULL,
  "Ferieboligid"            int      NOT NULL,
  "Kundeid"                 int      NOT NULL,
  "Kundekonsulentid"        int      NOT NULL,
  "Udlejningskonsulentid"   int      NOT NULL,
  "KontraktDato"            date     NOT NULL DEFAULT GETDATE(),
  "Aar"                     int      NOT NULL DEFAULT 2020,
  "Uge"                     int      NOT NULL DEFAULT 1,
  "KundePris"               money    NOT NULL DEFAULT 0.0,
  "UdlejningsKontraktTekst" nvarchar NOT NULL DEFAULT '',
  "ElForbrug"               real     NOT NULL DEFAULT 0.0,
  CONSTRAINT PK_Lejekontrakt PRIMARY KEY (Lejekontrakid)
)
GO

CREATE TABLE Opsynsmand
(
  "Opsynsmandid" int      NOT NULL IDENTITY(1,1),
  "Personid"     int      NOT NULL,
  "Distriktid"   int      NOT NULL,
  "Noter"        nvarchar NOT NULL DEFAULT 'Noter',
  CONSTRAINT PK_Opsynsmand PRIMARY KEY (Opsynsmandid)
)
GO

CREATE TABLE Person
(
  "Personid"  int           NOT NULL IDENTITY(1,1),
  "Adresseid" int           NOT NULL,
  "Fornavn"   nvarchar(47)  NOT NULL DEFAULT '',
  "Efternavn" nvarchar(79)  NOT NULL DEFAULT '',
  "Email"     nvarchar(127) NOT NULL DEFAULT '',
  "Tlf"       nvarchar(20)  NOT NULL DEFAULT '',
  "Password"  nvarchar(31)  NOT NULL DEFAULT 'Spassw0rd',
  CONSTRAINT PK_Person PRIMARY KEY (Personid)
)
GO

CREATE TABLE PostnrBy
(
  "Postnr" int          NOT NULL,
  "Bynavn" nvarchar(79) NOT NULL DEFAULT '''',
  CONSTRAINT PK_PostnrBy PRIMARY KEY (Postnr)
)
GO

ALTER TABLE PostnrBy
  ADD CONSTRAINT UQ_Postnr UNIQUE (Postnr)
GO

CREATE TABLE Saesonkategori
(
  "Ugeid"           int  check ("Ugeid" > 0 and "Ugeid" < 53) NOT NULL,
  "Kategori"        int                                       NOT NULL,
  "Kategroi navn"   nvarchar(20)                              NOT NULL DEFAULT 'Mellem',
  "Prismodifikator" money                                     NOT NULL DEFAULT 1.0,
  CONSTRAINT PK_Saesonkategori PRIMARY KEY (Ugeid)
)
GO

ALTER TABLE Saesonkategori
  ADD CONSTRAINT UQ_Ugeid UNIQUE (Ugeid)
GO

CREATE TABLE Udlejningskonsulent
(
  "Udlejningskonsulentid" int NOT NULL IDENTITY(1,1),
  "Personid"              int NOT NULL,
  "Distriktid"            int NOT NULL,
  CONSTRAINT PK_Udlejningskonsulent PRIMARY KEY (Udlejningskonsulentid)
)
GO

CREATE TABLE Udlejningskontrakt
(
  "Udlejningskontraktid"    int      NOT NULL IDENTITY(1,1),
  "Ferieboligid"            int      NOT NULL,
  "Udlejningskonsulentid"   int      NOT NULL,
  "KontraktDato"            date     NOT NULL DEFAULT GETDATE(),
  "Aar"                     int      NOT NULL DEFAULT 0,
  "Uge"                     int      NOT NULL DEFAULT 0,
  "PrisEjer"                money    NOT NULL DEFAULT 0.0,
  "UdlejningsKontraktTekst" nvarchar NOT NULL DEFAULT '',
  CONSTRAINT PK_Udlejningskontrakt PRIMARY KEY (Udlejningskontraktid)
)
GO

ALTER TABLE Kunde
  ADD CONSTRAINT FK_Person_TO_Kunde
    FOREIGN KEY (Personid)
    REFERENCES Person (Personid)
GO

ALTER TABLE Person
  ADD CONSTRAINT FK_Adresse_TO_Person
    FOREIGN KEY (Adresseid)
    REFERENCES Adresse (Adresseid)
GO

ALTER TABLE Kundekonsulent
  ADD CONSTRAINT FK_Person_TO_Kundekonsulent
    FOREIGN KEY (Personid)
    REFERENCES Person (Personid)
GO

ALTER TABLE Udlejningskontrakt
  ADD CONSTRAINT FK_Udlejningskonsulent_TO_Udlejningskontrakt
    FOREIGN KEY (Udlejningskonsulentid)
    REFERENCES Udlejningskonsulent (Udlejningskonsulentid)
GO

ALTER TABLE Opsynsmand
  ADD CONSTRAINT FK_Person_TO_Opsynsmand
    FOREIGN KEY (Personid)
    REFERENCES Person (Personid)
GO

ALTER TABLE Feriebolig
  ADD CONSTRAINT FK_Opsynsmand_TO_Feriebolig
    FOREIGN KEY (Opsynsmandid)
    REFERENCES Opsynsmand (Opsynsmandid)
GO

ALTER TABLE Udlejningskonsulent
  ADD CONSTRAINT FK_Person_TO_Udlejningskonsulent
    FOREIGN KEY (Personid)
    REFERENCES Person (Personid)
GO

ALTER TABLE Feriebolig
  ADD CONSTRAINT FK_Distrikt_TO_Feriebolig
    FOREIGN KEY (Distriktid)
    REFERENCES Distrikt (Distriktid)
GO

ALTER TABLE Opsynsmand
  ADD CONSTRAINT FK_Distrikt_TO_Opsynsmand
    FOREIGN KEY (Distriktid)
    REFERENCES Distrikt (Distriktid)
GO

ALTER TABLE Udlejningskontrakt
  ADD CONSTRAINT FK_Feriebolig_TO_Udlejningskontrakt
    FOREIGN KEY (Ferieboligid)
    REFERENCES Feriebolig (Ferieboligid)
GO

ALTER TABLE Udlejningskonsulent
  ADD CONSTRAINT FK_Distrikt_TO_Udlejningskonsulent
    FOREIGN KEY (Distriktid)
    REFERENCES Distrikt (Distriktid)
GO

ALTER TABLE Feriebolig
  ADD CONSTRAINT FK_Adresse_TO_Feriebolig
    FOREIGN KEY (Adresseid)
    REFERENCES Adresse (Adresseid)
GO

ALTER TABLE Lejekontrakt
  ADD CONSTRAINT FK_Kunde_TO_Lejekontrakt
    FOREIGN KEY (Kundeid)
    REFERENCES Kunde (Kundeid)
GO

ALTER TABLE Lejekontrakt
  ADD CONSTRAINT FK_Kundekonsulent_TO_Lejekontrakt
    FOREIGN KEY (Kundekonsulentid)
    REFERENCES Kundekonsulent (Kundekonsulentid)
GO

ALTER TABLE Lejekontrakt
  ADD CONSTRAINT FK_Udlejningskonsulent_TO_Lejekontrakt
    FOREIGN KEY (Udlejningskonsulentid)
    REFERENCES Udlejningskonsulent (Udlejningskonsulentid)
GO

ALTER TABLE Feriebolig
  ADD CONSTRAINT FK_Ejer_TO_Feriebolig
    FOREIGN KEY (Ejerid)
    REFERENCES Ejer (Ejerid)
GO

ALTER TABLE Lejekontrakt
  ADD CONSTRAINT FK_Feriebolig_TO_Lejekontrakt
    FOREIGN KEY (Ferieboligid)
    REFERENCES Feriebolig (Ferieboligid)
GO

ALTER TABLE Ejer
  ADD CONSTRAINT FK_Person_TO_Ejer
    FOREIGN KEY (Personid)
    REFERENCES Person (Personid)
GO

ALTER TABLE Adresse
  ADD CONSTRAINT FK_PostnrBy_TO_Adresse
    FOREIGN KEY (Postnr)
    REFERENCES PostnrBy (Postnr)
GO

/*
------ USER controle
GRANT SELECT, INSERT, UPDATE, DELETE ON "Sydvest-Bo" TO tec;
USE "Sydvest-Bo"
GO

EXEC sp_addrolemember 'db_datareader', 'tec'

EXEC sp_addrolemember 'db_datawriter', 'tec'

EXEC sp_addrolemember 'db_ddladmin', 'tec'

go
*/