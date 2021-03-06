-- Opsynsmand ------------------------

USE "Sydvest-Bo"
GO

INSERT INTO Adresse (Adressestring,Postnr) VALUES
  ('Sydvest-Bo admin 1 8. mf.',2450),
  ('Folketinget, Christiansborg Kontor 101',1240),
  ('Folketinget, Christiansborg Kontor 102',1240),
  ('Folketinget, Christiansborg Kontor 103',1240),
  ('Folketinget, Christiansborg Kontor 104',1240),
  ('Folketinget, Christiansborg Kontor 105',1240),
  ('Folketinget, Christiansborg Kontor 106',1240),
  ('Folketinget, Christiansborg Kontor 107',1240),
  ('Folketinget, Christiansborg Kontor 108',1240),
  ('Folketinget, Christiansborg Kontor 109',1240),
  ('Folketinget, Christiansborg Kontor 110',1240),
  ('Folketinget, Christiansborg Kontor 111',1240),
  ('Folketinget, Christiansborg Kontor 112',1240),
  ('Folketinget, Christiansborg Kontor 113',1240),
  ('Folketinget, Christiansborg Kontor 114',1240);
GO

INSERT INTO Person (Fornavn, Efternavn, Adresseid, Email, Person.Tlf, [Password]) VALUES
  ('Test','Opsynsmand',14,'opsynsmand@sydvest-bo.dk','26145443',' '),
  ('Uffe','Elbæk',15,'uffe.elbaek@ft.dk','+45 6162 5078',' '),
  ('Torsten','Gejl',16,'torsten.gejl@ft.dk','+45 6162 4651',' '),
  ('Rasmus','Nordqvist',17,'rasmus.nordqvist@ft.dk','+45 6162 4655',' '),
  ('Sikandar','Siddique',18,'sikandar.siddique@ft.dk','+45 6162 5962',' '),
  ('Susanne','Zimmer',19,'susanne.zimmer@ft.dk','+45 6162 5672',' '),
  ('Aaja','Chemnitz Larsen',20,'aaja.larsen@ft.dk','+45 6162 4667',' '),
  ('Sjúrður','Skaale',21,'sjurdur.skaale@ft.dk','+45 6162 5199',' '),
  ('Lars','Boje Mathiesen',22,'lars.mathiesen@ft.dk','+45 6162 5053',' '),
  ('Peter','Seier Christensen',23,'peter.christensen@ft.dk','+45 3337 5809',' '),
  ('Mette','Thiesen',24,'mette.thiesen@ft.dk','+45 3337 5813',' '),
  ('Pernille','Vermund',25,'pernille.vermund@ft.dk','+45 3337 5010',' '),
  ('Edmund','Joensen',26,'edmund.joensen@ft.dk','+45 3337 5429',' '),
  ('Aki-Matilda','Høegh-Dam',27,'akimatilda@ft.dk','+45 6162 5954',' '),
  ('Simon Emil','Ammitzbøll-Bille',28,'simon.ammitzboll@ft.dk','+45 3337 4903',' ');
GO

INSERT INTO Opsynsmand (Personid, Distriktid, Noter) VALUES
  (14,1,'Noter: Test Opsynsmand'),
  (15,3,'Noter:'),
  (16,2,'Noter:'),
  (17,3,'Noter:'),
  (18,2,'Noter:'),
  (19,3,'Noter:'),
  (20,2,'Noter:'),
  (21,1,'Noter:'),
  (22,3,'Noter:'),
  (23,2,'Noter:'),
  (24,3,'Noter:'),
  (25,2,'Noter:'),
  (26,3,'Noter:'),
  (27,2,'Noter:'),
  (28,3,'Noter:');
GO
