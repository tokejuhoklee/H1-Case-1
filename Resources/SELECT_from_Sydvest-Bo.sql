USE "Sydvest-Bo"
GO

SELECT * FROM Adresse
-- where Adressestring = 'Sydvest-Bo admin 1 1. tv.'
GO

SELECT * FROM Distrikt
GO

SELECT * FROM Ejer
  JOIN Person ON Ejer.Personid = Person.Personid
  JOIN Adresse ON Person.Adresseid = Adresse.Adresseid
  JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr
GO

print 'Feriebolig';
SELECT * FROM "Feriebolig"
  JOIN Distrikt ON Feriebolig.Distriktid = Distrikt.Distriktid
  JOIN Ejer ON Feriebolig.Ejerid = Ejer.Ejerid
  JOIN Adresse ON Feriebolig.Adresseid = Adresse.Adresseid
  JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr
GO

print 'Feriebolig - Sommerhuse';
SELECT * FROM "Feriebolig"
  JOIN Distrikt ON Feriebolig.Distriktid = Distrikt.Distriktid
  JOIN Ejer ON Feriebolig.Ejerid = Ejer.Ejerid
  JOIN Adresse ON Feriebolig.Adresseid = Adresse.Adresseid
  JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr
  WHERE FeriboligType = 'Sommerhus'
  order by Ejer.Ejerid asc;
GO

print 'Feriebolig - Ferielejlighed';
SELECT * FROM "Feriebolig"
  JOIN Distrikt ON Feriebolig.Distriktid = Distrikt.Distriktid
  JOIN Ejer ON Feriebolig.Ejerid = Ejer.Ejerid
  JOIN Adresse ON Feriebolig.Adresseid = Adresse.Adresseid
  JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr
  WHERE FeriboligType = 'Ferielejlighed'
GO


SELECT * FROM Kunde
  JOIN Person ON Kunde.Personid = Person.Personid
  JOIN Adresse ON Person.Adresseid = Adresse.Adresseid
  JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr
GO

SELECT * FROM Kundekonsulent
  JOIN Person ON Kundekonsulent.Personid = Person.Personid
  JOIN Adresse ON Person.Adresseid = Adresse.Adresseid
  JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr
GO

SELECT * FROM Lejekontrakt
GO

SELECT * FROM Opsynsmand
  JOIN Person ON Opsynsmand.Personid = Person.Personid
  JOIN Adresse ON Person.Adresseid = Adresse.Adresseid
  JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr
GO

SELECT * FROM Person
  JOIN Adresse ON Person.Adresseid = Adresse.Adresseid
  JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr
GO

SELECT * FROM Saesonkategori
GO

SELECT * FROM Udlejningskonsulent
  JOIN Person ON Udlejningskonsulent.Personid = Person.Personid
  JOIN Adresse ON Person.Adresseid = Adresse.Adresseid
  JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr
GO

SELECT * FROM Udlejningskontrakt
GO

