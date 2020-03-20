USE [Sydvest-Bo]
GO


UPDATE Feriebolig
  SET Feriebolig.Distriktid = 2
  WHERE Ferieboligid = 16



/*
update Ordre
  set Ordre.totalpris = 400 from Ordre
  join Person on Ordre.P_id = Person.id
  join Vare on Ordre.v_id = Vare.vareid
  where Person.id = 3 or Person.id = 4
go
*/