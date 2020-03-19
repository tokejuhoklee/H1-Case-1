/*
Person.Fornavn;Person.Efternavn;Adresse.Adressestring;Adresse.Postnr;Person.Email;Person.Tlf;Person.Password;Udlejningskonsulent.Distriktid
Test;Udlejningskonsulent;Sydvest-Bo admin 1 st. th.;2450;rasm42h0@elev.tec.dk;26145443; ;Test Distrikt
Karina;Lorentzen Dehnhardt;Sindalvej 4;6000;karina.dehnhardt@ft.dk;+45 6162 3045; ;Vest Danmark
Jacob;Mark;Nørregade 45 D;4600;jacob.mark@ft.dk;+45 3337 5500; ;Øst Danmark
*/

USE "Sydvest-Bo"
GO
/*
INSERT INTO Udlejningskonsulent (Person.Fornavn, Person.Efternavn, Adresse.Adressestring, Adresse.Postnr, Person.Email, Person.Tlf, Person.Password, Udlejningskonsulent.Distriktid) VALUES
  ('Test',';Udlejningskonsulent','Sydvest-Bo admin 1 st. th.',2450,'rasm42h0@elev.tec.dk','26145443',' ','Test Distrikt'),
  ('Karina','Lorentzen Dehnhardt','Sindalvej 4',6000,'karina.dehnhardt@ft.dk','+45 6162 3045',' ','Vest Danmark'),
  ('Jacob','Mark','Nørregade 45 D',4600,'jacob.mark@ft.dk','+45 3337 5500',' ','Øst Danmark');
GO
*/

INSERT INTO Adresse (Adressestring,Postnr) VALUES
  ('Sydvest-Bo admin 1 st. th.',2450),
  ('Sindalvej 4',6000),
  ('Nørregade 45 D',4600);
GO

INSERT INTO Person (Fornavn, Efternavn, Adresseid, Email, Person.Tlf, [Password]) VALUES
  ('Test','Udlejningskonsulent',1,'rasm42h0@elev.tec.dk','26145443',' '),
  ('Karina','Lorentzen Dehnhardt',2,'karina.dehnhardt@ft.dk','+45 6162 3045',' '),
  ('Jacob','Mark',3,'jacob.mark@ft.dk','+45 3337 5500',' ');
GO

INSERT INTO Udlejningskonsulent (Personid, Distriktid) VALUES
  (1,1),
  (2,2),
  (3,3);
GO

