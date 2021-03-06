-- 10 Feriebolig Lejligheder ------------------------------------------------------------------------------

--Feriebolig.Ferieboligid;Feriebolig.Distriktid;Feriebolig.Adresseid;Feriebolig.Ejerid;Feriebolig.Opsynsmandid;Feriebolig.Stoerrelse;Feriebolig.Rum;Feriebolig.Senge;Feriebolig.Kvalitet;Feriebolig.Pris;Feriebolig.FeriboligType;Feriebolig.Noter;Adresse.Adressestring;Adresse.Postnr

USE "Sydvest-Bo"
GO

INSERT INTO Adresse (Adressestring,Postnr) VALUES
  ('Sydvest-Bo admin 1 7. tv.',2450),
  ('Sydvest-Bo admin 1 7. mf.',2450),
  ('Sydvest-Bo admin 1 7. th.',2450),
  ('Folketinget, Christiansborg, Lejlighed 301',1240),
  ('Folketinget, Christiansborg, Lejlighed 302',1240),
  ('Folketinget, Christiansborg, Lejlighed 303',1240),
  ('Folketinget, Christiansborg, Lejlighed 304',1240),
  ('Folketinget, Christiansborg, Lejlighed 305',1240),
  ('Folketinget, Christiansborg, Lejlighed 306',1240),
  ('Folketinget, Christiansborg, Lejlighed 307',1240),
  ('Folketinget, Christiansborg, Lejlighed 308',1240),
  ('Folketinget, Christiansborg, Lejlighed 309',1240),
  ('Folketinget, Christiansborg, Lejlighed 310',1240),
  ('Folketinget, Christiansborg, Lejlighed 401',1240),
  ('Folketinget, Christiansborg, Lejlighed 402',1240),
  ('Folketinget, Christiansborg, Lejlighed 403',1240),
  ('Folketinget, Christiansborg, Lejlighed 404',1240),
  ('Folketinget, Christiansborg, Lejlighed 405',1240),
  ('Folketinget, Christiansborg, Lejlighed 406',1240),
  ('Folketinget, Christiansborg, Lejlighed 407',1240),
  ('Folketinget, Christiansborg, Lejlighed 408',1240),
  ('Folketinget, Christiansborg, Lejlighed 409',1240),
  ('Folketinget, Christiansborg, Lejlighed 410',1240),
  ('Ebeltoft Rådhus, Torvet 2A, Lejlighed 101',8400),
  ('Ebeltoft Rådhus, Torvet 2A, Lejlighed 102',8400),
  ('Ebeltoft Rådhus, Torvet 2A, Lejlighed 103',8400),
  ('Ebeltoft Rådhus, Torvet 2A, Lejlighed 201',8400),
  ('Ebeltoft Rådhus, Torvet 2A, Lejlighed 202',8400),
  ('Ebeltoft Rådhus, Torvet 2A, Lejlighed 203',8400),
  ('Ebeltoft Rådhus, Torvet 2A, Lejlighed 301',8400),
  ('Ebeltoft Rådhus, Torvet 2A, Lejlighed 302',8400),
  ('Ebeltoft Rådhus, Torvet 2A, Lejlighed 303',8400),
  ('Ebeltoft Rådhus, Torvet 2A, Lejlighed 401',8400);

  USE "Sydvest-Bo"
GO

INSERT INTO Feriebolig ( Distriktid, Adresseid, Ejerid, Opsynsmandid, Stoerrelse, Rum, Senge, Kvalitet, Pris, FeriboligType, Noter) VALUES
  (1,61,8,16,75,2,2,'8',5000,'Ferielejlighed','Noter: Test Feriebolig Lejlighed 1'),
  (1,62,8,16,75,2,2,'8',5000,'Ferielejlighed','Noter: Test Feriebolig Lejlighed 2'),
  (1,63,8,16,75,2,2,'8',5000,'Ferielejlighed','Noter: Test Feriebolig Lejlighed 3'),
  (2,64,9,17,24,1,2,'10',14995,'Ferielejlighed','Noter:'),
  (2,65,9,17,24,1,2,'10',14995,'Ferielejlighed','Noter:'),
  (2,66,9,17,24,1,2,'10',14995,'Ferielejlighed','Noter:'),
  (2,67,9,17,24,1,2,'10',14995,'Ferielejlighed','Noter:'),
  (2,68,9,17,24,1,2,'10',14995,'Ferielejlighed','Noter:'),
  (2,69,9,17,24,1,2,'10',14995,'Ferielejlighed','Noter:'),
  (2,70,9,17,24,1,2,'10',14995,'Ferielejlighed','Noter:'),
  (2,71,9,17,24,1,2,'10',14995,'Ferielejlighed','Noter:'),
  (2,72,9,17,24,1,2,'10',14995,'Ferielejlighed','Noter:'),
  (2,73,9,17,24,1,2,'10',14995,'Ferielejlighed','Noter:'),
  (2,74,11,19,24,1,2,'10',15000,'Ferielejlighed','Noter:'),
  (2,75,11,19,24,1,2,'10',15000,'Ferielejlighed','Noter:'),
  (2,76,11,19,24,1,2,'10',15000,'Ferielejlighed','Noter:'),
  (2,77,11,19,24,1,2,'10',15000,'Ferielejlighed','Noter:'),
  (2,78,11,19,24,1,2,'10',15000,'Ferielejlighed','Noter:'),
  (2,79,11,19,24,1,2,'10',15000,'Ferielejlighed','Noter:'),
  (2,80,11,19,24,1,2,'10',15000,'Ferielejlighed','Noter:'),
  (2,81,11,19,24,1,2,'10',15000,'Ferielejlighed','Noter:'),
  (2,82,11,19,24,1,2,'10',15000,'Ferielejlighed','Noter:'),
  (2,83,11,19,24,1,2,'10',15000,'Ferielejlighed','Noter:'),
  (3,84,10,18,16,1,2,'10',15000,'Ferielejlighed','Noter:'),
  (3,85,10,18,16,1,2,'10',15000,'Ferielejlighed','Noter:'),
  (3,86,10,18,16,1,2,'10',15000,'Ferielejlighed','Noter:'),
  (3,87,10,18,16,1,2,'10',20000,'Ferielejlighed','Noter:'),
  (3,88,10,18,16,1,2,'10',20000,'Ferielejlighed','Noter:'),
  (3,89,10,18,16,1,2,'10',20000,'Ferielejlighed','Noter:'),
  (3,90,10,18,16,1,2,'10',25000,'Ferielejlighed','Noter:'),
  (3,91,10,18,16,1,2,'10',25000,'Ferielejlighed','Noter:'),
  (3,92,10,18,16,1,2,'10',25000,'Ferielejlighed','Noter:'),
  (3,93,10,18,12,1,2,'10',30000,'Ferielejlighed','Noter:');
