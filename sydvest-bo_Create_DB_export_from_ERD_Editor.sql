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

CREATE TABLE "Address"
(
  "Address id" int           NOT NULL IDENTITY(1,1),
  "ZipCode id" int           NOT NULL,
  "Adresse"    nvarchar(127) NOT NULL DEFAULT '',
  CONSTRAINT "PK_Address" PRIMARY KEY ("Address id")
)
GO

CREATE TABLE Customer
(
  "Customer id" int      NOT NULL IDENTITY(1,1),
  "Person id"   int      NOT NULL,
  "Notes"       nvarchar NOT NULL DEFAULT '',
  CONSTRAINT "PK_Customer" PRIMARY KEY ("Customer id")
)
GO

CREATE TABLE "Customer Consultant"
(
  "Customer Consultant id" int      NOT NULL IDENTITY(1,1),
  "Person id"              int      NOT NULL,
  "Etc"                    nvarchar NOT NULL DEFAULT '',
  CONSTRAINT "PK_Customer Consultant" PRIMARY KEY ("Customer Consultant id")
)
GO

CREATE TABLE "Customer Rental Contract"
(
  "Customer id"                   int      NOT NULL,
  "Customer Consultant id"        int      NOT NULL,
  "Rental Consultant id"          int      NOT NULL,
  "Date of contract"              date     NOT NULL DEFAULT GETDATE(),
  "Date Start Rent"               date     NOT NULL DEFAULT GETDATE(),
  "Date End Rent"                 date     NOT NULL DEFAULT GETDATE(),
  "Price"                         money    NOT NULL DEFAULT 0.0,
  "Price modifyer"                float    NOT NULL DEFAULT 1.0,
  "Customer Rental Contract Text" nvarchar NOT NULL DEFAULT ''
)
GO

CREATE TABLE District
(
  "Area id"              int           NOT NULL IDENTITY(1,1),
  "Area name"            nvarchar(200) NOT NULL,
  "Rental consultant id" int           NOT NULL,
  CONSTRAINT "PK_District" PRIMARY KEY ("Area id")
)
GO

CREATE TABLE "Independant overseer"
(
  "Independant overseer id" int      NOT NULL IDENTITY(1,1),
  "Person id"               int      NOT NULL,
  "Etc"                     nvarchar NOT NULL DEFAULT '',
  CONSTRAINT "PK_Independant overseer" PRIMARY KEY ("Independant overseer id")
)
GO

CREATE TABLE Person
(
  "Person id"  int           NOT NULL IDENTITY(1,1),
  "Address id" int           NOT NULL,
  "Name"       nvarchar(47)  NOT NULL DEFAULT '',
  "Last name"  nvarchar(79)  NOT NULL DEFAULT '',
  "Email"      nvarchar(127) NOT NULL DEFAULT '',
  "PhoneNo"    nvarchar(20)  NOT NULL DEFAULT '',
  CONSTRAINT "PK_Person" PRIMARY KEY ("Person id")
)
GO

CREATE TABLE "Rental Consultant"
(
  "Rental Consultant id" int NOT NULL IDENTITY(1,1),
  "Person id"            int NOT NULL,
  CONSTRAINT "PK_Rental Consultant" PRIMARY KEY ("Rental Consultant id")
)
GO

CREATE TABLE Residence
(
  "Residence id"                int          NOT NULL IDENTITY(1,1),
  "Residence Owner Contract id" int          NOT NULL,
  "Independant overseer id"     int          NOT NULL,
  "Address id"                  int          NOT NULL,
  "Area"                        int          NOT NULL,
  "Size"                        int          NOT NULL DEFAULT 0,
  "Rooms"                       int          NOT NULL DEFAULT 0,
  "Number of beds"              int          NOT NULL DEFAULT 0,
  "Rental quality"              nvarchar(47) NOT NULL DEFAULT '',
  "Etc"                         nvarchar     NOT NULL DEFAULT '',
  "Base Price"                  money        NOT NULL DEFAULT 0.0,
  "Residence Type"              nvarchar(31) NOT NULL DEFAULT '',
  CONSTRAINT "PK_Residence" PRIMARY KEY ("Residence id")
)
GO

CREATE TABLE "Residence Owner"
(
  "Residence Owner id" int      NOT NULL IDENTITY(1,1),
  "Person id"          int      NOT NULL,
  "Etc"                nvarchar NOT NULL DEFAULT '',
  CONSTRAINT "PK_Residence Owner" PRIMARY KEY ("Residence Owner id")
)
GO

CREATE TABLE "Residence Owner Contract"
(
  "Residence Owner Contract id"   int      NOT NULL IDENTITY(1,1),
  "Residence Owner id"            int      NOT NULL,
  "Rental consultant id"          int      NOT NULL,
  "Date of contract"              date     NOT NULL DEFAULT GETDATE(),
  "Date Start Rent"               date     NOT NULL DEFAULT GETDATE(),
  "Date End Rent"                 date     NOT NULL DEFAULT GETDATE(),
  "Price"                         money    NOT NULL DEFAULT 0.0,
  "Residence Owner Contract Text" nvarchar NOT NULL DEFAULT '',
  CONSTRAINT "PK_Residence Owner Contract" PRIMARY KEY ("Residence Owner Contract id")
)
GO

CREATE TABLE Vacancy
(
  "year"                        date  NOT NULL,
  "week"                        date  NOT NULL,
  "Residence id"                int   NOT NULL,
  "Udlejnings pris"             money NOT NULL DEFAULT 0.0,
  "Residence Owner Contract id" int   NOT NULL DEFAULT 0,
  CONSTRAINT "PK_Vacancy" PRIMARY KEY (year, week, "Residence id")
)
GO

CREATE TABLE "ZipCode Town"
(
  "ZipCode id" int  check ("ZipCode id" > 99 and "ZipCode id" < 10000) NOT NULL,
  "Town"       nvarchar(79)                                            NOT NULL DEFAULT '''',
  CONSTRAINT "PK_ZipCode Town" PRIMARY KEY ("ZipCode id")
)
GO

ALTER TABLE "ZipCode Town"
  ADD CONSTRAINT "UQ_ZipCode id" UNIQUE ("ZipCode id")
GO

ALTER TABLE Residence
  ADD CONSTRAINT "FK_District_TO_Residence"
    FOREIGN KEY (Area)
    REFERENCES District ("Area id")
GO

ALTER TABLE "Residence Owner"
  ADD CONSTRAINT "FK_Person_TO_Residence Owner"
    FOREIGN KEY ("Person id")
    REFERENCES Person ("Person id")
GO

ALTER TABLE "Customer Consultant"
  ADD CONSTRAINT "FK_Person_TO_Customer Consultant"
    FOREIGN KEY ("Person id")
    REFERENCES Person ("Person id")
GO

ALTER TABLE "Rental Consultant"
  ADD CONSTRAINT "FK_Person_TO_Rental Consultant"
    FOREIGN KEY ("Person id")
    REFERENCES Person ("Person id")
GO

ALTER TABLE District
  ADD CONSTRAINT "FK_Rental Consultant_TO_District"
    FOREIGN KEY ("Rental consultant id")
    REFERENCES "Rental Consultant" ("Rental Consultant id")
GO

ALTER TABLE "Customer Rental Contract"
  ADD CONSTRAINT "FK_Customer_TO_Customer Rental Contract"
    FOREIGN KEY ("Customer id")
    REFERENCES Customer ("Customer id")
GO

ALTER TABLE Customer
  ADD CONSTRAINT "FK_Person_TO_Customer"
    FOREIGN KEY ("Person id")
    REFERENCES Person ("Person id")
GO

ALTER TABLE "Independant overseer"
  ADD CONSTRAINT "FK_Person_TO_Independant overseer"
    FOREIGN KEY ("Person id")
    REFERENCES Person ("Person id")
GO

ALTER TABLE Person
  ADD CONSTRAINT "FK_Address_TO_Person"
    FOREIGN KEY ("Address id")
    REFERENCES "Address" ("Address id")
GO

ALTER TABLE "Address"
  ADD CONSTRAINT "FK_ZipCode Town_TO_Address"
    FOREIGN KEY ("ZipCode id")
    REFERENCES "ZipCode Town" ("ZipCode id")
GO

ALTER TABLE Residence
  ADD CONSTRAINT "FK_Residence Owner Contract_TO_Residence"
    FOREIGN KEY ("Residence Owner Contract id")
    REFERENCES "Residence Owner Contract" ("Residence Owner Contract id")
GO

ALTER TABLE Residence
  ADD CONSTRAINT "FK_Address_TO_Residence"
    FOREIGN KEY ("Address id")
    REFERENCES Address ("Address id")
GO

ALTER TABLE Residence
  ADD CONSTRAINT "FK_Independant overseer_TO_Residence"
    FOREIGN KEY ("Independant overseer id")
    REFERENCES "Independant overseer" ("Independant overseer id")
GO

ALTER TABLE "Residence Owner Contract"
  ADD CONSTRAINT "FK_Rental Consultant_TO_Residence Owner Contract"
    FOREIGN KEY ("Rental consultant id")
    REFERENCES "Rental Consultant" ("Rental Consultant id")
GO

ALTER TABLE Vacancy
  ADD CONSTRAINT "FK_Residence_TO_Vacancy"
    FOREIGN KEY ("Residence id")
    REFERENCES Residence ("Residence id")
GO

ALTER TABLE Vacancy
  ADD CONSTRAINT "FK_Residence Owner Contract_TO_Vacancy"
    FOREIGN KEY ("Residence Owner Contract id")
    REFERENCES "Residence Owner Contract" ("Residence Owner Contract id")
GO

ALTER TABLE "Customer Rental Contract"
  ADD CONSTRAINT "FK_Rental Consultant_TO_Customer Rental Contract"
    FOREIGN KEY ("Rental Consultant id")
    REFERENCES "Rental Consultant" ("Rental Consultant id")
GO

ALTER TABLE "Customer Rental Contract"
  ADD CONSTRAINT "FK_Customer Consultant_TO_Customer Rental Contract"
    FOREIGN KEY ("Customer Consultant id")
    REFERENCES "Customer Consultant" ("Customer Consultant id")
GO

ALTER TABLE "Residence Owner Contract"
  ADD CONSTRAINT "FK_Residence Owner_TO_Residence Owner Contract"
    FOREIGN KEY ("Residence Owner id")
    REFERENCES "Residence Owner" ("Residence Owner id")
GO

------ USER controle
USE "Sydvest-Bo"
GO

ALTER ROLE db_datareader ADD MEMBER tec
GO

ALTER ROLE db_datawriter ADD MEMBER tec
GO

ALTER ROLE db_ddladmin ADD MEMBER tec
go

---- Insert from Resources
/*
BULK INSERT "ZipCode Town"
FROM 'd:\TEC.Datatekniker\H1\Versionering og Dokumentation\H1-Case-1\Resources\postnumre.csv'
WITH
(
    FORMAT = 'CSV', 
    FIELDQUOTE = '"',
    FIRSTROW = 2,
    FIELDTERMINATOR = ';',  --CSV field delimiter
    ROWTERMINATOR = '\n',   --Use to shift the control to next row
    TABLOCK
)
GO
*/

/*
-- BULK INSERT "ZipCode Town"
BULK INSERT [dbo].[ZipCode Town]
FROM 'd:\TEC.Datatekniker\H1\Versionering og Dokumentation\H1-Case-1\Resources\postnumre.csv'
with (
    FIRSTROW = 2,
    FIELDTERMINATOR = ';',
    ROWTERMINATOR = '\n',
    BATCHSIZE = 250000,
    MAXERRORS = 2,
    CODEPAGE = 65001
);
GO
*/