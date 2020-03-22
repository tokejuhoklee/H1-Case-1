-- 03 Udlejningskonsulent ----------------

USE "Sydvest-Bo"
GO

INSERT INTO Adresse (Adressestring,Postnr) VALUES
  ('Sydvest-Bo admin 1 st. th.',2450),
  ('Sindalvej 4',6000),
  ('Nørregade 45 D',4600);
GO

INSERT INTO Person (Fornavn, Efternavn, Adresseid, Email, Person.Tlf, [Password]) VALUES
  ('Test','Udlejningskonsulent',1,'udlejningskonsulent@sydvest-bo.dk','26145443',' '),
  ('Karina','Lorentzen Dehnhardt',2,'karina.dehnhardt@ft.dk','+45 6162 3045',' '),
  ('Jacob','Mark',3,'jacob.mark@ft.dk','+45 3337 5500',' ');
GO

INSERT INTO Udlejningskonsulent (Personid, Distriktid,Noter) VALUES
  (1,1,'Noter:'),
  (2,2,'Noter:'),
  (3,3,'Noter:');
GO

