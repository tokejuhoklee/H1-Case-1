
USE "Sydvest-Bo"
GO

INSERT INTO Adresse (Adressestring,Postnr) VALUES
  ('Sydvest-Bo admin 1 st. tv.',2450),
  ('Svanelundsvej 36',9800),
  ('Paradisbakken 3',7660);
GO

INSERT INTO Person (Fornavn, Efternavn, Adresseid, Email, Person.Tlf, [Password]) VALUES
  ('Test','Kundekonsulent',4,'kundekonsulent@sydvest-bo.dk','26145443',' '),
  ('Per','Larsen',5,'per.larsen@ft.dk','+45 6162 3226',' '),
  ('Orla','Østerby',6,'orla.osterby@ft.dk','+45 6162 4914',' ');

GO

INSERT INTO Kundekonsulent (Personid, Noter) VALUES
  (4,'Noter: Testbruger og årets kundekonsulent'),
  (5,'Noter:'),
  (6,'Noter:');
GO

