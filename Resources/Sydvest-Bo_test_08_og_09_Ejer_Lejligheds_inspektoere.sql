-- 8 Ejer_Lejligheds inspektoere --------------------------------

USE "Sydvest-Bo"
GO

INSERT INTO Adresse (Adressestring,Postnr) VALUES
  ('Sydvest-Bo admin 1 3. mf.',2450),
  ('Folketinget, Christiansborg Kontor 201',1240),
  ('Folketinget, Christiansborg Kontor 202',1240),
  ('Folketinget, Christiansborg Kontor 203',1240);
GO

USE "Sydvest-Bo"
GO
INSERT INTO Person (Fornavn, Efternavn, Adresseid, Email, Person.Tlf, [Password]) VALUES
  ('Test','Lejligheds inspektør',57,'inspektør@sydvest-bo.dk','26145443',' '),
  ('Ole','Birk Olesen',58,'ole.birk@ft.dk','+45 3337 4908',' '),
  ('Henrik','Dahl',59,'henrik.dahl@ft.dk','+45 6162 4573',' '),
  ('Alex','Vanopslagh',60,'alex.vanopslagh@ft.dk','+45 6162 5666',' ');
GO

INSERT INTO Ejer (Ejer.Personid, Ejertype, Noter) VALUES
  (29,'Lejligheds inspektør','Noter: Test Lejligheds inspektør'),
  (30,'Lejligheds inspektør','Noter:'),
  (31,'Lejligheds inspektør','Noter:'),
  (32,'Lejligheds inspektør','Noter:');
GO

-- 9 Opsysnmænd Lejligheds inspektoere --------------------------------

INSERT INTO Opsynsmand (Personid, Distriktid, Noter) VALUES
  (29,1,'Noter: Test Lejligheds inspektør'),
  (30,2,'Noter: Lejligheds inspektør'),
  (31,3,'Noter: Lejligheds inspektør'),
  (32,2,'Noter: Lejligheds inspektør');
GO

