-- 11 Kunde -------------------------------------

USE "Sydvest-Bo"
GO

INSERT INTO Adresse (Adressestring,Postnr) VALUES
  ('Sydvest-Bo admin 1 1. tv.',2450),
  ('Folketinget, Christiansborg Kontor 204',1240),
  ('Folketinget, Christiansborg Kontor 205',1240),
  ('Folketinget, Christiansborg Kontor 206',1240),
  ('Folketinget, Christiansborg Kontor 207',1240),
  ('Folketinget, Christiansborg Kontor 208',1240),
  ('Folketinget, Christiansborg Kontor 209',1240),
  ('Folketinget, Christiansborg Kontor 210',1240),
  ('Folketinget, Christiansborg Kontor 211',1240),
  ('Folketinget, Christiansborg Kontor 212',1240),
  ('Folketinget, Christiansborg Kontor 213',1240),
  ('Folketinget, Christiansborg Kontor 214',1240),
  ('Folketinget, Christiansborg Kontor 215',1240),
  ('Folketinget, Christiansborg Kontor 216',1240),
  ('Folketinget, Christiansborg Kontor 217',1240),
  ('Folketinget, Christiansborg Kontor 218',1240),
  ('Folketinget, Christiansborg Kontor 219',1240),
  ('Folketinget, Christiansborg Kontor 220',1240),
  ('Duevej 2',9000),
  ('C. F. Richs Vej 60',2000),
  ('Karlslunde Kysthave 9, 2. tv.',2690),
  ('Ellebyvej 11',3700),
  ('Egebjerg Landevej 14, Krogager',7200),
  ('Hermelinvej 4',8643),
  ('Friggsvang 3',6500),
  ('Stævnen 26.6.2',7100),
  ('Dybdalen 12',8960);
GO

USE "Sydvest-Bo"
GO
INSERT INTO Person (Fornavn, Efternavn, Adresseid, Email, Person.Tlf, [Password]) VALUES
  ('Test','Kunde',94,'kunde@sydvest-bo.dk','26145443',' '),
  ('Ida','Auken',95,'ida.auken@ft.dk','+45 3337 4710',' '),
  ('Anne Sophie','Callesen',96,'anne.sophie.callesen@ft.dk','+45 6162 4120',' '),
  ('Sofie','Carsten Nielsen',97,'sofie.carsten.nielsen@ft.dk','+45 3337 5500',' '),
  ('Kristian','Hegaard',98,'kristian.hegaard@ft.dk','+45 3337 4705',' '),
  ('Rasmus','Helveg Petersen',99,'rasmus.helveg.petersen@ft.dk','+45 3337 4720',' '),
  ('Marianne','Jelved',100,'marianne.jelved@ft.dk','+45 3337 4703',' '),
  ('Martin','Lidegaard',101,'martin.lidegaard@ft.dk','+45 3337 4716',' '),
  ('Stinus','Lindgreen',102,'stinus.lindgreen@ft.dk','+45 3337 4712',' '),
  ('Samira','Nawa',103,'samira.nawa@ft.dk','+45 6162 4111',' '),
  ('Kathrine','Olldag',104,'kathrine.olldag@ft.dk','+45 6162 3800',' '),
  ('Katrine','Robsøe',105,'katrine.robsoe@ft.dk','+45 6162 4155',' '),
  ('Lotte','Rod',106,'lotte.rod@ft.dk','+45 6162 5164',' '),
  ('Jens','Rohde',107,'jens.rohde@ft.dk','+45 3337 4701',' '),
  ('Nils','Sjøberg',108,'nils.sjoeberg@ft.dk','+45 6162 5368',' '),
  ('Zenia','Stampe',109,'zenia.stampe@ft.dk','+45 6162 5161',' '),
  ('Andreas','Steenberg',110,'andreas.steenberg@ft.dk','+45 6162 5075',' '),
  ('Morten','Østergaard',111,'morten.ostergaard@ft.dk','+45 3337 5500',' '),
  ('Marie','Bjerre',112,'marie.bjerre@ft.dk','+45 6162 3260',' '),
  ('Jan','E. Jørgensen',113,'jan.e@ft.dk','+45 3337 4551',' '),
  ('Morten','Dahlin',114,'morten.dahlin@ft.dk','+45 6162 5972',' '),
  ('Peter','Juel-Jensen',115,'peter.juel-jensen@ft.dk','+45 3337 4501',' '),
  ('Anni','Matthiesen',116,'anni.matthiesen@ft.dk','+45 6162 5172',' '),
  ('Kristian','Pihl Lorentzen',117,'kristian.lorentzen@ft.dk','+45 2752 2818',' '),
  ('Hans Christian','Schmidt',118,'hans.schmidt@ft.dk','+45 3337 4572',' '),
  ('Christoffer','Aagaard Melson',119,'christoffer.melson@ft.dk','+45 6162 3303',' '),
  ('Michael','Aastrup Jensen',120,'michael.aastrup@ft.dk','+45 6162 4225',' ');
GO


USE "Sydvest-Bo"
GO
INSERT INTO Kunde (Personid, Noter) VALUES
  (33,'Noter: Test Kunde'),
  (34,'Noter:'),
  (35,'Noter:'),
  (36,'Noter:'),
  (37,'Noter:'),
  (38,'Noter:'),
  (39,'Noter:'),
  (40,'Noter:'),
  (41,'Noter:'),
  (42,'Noter:'),
  (43,'Noter:'),
  (44,'Noter:'),
  (45,'Noter:'),
  (46,'Noter:'),
  (47,'Noter:'),
  (48,'Noter:'),
  (49,'Noter:'),
  (50,'Noter:'),
  (51,'Noter:'),
  (52,'Noter:'),
  (53,'Noter:'),
  (54,'Noter:'),
  (55,'Noter:'),
  (56,'Noter:'),
  (57,'Noter:'),
  (58,'Noter:'),
  (59,'Noter:');
go
