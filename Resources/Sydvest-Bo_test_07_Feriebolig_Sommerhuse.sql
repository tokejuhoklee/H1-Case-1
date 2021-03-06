-- Feriebolig sommerhuse ---------------------------------

-- Feriebolig.Ferieboligid;Feriebolig.Distriktid;Feriebolig.Adresseid;Feriebolig.Ejerid;Feriebolig.Opsynsmandid;Feriebolig.Stoerrelse;Feriebolig.Rum;Feriebolig.Senge;Feriebolig.Kvalitet;Feriebolig.Pris;Feriebolig.FeriboligType;Feriebolig.Noter;Adresse.Adressestring;Adresse.Postnr
USE "Sydvest-Bo"
GO

INSERT INTO Adresse (Adressestring,Postnr) VALUES
  ('Sydvest-Bo admin 1 8. mf.',2450),
  ('Holbergsgade 6',1057),
  ('Beskæftigelsesministeriet, Holmens Kanal 20',1060),
  ('Holmens Kanal 9',1060),
  ('Klima-, Energi- og Forsyningsministeriet, Holmens Kanal 20',1060),
  ('Social- og indenrigsministeriet, Holmens Kanal 22',1060),
  ('Uddannelses- og forskningsministeriet, Børsgade 4',1215),
  ('Justitsministeriet, Slotsholmsgade 10',1216),
  ('Miljø- og Fødevareministeriet, Slotsholmsgade 12',1216),
  ('Udlændinge- og Integrationsministeriet, Slotsholmsgade 10',1216),
  ('Christiansborg Slotsplads 1',1218),
  ('Statsministeriet, Christiansborg, Prins Jørgens Gård 11',1218),
  ('Børne- og Undervisningsministeriet, Frederiksholms Kanal 21',1220),
  ('Transport- og Boligministeriet, Frederiksholms Kanal 27 F',1220),
  ('Slotsholmsgade 10-12',1240),
  ('Nicolai Eigtveds Gade 28',1402),
  ('Udenrigsministeriet, Asiatisk Plads 2',1448),
  ('Frederiksborgvej 572',4000),
  ('Enghavevej 35',4892),
  ('Højen 2 A',5330),
  ('Dalgårdsvej 124',6600),
  ('Jyllandsgade 6',7200),
  ('Gøgeurten 22',7500),
  ('Knud Rasmussens Vej 5',8200),
  ('Resedavej 19, 3. th.',8600),
  ('Spættevej 11, Øster Snede',8723),
  ('Aalborg Kloster, Klosterjordet 3',9000),
  ('Drosselvænget 2',9530);
GO

USE "Sydvest-Bo"
GO

INSERT INTO Feriebolig ( Distriktid, Adresseid, Ejerid, Opsynsmandid, Stoerrelse, Rum, Senge, Kvalitet, Pris, FeriboligType, Noter) VALUES
  (1, 29, 1, 1, 125, 5, 5, '10',10000.00, 'Sommerhus', 'Noter:'),
  (2, 30, 5, 2, 60, 4, 8, '4',8000.00, 'Sommerhus', 'Noter:'),
  (2, 31, 2, 1, 160, 4, 12, '9',9000.00, 'Sommerhus', 'Noter:'),
  (2, 32, 5, 1, 67, 3, 8, '4',10000.00, 'Sommerhus', 'Noter:'),
  (2, 33, 3, 1, 170, 5, 12, '7',7000.00, 'Sommerhus', 'Noter:'),
  (2, 34, 5, 1, 71, 4, 8, '4',10000.00, 'Sommerhus', 'Noter:'),
  (2, 35, 4, 1, 121, 5, 12, '8',8000.00, 'Sommerhus', 'Noter:'),
  (2, 36, 5, 1, 82, 3, 8, '4',10000.00, 'Sommerhus', 'Noter:'),
  (2, 37, 6, 1, 125, 4, 12, '9',9000.00, 'Sommerhus', 'Noter:'),
  (2, 38, 5, 1, 55, 5, 8, '4',10000.00, 'Sommerhus', 'Noter:'),
  (2, 39, 7, 1, 120, 5, 12, '7',7000.00, 'Sommerhus', 'Noter:'),
  (2, 40, 5, 1, 48, 3, 8, '4',10000.00, 'Sommerhus', 'Noter:'),
  (2, 41, 2, 1, 140, 5, 12, '8',8000.00, 'Sommerhus', 'Noter:'),
  (2, 42, 5, 1, 72, 4, 8, '4',10000.00, 'Sommerhus', 'Noter:'),
  (2, 43, 2, 1, 164, 5, 12, '9',9000.00, 'Sommerhus', 'Noter:'),
  (2, 44, 5, 1, 80, 4, 8, '3',10000.00, 'Sommerhus', 'Noter:'),
  (2, 45, 3, 1, 140, 5, 12, '7',7000.00, 'Sommerhus', 'Noter:'),
  (2, 46, 5, 1, 82, 3, 8, '4',10000.00, 'Sommerhus', 'Noter:'),
  (2, 47, 3, 1, 110, 6, 12, '8',8000.00, 'Sommerhus', 'Noter:'),
  (3, 48, 5, 1, 60, 4, 8, '4',10000.00, 'Sommerhus', 'Noter:'),
  (3, 49, 4, 1, 120, 5, 12, '9',9000.00, 'Sommerhus', 'Noter:'),
  (3, 50, 5, 1, 76, 3, 8, '4',10000.00, 'Sommerhus', 'Noter:'),
  (3, 51, 4, 1, 141, 5, 12, '7',7000.00, 'Sommerhus', 'Noter:'),
  (3, 52, 5, 1, 59, 2, 8, '4',10000.00, 'Sommerhus', 'Noter:'),
  (3, 53, 6, 1, 102, 5, 12, '9',9000.00, 'Sommerhus', 'Noter:'),
  (3, 54, 5, 1, 65, 3, 8, '4',10000.00, 'Sommerhus', 'Noter:'),
  (3, 55, 6, 1, 170, 5, 12, '9',9000.00, 'Sommerhus', 'Noter:'),
  (3, 56, 5, 1, 49, 3, 8, '4',10000.00, 'Sommerhus', 'Noter:');
GO

