if exists (select * from sys.databases where name = '[Sydvest-Bo]')
begin
  print '           Da databasen ''[Sydvest-Bo]'' eksistere i forvejen slettes den' + char(13) + char(10)
  -- smid alle andre brugere af
  alter database [Sydvest-Bo] set single_user
  print '             alter database [Sydvest-Bo] set single_user ... done!'
  drop database [Sydvest-Bo]
  print '             drop database [Sydvest-Bo] ... done!' + char(13) + char(10)
end
else
begin
  print '           Databasen ''[Sydvest-Bo]'' eksistere ikke i forvejen!' + char(13) + char(10)
end;
go

print char(13) + char(10) + '             *************************************************'
print '             **  Databasen ''[Sydvest-Bo]'' oprettes på ny  **'
create database [Sydvest-Bo];
go
print '             **                                             **'
use [Sydvest-Bo];
go
print '             **  og er taget i bruge..                      **'
print '             *************************************************' + char(13) + char(10)
go



CREATE TABLE [Address]
(
  [Address id] int           NOT NULL IDENTITY(1,1),
  [ZipCode id] int           NOT NULL,
  [Adresse]    nvarchar(150) NOT NULL DEFAULT '',
  CONSTRAINT [PK Address] PRIMARY KEY ([Address id])
)
GO

EXECUTE sys.sp_addextendedproperty 'MS_Description',
  'Anything with an address', 'user', dbo, 'table', 'Address'
GO

CREATE TABLE Customer
(
  [Customer id] int            NOT NULL IDENTITY(1,1),
  [Person id]   int            NOT NULL,
  Notes         nvarchar       NOT NULL DEFAULT '',
  CONSTRAINT [PK Customer] PRIMARY KEY ([Customer id])
)
GO

CREATE TABLE [Customer consultant]
(
  [Customer consultant id]  int            NOT NULL IDENTITY(1,1),
  [Person id]               int            NOT NULL,
  Etc                       nvarchar       NOT NULL DEFAULT '',
  CONSTRAINT [PK Customer consultant] PRIMARY KEY ([Customer consultant id])
)
GO

CREATE TABLE [Customer Rental Contract Relation]
(
  [Customer id]                   int            NOT NULL,
  [Customer consultant id]        int            NOT NULL,
  [Rental consultant id]          int            NOT NULL,
  [Customer Rental Contract Text] nvarchar       NOT NULL DEFAULT '',
  [Date of contract]              date           NOT NULL DEFAULT GETDATE(),
  [Date Start Rent]               date           NOT NULL DEFAULT GETDATE(),
  [Date End Rent]                 date           NOT NULL DEFAULT GETDATE(),
  Price                           money          NOT NULL DEFAULT 0.0,
  [Price modifyer]                float          NOT NULL DEFAULT 1.0
)
GO

CREATE TABLE District
(
  [Area id]              int           NOT NULL IDENTITY(1,1),
  [Area name]            nvarchar(200) NOT NULL,
  [Rental consultant id] int           NOT NULL,
  CONSTRAINT [PK District] PRIMARY KEY ([Area id])
)
GO

EXECUTE sys.sp_addextendedproperty 'MS_Description',
  'Add regions to this field later', 'user', dbo, 'table', 'District'
GO

CREATE TABLE [Independant overseer]
(
  [Independant overseer id] int            NOT NULL IDENTITY(1,1),
  [Person id]               int            NOT NULL,
  Etc                       nvarchar       NOT NULL DEFAULT '',
  CONSTRAINT [PK Independant overseer] PRIMARY KEY ([Independant overseer id])
)
GO

EXECUTE sys.sp_addextendedproperty 'MS_Description',
  'Keeps track of used electricity, and for changes made to the buildings', 'user', dbo, 'table', 'Independant overseer'
GO

CREATE TABLE Person
(
  [Person id]  int          NOT NULL IDENTITY(1,1),
  [Address id] int          NOT NULL,
  [Name]       nvarchar(50) NOT NULL DEFAULT '',
  [Last name]  nvarchar(75) NOT NULL DEFAULT '',
  Email        nvarchar(50) NOT NULL DEFAULT '',
  PhoneNo      nvarchar(20) NOT NULL DEFAULT '',
  CONSTRAINT [PK Person] PRIMARY KEY ([Person id])
)
GO

EXECUTE sys.sp_addextendedproperty 'MS_Description',
  'All Persons', 'user', dbo, 'table', 'Person'
GO

CREATE TABLE [Rental consultant]
(
  [Rental consultant id] int NOT NULL IDENTITY(1,1),
  [Person id]            int NOT NULL,
  CONSTRAINT [PK Rental consultant] PRIMARY KEY ([Rental consultant id])
)
GO

EXECUTE sys.sp_addextendedproperty 'MS_Description',
  'Speaks with owners,', 'user', dbo, 'table', 'Rental consultant'
GO

CREATE TABLE [Summerhouse owner]
(
  [Summerhouse owner id] int            NOT NULL IDENTITY(1,1),
  [Person id]            int            NOT NULL,
  Etc                    nvarchar       NOT NULL DEFAULT '',
  CONSTRAINT [PK Summerhouse owner] PRIMARY KEY ([Summerhouse owner id])
)
GO

CREATE TABLE [Summerhouse Owner Contract Relation]
(
  [Summerhouse Owner Contract id]   int            NOT NULL IDENTITY(1,1),
  [Summerhouse owner id]            int            NOT NULL,
  [Rental consultant id]            int            NOT NULL,
  [Date of contract]                date           NOT NULL DEFAULT GETDATE(),
  [Date Start Rent]                 date           NOT NULL DEFAULT GETDATE(),
  [Date End Rent]                   date           NOT NULL DEFAULT GETDATE(),
  [Summerhouse Owner Contract Text] nvarchar       NOT NULL DEFAULT '',
  Price                             money          NOT NULL DEFAULT 0.0,
  CONSTRAINT [PK Summerhouse Owner Contract Relation] PRIMARY KEY ([Summerhouse Owner Contract id])
)
GO

CREATE TABLE Summerhouses
(
  [Summerhouse id]                int            NOT NULL IDENTITY(1,1),
  [Summerhouse Owner Contract id] int            NOT NULL,
  [Independant overseer id]       int            NOT NULL,
  [Address id]                    int            NOT NULL,
  Area                            int            NOT NULL,
  Size                            int            NOT NULL DEFAULT 0,
  Rooms                           int            NOT NULL DEFAULT 0,
  [Number of beds]                int            NOT NULL DEFAULT 0,
  [Rental quality]                nvarchar(50)   NOT NULL DEFAULT '',
  Etc                             nvarchar       NOT NULL DEFAULT '',
  [Base Price]                    money          NOT NULL DEFAULT 0.0,
  [Residence Type]                nvarchar(20)   NOT NULL DEFAULT '',
  CONSTRAINT [PK Summerhouses] PRIMARY KEY ([Summerhouse id])
)
GO

CREATE TABLE [Vacancy]
(
  year                            date  NOT NULL,
  week                            date  NOT NULL,
  [Summerhouse id]                int   NOT NULL,
  [Udlejnings pris]               money NOT NULL DEFAULT 0.0,
  [Summerhouse Owner Contract id] int   NOT NULL,
  CONSTRAINT [PK Vacancy] PRIMARY KEY (year, week, [Summerhouse id])
)
GO


CREATE TABLE [Zip Code and Town]
(
  [ZipCode id] int check ([ZipCode id] > 999 and [ZipCode id] < 10000) NOT NULL,
  Town         nvarchar(66)                                            NOT NULL DEFAULT '',
  CONSTRAINT [PK Zip Code and Town] PRIMARY KEY ([ZipCode id])
)
GO

ALTER TABLE [Zip Code and Town]
  ADD CONSTRAINT [UQ ZipCode id] UNIQUE ([ZipCode id])
GO

ALTER TABLE Summerhouses
  ADD CONSTRAINT [FK District TO Summerhouses]
    FOREIGN KEY (Area)
    REFERENCES District ([Area id])
GO

ALTER TABLE [Summerhouse owner]
  ADD CONSTRAINT [FK Person TO Summerhouse owner]
    FOREIGN KEY ([Person id])
    REFERENCES Person ([Person id])
GO

ALTER TABLE [Customer consultant]
  ADD CONSTRAINT [FK Person TO Customer consultant]
    FOREIGN KEY ([Person id])
    REFERENCES Person ([Person id])
GO

ALTER TABLE [Rental consultant]
  ADD CONSTRAINT [FK Person TO Rental consultant]
    FOREIGN KEY ([Person id])
    REFERENCES Person ([Person id])
GO

ALTER TABLE [Summerhouse Owner Contract Relation]
  ADD CONSTRAINT [FK Summerhouse owner TO Summerhouse Owner Contract Relation]
    FOREIGN KEY ([Summerhouse owner id])
    REFERENCES [Summerhouse owner] ([Summerhouse owner id])
GO

ALTER TABLE District
  ADD CONSTRAINT [FK Rental consultant TO District]
    FOREIGN KEY ([Rental consultant id])
    REFERENCES [Rental consultant] ([Rental consultant id])
GO

ALTER TABLE [Customer Rental Contract Relation]
  ADD CONSTRAINT [FK Customer TO Customer Rental Contract Relation]
    FOREIGN KEY ([Customer id])
    REFERENCES Customer ([Customer id])
GO

ALTER TABLE [Customer Rental Contract Relation]
  ADD CONSTRAINT [FK Customer consultant TO Customer Rental Contract Relation]
    FOREIGN KEY ([Customer consultant id])
    REFERENCES [Customer consultant] ([Customer consultant id])
GO

ALTER TABLE Customer
  ADD CONSTRAINT [FK Person TO Customer]
    FOREIGN KEY ([Person id])
    REFERENCES Person ([Person id])
GO

ALTER TABLE [Independant overseer]
  ADD CONSTRAINT [FK Person TO Independant overseer]
    FOREIGN KEY ([Person id])
    REFERENCES Person ([Person id])
GO

ALTER TABLE Person
  ADD CONSTRAINT [FK Address TO Person]
    FOREIGN KEY ([Address id])
    REFERENCES [Address] ([Address id])
GO

ALTER TABLE Address
  ADD CONSTRAINT [FK Zip Code and Town TO Address]
    FOREIGN KEY ([ZipCode id])
    REFERENCES [Zip Code and Town] ([ZipCode id])
GO

ALTER TABLE Summerhouses
  ADD CONSTRAINT [FK Summerhouse Owner Contract Relation TO Summerhouses]
    FOREIGN KEY ([Summerhouse Owner Contract id])
    REFERENCES [Summerhouse Owner Contract Relation] ([Summerhouse Owner Contract id])
GO

ALTER TABLE Summerhouses
  ADD CONSTRAINT [FK Address TO Summerhouses]
    FOREIGN KEY ([Address id])
    REFERENCES Address ([Address id])
GO

ALTER TABLE Summerhouses
  ADD CONSTRAINT [FK Independant overseer TO Summerhouses]
    FOREIGN KEY ([Independant overseer id])
    REFERENCES [Independant overseer] ([Independant overseer id])
GO

ALTER TABLE [Customer Rental Contract Relation]
  ADD CONSTRAINT [FK Rental consultant TO Customer Rental Contract Relation]
    FOREIGN KEY ([Rental consultant id])
    REFERENCES [Rental consultant] ([Rental consultant id])
GO

ALTER TABLE [Summerhouse Owner Contract Relation]
  ADD CONSTRAINT [FK Rental consultant TO Summerhouse Owner Contract Relation]
    FOREIGN KEY ([Rental consultant id])
    REFERENCES [Rental consultant] ([Rental consultant id])
GO

ALTER TABLE Vacancy
  ADD CONSTRAINT [FK Summerhouses TO Vacancy]
    FOREIGN KEY ([Summerhouse id])
    REFERENCES Summerhouses ([Summerhouse id])
GO

ALTER TABLE Vacancy
  ADD CONSTRAINT [FK Summerhouse Owner Contract Relation TO Vacancy]
    FOREIGN KEY ([Summerhouse Owner Contract id])
    REFERENCES [Summerhouse Owner Contract Relation] ([Summerhouse Owner Contract id])
GO
