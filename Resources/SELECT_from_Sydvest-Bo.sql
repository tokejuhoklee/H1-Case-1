USE "Sydvest-Bo"
GO

SELECT * FROM "Adresse"
GO

SELECT * FROM "Distrikt"
GO

SELECT * FROM "Ejer"
GO

SELECT * FROM "Feriebolig"
  JOIN Distrikt ON Feriebolig.Distriktid = Distrikt.Distriktid
  JOIN Ejer ON Feriebolig.Ejerid = Ejer.Ejerid
  JOIN Adresse ON Feriebolig.Adresseid = Adresse.Adresseid
  JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr
GO

SELECT * FROM "Kunde"
GO

SELECT * FROM Kundekonsulent
  JOIN Person ON Kundekonsulent.Personid = Person.Personid
  JOIN Adresse ON Person.Adresseid = Adresse.Adresseid
  JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr

GO

SELECT * FROM "Lejekontrakt"
GO

SELECT * FROM Opsynsmand
  JOIN Person ON Opsynsmand.Personid = Person.Personid
  JOIN Adresse ON Person.Adresseid = Adresse.Adresseid
  JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr
GO

SELECT * FROM "Person"
  JOIN Adresse ON Person.Adresseid = Adresse.Adresseid
  JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr
GO

SELECT * FROM "Saesonkategori"
GO

SELECT * FROM Udlejningskonsulent
  JOIN Person ON Udlejningskonsulent.Personid = Person.Personid
  JOIN Adresse ON Person.Adresseid = Adresse.Adresseid
  JOIN PostnrBy ON Adresse.Postnr = PostnrBy.Postnr
GO

SELECT * FROM "Udlejningskontrakt"
GO

