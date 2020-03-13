use [Sydvest-Bo2]
go

BULK INSERT [Zip Code and Town]
FROM '/Data/PostalCodes.csv'
WITH (FIRSTROW = 1,
    FIELDTERMINATOR = ',',
    ROWTERMINATOR='\n',
    BATCHSIZE=250000,
    MAXERRORS=2,
	codepage=65001);



