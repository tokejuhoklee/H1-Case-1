-- 13 Sandbox -------------------------------------

USE "Sydvest-Bo";
GO

CREATE TABLE Sandbox
(
  "Id"      int           NOT NULL,
  "Navn"    nvarchar(127) NOT NULL DEFAULT '',
  "Heltal"  int           NOT NULL,
  "Penge"   money         NOT NULL DEFAULT 0.0,
  "Dato"    date          NOT NULL DEFAULT GETDATE(),
)
GO
-- Id, Navn, Heltal,Penge,Dato

INSERT INTO Sandbox (Id, Navn, Heltal, Penge) VALUES
  (1,'Bengalsk bønnesalat',1,100.00),
  (2,'Erik Påskebryg',2,200),
  (3,'Palmin fedt',4,500.50),
  (4,'rød pølse = konfirmant pik',8,27.50),
  (5,'Heste galocher',16,11111.11);
GO
