-- Creates the login tec with password 'OsteFis'

USE master
IF NOT EXISTS (SELECT name FROM sys.sql_logins WHERE name='tec')
  BEGIN
    CREATE LOGIN tec
      WITH PASSWORD = 'OsteFis';
    PRINT 'USER ''tec'' CREATED';
  END
ELSE
  BEGIN
    PRINT 'USER ''tec'' ALREADY EXISTS';
  END;


-- map user rights

USE [Sydvest-Bo]
GO
-- Check database user
IF USER_ID('tec') IS NULL
  CREATE USER tec FOR LOGIN tec;
GO

USE [Sydvest-Bo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [tec]
GO
USE [Sydvest-Bo]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [tec]
GO
USE [Sydvest-Bo]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [tec]
GO
