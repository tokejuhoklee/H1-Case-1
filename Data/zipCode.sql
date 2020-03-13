use [Sydvest-Bo2]
go

BULK INSERT [Zip Code and Town]
FROM '/Users/dreams/Programming/H1-Case-1/Data/PostalCodes.csv'
WITH (FIRSTROW = 1,
    FIELDTERMINATOR = ',',
    ROWTERMINATOR='\n',
    BATCHSIZE=250000,
    MAXERRORS=2,
	codepage=65001);


