-- Ejere Sommerhus -------------

USE "Sydvest-Bo"
GO

INSERT INTO Adresse (Adressestring,Postnr) VALUES
  ('Sydvest-Bo admin 1 1. th.',2450),
  ('<Hemmelig>',2400),
  ('Bakkevænget 2',9750),
  ('Blåhegnet 36',2670),
  ('Filshuse 14, Sandager',5610),
  ('Sikavej 23',7160),
  ('Ørskovbakken 42, Snejbjerg',7400);
GO

INSERT INTO Person (Fornavn, Efternavn, Adresseid, Email, Person.Tlf, [Password]) VALUES
  ('Test','Sommerhus Ejer',7,'ejer@sydvest-bo.dk','26145443',' '),
  ('Pernille','Bendixen',8,'pernille.bendixen@ft.dk','+45 3337 5500',' '),
  ('Bent','Bøgsted',9,'bent.bogsted@ft.dk','+45 6162 3360',' '),
  ('Liselott','Blixt',10,'liselott.blixt@ft.dk','+45 6162 4626',' '),
  ('Jens Henrik','Thulesen Dahl',11,'jens.henrik.thulesen.dahl@ft.dk','+45 3337 5126',' '),
  ('Hans Kristian','Skibby',12,'hans.skibby@ft.dk','+45 6162 4231',' '),
  ('Dennis','Flydtkjær',13,'dennis.flydtkjaer@ft.dk','+45 3337 5112',' ');
GO

INSERT INTO Ejer (Ejer.Personid, Ejertype, Noter) VALUES
  (7,'Sommerhusejer','Noter:'),
  (8,'Sommerhusejer','Noter:'),
  (9,'Sommerhusejer','Noter:'),
  (10,'Sommerhusejer','Noter:'),
  (11,'Sommerhusejer','Noter:'),
  (12,'Sommerhusejer','Noter:'),
  (13,'Sommerhusejer','Noter:');
GO

